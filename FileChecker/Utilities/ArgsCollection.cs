namespace SharePoint.FileChecker
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Class the provides methods for working with command line arguments.
    /// </summary>
    public sealed class ArgsCollection : StringDictionary, ICollection
    {
        /// <summary>
        /// Specifies immutable regular expressions.
        /// </summary>
        private static Regex operators = new Regex(@"^([/-]|--){1}(?<name>\w+)([:=])?(?<value>.+)?$", RegexOptions.Compiled);

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgsCollection"/> class.
        /// </summary>
        /// <param name="args">Specifies arguments passed to the command line.</param>
        public ArgsCollection(string[] args)
        {
            string name = null;
            char[] chars = { '"', '\'' };
            foreach (string arg in args)
            {
                Match match = operators.Match(arg);

                if (!match.Success)
                {
                    if (name != null)
                    {
                        this[name] = arg.Trim(chars);
                    }
                }
                else
                {
                    name = match.Groups["name"].Value;
                    this.Add(name, match.Groups["value"].Value.Trim(chars));
                }
            }
        }
    }
}