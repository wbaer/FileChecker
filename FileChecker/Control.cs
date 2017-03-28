//-----------------------------------------------------------------------
// <copyright file="Control.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <author>Bill Baer</author>
//-----------------------------------------------------------------------

namespace SharePoint.FileChecker
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Contains methods to support validation of files
    /// for use with OneDrive for Business and SharePoint
    /// Online.
    /// </summary>
    public partial class Control : Form
    {
        /// <summary>
        /// Implements a new Regex Class for the specified regular expression.
        /// </summary>
        private static Regex pattern = new Regex(@"[\\\|~#%*\:{}?/]+", RegexOptions.Compiled);

        /// <summary>
        /// Initializes a new instance of the Control class.
        /// </summary>
        public Control()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///  Opens the source input directory for file validation.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            try
            {
                openFolder.ShowDialog();
                this.inputBox.Text = openFolder.SelectedPath.ToString();
            }
            finally
            {
                openFolder.Dispose();
            }
        }

        /// <summary>
        /// Provides methods for enumerating files in one 
        /// or more directories that contain the characters that cannot 
        /// be used with Microsoft SharePoint and OneDrive for Business. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void Validate_Click(object sender, EventArgs e)
        {
            Stream stream = null;

            try
            {
                int count = 0;

                stream = new FileStream("FileCheckerResults.csv", FileMode.OpenOrCreate);

                using (StreamWriter writer = new StreamWriter(stream))
                {
                    stream = null;

                    writer.WriteLine("Condition,File Name,Invalid Character,Path,Rule Violation");

                    int i = 0;

                    DirectoryInfo source = new DirectoryInfo(this.inputBox.Text);

                    foreach (DirectoryInfo di in source.GetDirectories())
                    {
                        if (di != null)
                        {
                            FileInfo[] files = source.GetFiles("*.*", SearchOption.AllDirectories);

                            foreach (FileInfo file in files)
                            {
                                count++;

                                string name = Path.GetFileName(file.Name);
                                Match match = pattern.Match(name);

                                this.outputBox.AppendText(count + ".  " + name);
                                this.outputBox.AppendText(Environment.NewLine);

                                var namespaces = new List<string>() { "Icon", ".lock", "CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9", "desktop.ini", "thumbs.db", "ehtumbs.db" };
                                var extensions = new List<string>() { ".aspx", ".asmx", ".ascx", ".master", ".xap", ".swf", ".jar", ".xsf", ".htc", ".tmp", ".ds_store" };

                                string extension = Path.GetFileName(file.Extension);
                                if (extensions.Contains(extension))
                                {
                                    writer.WriteLine("Error," + name + "," + extension + "," + file.FullName + ",Files cannot be of the following type " + extension + "With group-connected team sites, you cannot upload these files.");
                                    i++;
                                }
                                else if (name.Equals(namespaces))
                                {
                                    writer.WriteLine("Error," + name + "," + extension + "," + file.FullName + ",Filenames cannot be of the following type " + namespaces + " Also avoid these names followed immediately by an extension; for example, NUL.txt is not recommended.");
                                    i++;
                                }
                                else if (match.Success)
                                {
                                    writer.WriteLine("Error," + name + "," + match + match.NextMatch() + "," + file.FullName + ",You cannot use the following character anywhere in a file name " + match + match.NextMatch() + ".");
                                    i++;
                                }
                                else if (name.StartsWith("_", StringComparison.OrdinalIgnoreCase))
                                {
                                    writer.WriteLine("Warning," + name + "," + "_" + "," + file.FullName + ",If you use an underscore character (_) at the beginning of a file name the file will be a hidden file when using Open in Explorer.");
                                    i++;
                                }
                                else if (name.Contains(".."))
                                {
                                    writer.WriteLine("Error," + name + "," + ".." + "," + file.FullName + ",You cannot use the period character consecutively in the middle of a file name.");
                                    i++;
                                }
                                else if (name.EndsWith(".", StringComparison.OrdinalIgnoreCase))
                                {
                                    writer.WriteLine("Warning," + name + "," + "." + "," + file.FullName + ",Do not end a file or directory name with a period. Although the underlying file system may support such names, the Windows shell and user interface does not.");
                                    i++;
                                }
                                else if (file.Length.Equals(0))
                                {
                                    writer.WriteLine("Error," + name + "," + string.Empty + "," + file.FullName + ",Files cannot be empty.");
                                    i++;
                                }
                                else if (file.Length > 16106127360)
                                {
                                    writer.WriteLine("Error," + name + "," + string.Empty + "," + file.FullName + ",Files cannot be larger than 15GB.");
                                    i++;
                                }
                                else if (name.Length > 256)
                                {
                                    writer.WriteLine("Error," + name + "," + string.Empty + "," + file.FullName + ",File names cannot exceed 256 characters.");
                                    i++;
                                }
                            }
                            break;
                        }
                    }

                    if (i > 0)
                    {
                        this.outputBox.AppendText(Environment.NewLine);
                        this.outputBox.AppendText(i + " issues discovered parsing " + count + " files.  Refer to FileCheckerResults.csv for additional details.");
                        this.outputBox.AppendText(Environment.NewLine);
                        this.outputBox.AppendText(Environment.NewLine);
                        this.outputBox.AppendText("For additional information on file and folder name restrictions see also http://support.microsoft.com/kb/905231.");
                        this.outputBox.AppendText(Environment.NewLine);
                        this.outputBox.AppendText(Environment.NewLine);
                        this.outputBox.AppendText("To resolve these issues automatically download and run the Easy Fix tool from http://aka.ms/easyfix20150.");
                    }
                    else if (i == 0)
                    {
                        this.outputBox.AppendText(Environment.NewLine);
                        this.outputBox.AppendText(i + " issues discovered parsing " + count + " files.");
                        this.outputBox.AppendText(Environment.NewLine);
                        this.outputBox.AppendText(Environment.NewLine);
                        this.outputBox.AppendText("For additional information on file and folder name restrictions see also http://support.microsoft.com/kb/905231.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
                throw;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }
        }

        /// <summary>
        /// Opens the application Help control.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A EventArgs instance that contains the event data.</param>
        private void Command_Click(object sender, EventArgs e)
        {
            Help options = new Help();
            try
            {
                options.ShowDialog();
            }
            finally
            {
                options.Dispose();
            }
        }

        /// <summary>
        /// Informs all message pumps that they must terminate,
        /// and then closes all application windows after the
        /// messages have been processed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Displays a message box with information about the application.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A EventArgs instance that contains the event data.</param>
        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "FileChecker\n" + "Version " + Application.ProductVersion.ToString() + "\nCopyright © 2017 " + Application.CompanyName.ToString() + "." + "\nAll Rights Reserved." + "\n\nMicrosoft .NET Framework " + Environment.Version.ToString(), "About FileChecker", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
        }

        /// <summary>
        /// Opens the TechCenters for IT Products and Technologies in a new
        /// browser window.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A EventArgs instance that contains the event data.</param>
        private void TechCenter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://go.microsoft.com/fwlink/?LinkId=34401");
        }
    }
}
