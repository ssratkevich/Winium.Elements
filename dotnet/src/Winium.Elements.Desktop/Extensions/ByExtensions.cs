using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace Winium.Elements.Desktop.Extensions
{
    /// <summary>
    /// By strategy extensions.
    /// </summary>
    public static class ByExtensions
    {
        #region Constants

        private const string DescriptionRegexp = @"\.(.*)\: (.*)";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Get strategy from it's string representation.
        /// </summary>
        /// <param name="by">Search strategy.</param>
        /// <returns>Strategy string (eg.: name, id, classname).</returns>
        public static object GetStrategy(this By by)
        {
            var match = Regex.Match(by.ToString(), DescriptionRegexp);
            return Regex.Replace(match.Groups[1].Value, "([A-Z])", " $1").Split('[').First().Trim().ToLower();
        }

        /// <summary>
        /// Get strategy value from it's string representation.
        /// </summary>
        /// <param name="by">Search strategy.</param>
        /// <returns>Strategy value.</returns>
        public static object GetValue(this By by)
        {
            var match = Regex.Match(by.ToString(), DescriptionRegexp);
            return match.Groups[2].Value;
        }

        #endregion
    }
}
