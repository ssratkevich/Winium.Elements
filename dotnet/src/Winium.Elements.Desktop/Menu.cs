using System.Collections.Generic;
using OpenQA.Selenium;

namespace Winium.Elements.Desktop
{
    /// <summary>
    /// Wrapper for Menu element.
    /// </summary>
    public class Menu : DesktopElement
    {
        #region Constants

        private const string FindMenuItem = "findMenuItem";

        private const string SelectMenuItem = "selectMenuItem";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Creates wrapper web element representing Menu.
        /// </summary>
        /// <param name="element">Web element representing Menu.</param>
        public Menu(IWebElement element)
            : base(element)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Find element by path.
        /// </summary>
        /// <param name="path">Headers path with '$' separator (ex:control$view$zoom).</param>
        /// <returns>Found element.</returns>
        public IWebElement FindItem(string path) =>
            this.CallMenuItemCommand(FindMenuItem, path);

        /// <summary>
        /// Select element by path.
        /// </summary>
        /// <param name="path">Headers path with '$' separator (ex:control$view$zoom).</param>
        /// <returns>Selected element.</returns>
        public IWebElement SelectItem(string path) =>
            this.CallMenuItemCommand(SelectMenuItem, path);

        #endregion

        #region Methods

        private IWebElement CallMenuItemCommand(string command, string path) =>
            this.CreateRemoteWebElementFromResponse(
                this.Execute(command,
                    new Dictionary<string, object>
                    { 
                        { "id", this.Id},
                        { "path", path}
                    }));

        #endregion
    }
}
