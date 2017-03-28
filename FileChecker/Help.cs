//-----------------------------------------------------------------------
// <copyright file="Help.cs" company="Microsoft Corporation">
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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Contains help documentation for command line
    /// options.
    /// </summary>
    public partial class Help : Form
    {
        /// <summary>
        /// Initializes a new instance of the Help class.
        /// </summary>
        public Help()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
