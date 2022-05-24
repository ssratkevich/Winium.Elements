using System.Collections.Generic;
using OpenQA.Selenium;
using Winium.Elements.Desktop.Extensions;

namespace Winium.Elements.Desktop
{
    /// <summary>
    /// ListBox representation.
    /// </summary>
    public class ListBox : DesktopElement
    {
        #region Constants

        private const string ScrollToListBoxItem = "scrollToListBoxItem";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Creates a wrapper for web element representing ListBox.
        /// </summary>
        /// <param name="element">Web element representing ListBox.</param>
        public ListBox(IWebElement element)
            : base(element)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Scrolls to element given by strategy.
        /// </summary>
        /// <param name="by">Element search strategy.</param>
        /// <returns>Element.</returns>
        public IWebElement ScrollTo(By by) =>
            this.CreateRemoteWebElementFromResponse(
                this.Execute(
                    ScrollToListBoxItem,
                    new Dictionary<string, object>
                    {
                        { "id", this.Id },
                        { "using", by.GetStrategy() },
                        { "value", by.GetValue() },
                    }));

        #endregion
    }
}
