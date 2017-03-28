namespace SharePoint.FileChecker
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Provides methods for enumerating files in one 
    /// or more directories that contain the characters that cannot 
    /// be used with Microsoft SharePoint and OneDrive for Business. 
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Implements a new Regex Class for the specified regular expression.
        /// </summary>
        private static Regex pattern = new Regex(@"[\\\|~#%*\:{}?/]+", RegexOptions.Compiled);

        [STAThread]

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Specifies arguments passed to the command line.</param>
        private static void Main(string[] args)
        {
            ArgsCollection command = new ArgsCollection(args);

            string dir = command["d"];

            NativeMethods.AttachConsole(-1);

            if (command["d"] != null)
            {
                Console.Title = "SharePoint File Validation Tool";
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("FileChecker Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
                Console.WriteLine("Copyright (c) 2017 Microsoft Corporation.  All rights reserved.");
                Console.WriteLine(Environment.NewLine);

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

                        DirectoryInfo source = new DirectoryInfo(dir);

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

                                    Console.WriteLine(count + ".  " + name);

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
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine(i + " issues discovered parsing " + count + " files.  Refer to FileCheckerResults.csv for additional details.");
                            Console.WriteLine(Environment.NewLine);         
                            Console.WriteLine("For additional information on file and folder name restrictions see also http://support.microsoft.com/kb/905231.");
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine("To resolve these issues automatically download and run the Easy Fix tool from http://aka.ms/easyfix20150.");
                        }
                        else if (i == 0)
                        {
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine(i + " issues discovered parsing " + count + " files.");
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine("For additional information on file and folder name restrictions see also http://support.microsoft.com/kb/905231.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Exception Occurred: " + ex.Message);
                    Console.Error.Close();
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Dispose();
                    }
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Control());
            }
        }
    }
}
