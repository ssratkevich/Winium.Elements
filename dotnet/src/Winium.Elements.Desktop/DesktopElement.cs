using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Winium.Elements.Desktop.Extensions;

namespace Winium.Elements.Desktop
{
    /// <summary>
    /// Wrapper for WebElement.
    /// </summary>
    public abstract class DesktopElement : RemoteWebElement
    {
        #region Constructors and Destructors

        /// <summary>
        /// Creates DesktopElement wrapper for WebElement.
        /// </summary>
        /// <param name="element">Web element.</param>
        protected DesktopElement(IWebElement element)
            : base(GetRemoteWebDriver(element), element.GetId())
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create WebElement from response.
        /// </summary>
        /// <param name="response">Selenium response.</param>
        /// <returns>Element.</returns>
        protected RemoteWebElement CreateRemoteWebElementFromResponse(Response response)
        {
            var elementDictionary = response.Value as Dictionary<string, object>;
            if (elementDictionary == null)
            {
                return null;
            }

            return new RemoteWebElement((RemoteWebDriver)this.WrappedDriver, (string)elementDictionary["ELEMENT"]);
        }

        private static RemoteWebDriver GetRemoteWebDriver(IWebElement element)
        {
            var remoteWebElement = element as RemoteWebElement;
            if (remoteWebElement == null)
            {
                throw new InvalidCastException("Specified cast is not valid. Please use RemoteWebElement as parameter.");
            }

            return (RemoteWebDriver)remoteWebElement.WrappedDriver;
        }

        #endregion
    }
}
