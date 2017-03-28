namespace SharePoint.FileChecker
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Provides access to P/Invoke methods.
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// Attaches the calling process to the console of the current process.
        /// </summary>
        private const int ATTACH_PARENT_PROCESS = -1;

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool AttachConsole(int dwProcessId);
    }
}
