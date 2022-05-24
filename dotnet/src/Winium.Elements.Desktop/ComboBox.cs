using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Winium.Elements.Desktop.Extensions;

namespace Winium.Elements.Desktop
{
    /// <summary>
    /// Represents ComboBox control.
    /// </summary>
    public class ComboBox : DesktopElement
    {
        #region Constants

        private const string CollapseComboBox = "collapseComboBox";

        private const string ExpandComboBox = "expandComboBox";

        private const string FindComboBoxSelectedItem = "findComboBoxSelectedItem";

        private const string IsComboBoxExpanded = "isComboBoxExpanded";

        private const string ScrollToComboBoxItem = "scrollToComboBoxItem";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Creates a wrapper for web element representing ComboBox control.
        /// </summary>
        /// <param name="element">Web element representing ComboBox control.</param>
        public ComboBox(IWebElement element)
            : base(element)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Is ComboBox expanded.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                var parameters = new Dictionary<string, object> { { "id", this.Id } };
                var response = this.Execute(IsComboBoxExpanded, parameters);

                return bool.Parse(response.Value.ToString());
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Collapse comboBox.
        /// </summary>
        public void Collapse() =>
            this.CallComboBoxCommand(CollapseComboBox);

        /// <summary>
        /// Expand comboBox.
        /// </summary>
        public void Expand() =>
            this.CallComboBoxCommand(ExpandComboBox);

        /// <summary>
        /// Find selected item.
        /// </summary>
        /// <returns>Selected element.</returns>
        public IWebElement FindSelected() =>
            this.CreateRemoteWebElementFromResponse(this.CallComboBoxCommand(FindComboBoxSelectedItem));

        /// <summary>
        /// Scroll to element given by strategy.
        /// </summary>
        /// <param name="by">Element search strategy.</param>
        /// <returns>Element.</returns>
        public IWebElement ScrollTo(By by)
        {
            var response = this.Execute(
                ScrollToComboBoxItem,
                new Dictionary<string, object>
                    {
                        { "id", this.Id },
                        { "using", by.GetStrategy() },
                        { "value", by.GetValue() },
                    });

            return this.CreateRemoteWebElementFromResponse(response);
        }

        #endregion

        #region Methods

        private Response CallComboBoxCommand(string command) =>
            this.Execute(command, new Dictionary<string, object>
            {
                { "id", this.Id }
            });

        #endregion
    }
}
