using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Winium.Elements.Desktop.Extensions
{
    /// <summary>
    /// WebElement extensions.
    /// </summary>
    public static class WebElementExtensions
    {
        private static readonly MethodInfo ExecuteMethodInfo;
        private static readonly PropertyInfo IdPropertyInfo;

        static WebElementExtensions()
        {
            var type = typeof(RemoteWebElement);
            ExecuteMethodInfo = type.GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance);
            IdPropertyInfo = type.GetProperty("Id", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
        }


        /// <summary>
        /// Creates DataGrid wrapper for given element.
        /// </summary>
        /// <param name="element">WebElement representing DataGrid.</param>
        /// <returns>DataGrid wrapper.</returns>
        public static DataGrid ToDataGrid(this IWebElement element) =>
            new DataGrid(element);

        /// <summary>
        /// Creates ListBox wrapper for given element.
        /// </summary>
        /// <param name="element">WebElement representing ListBox.</param>
        /// <returns>ListBox wrapper.</returns>
        public static ListBox ToListBox(this IWebElement element) =>
            new ListBox(element);

        /// <summary>
        /// Creates ComboBox wrapper for given element.
        /// </summary>
        /// <param name="element">WebElement representing ComboBox.</param>
        /// <returns>ComboBox wrapper.</returns>
        public static ComboBox ToComboBox(this IWebElement element) =>
            new ComboBox(element);

        /// <summary>
        /// Creates Menu wrapper for given element.
        /// </summary>
        /// <param name="element">WebElement representing Menu.</param>
        /// <returns>Menu wrapper.</returns>
        public static Menu ToMenu(this IWebElement element) =>
            new Menu(element);

        /// <summary>
        /// Helper to call RemoteWebElement.Execute method with signature:
        /// <para>
        /// Response Execute(string commandToExecute, Dictionary&lt;string, object&gt; parameters);
        /// </para>
        /// </summary>
        /// <param name="element">Target element.</param>
        /// <param name="parameters">commandToExecute: string, parameters: Dictionary&lt;string, object&gt;.</param>
        /// <returns>Response.</returns>
        public static Response Execute(this IWebElement element, params object[] parameters) =>
            (Response)ExecuteMethodInfo.Invoke(element, parameters);

        /// <summary>
        /// Helper to get Element identifier.
        /// </summary>
        /// <param name="element">Target element.</param>
        /// <returns>Element UID.</returns>
        public static string GetId(this IWebElement element) =>
            IdPropertyInfo.GetValue(element, null).ToString();

    }
}
