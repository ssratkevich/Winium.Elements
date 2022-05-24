using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Winium.Elements.Desktop
{
    /// <summary>
    /// Represents a DataGrid control.
    /// </summary>
    public class DataGrid : DesktopElement
    {
        #region Constants

        private const string FindDataGridCell = "findDataGridCell";

        private const string GetDataGridColumnCount = "getDataGridColumnCount";

        private const string GetDataGridRowCount = "getDataGridRowCount";

        private const string ScrollToDataGridCell = "scrollToDataGridCell";

        private const string SelectDataGridCell = "selectDataGridCell";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Creates DataGrid wrapper element.
        /// </summary>
        /// <param name="element">Web element that is DataGrid.</param>
        public DataGrid(IWebElement element)
            : base(element)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Columns count.
        /// </summary>
        public int ColumnCount
        {
            get
            {
                var parameters = new Dictionary<string, object> { { "id", this.Id } };
                var response = this.Execute(GetDataGridColumnCount, parameters);

                return int.Parse(response.Value.ToString());
            }
        }

        /// <summary>
        /// Rows count.
        /// </summary>
        public int RowCount
        {
            get
            {
                var parameters = new Dictionary<string, object> { { "id", this.Id } };
                var response = this.Execute(GetDataGridRowCount, parameters);

                return int.Parse(response.Value.ToString());
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Find element in given position.
        /// </summary>
        /// <param name="row">Row number.</param>
        /// <param name="column">Column number.</param>
        /// <returns>Element.</returns>
        public IWebElement Find(int row, int column) =>
            this.CreateRemoteWebElementFromResponse(this.CallDataGridCellCommand(FindDataGridCell, row, column));

        /// <summary>
        /// Scroll view to element.
        /// </summary>
        /// <param name="row">Row number.</param>
        /// <param name="column">Column number.</param>
        public void ScrollTo(int row, int column) =>
            this.CallDataGridCellCommand(ScrollToDataGridCell, row, column);

        /// <summary>
        /// Select element.
        /// </summary>
        /// <param name="row">Row number.</param>
        /// <param name="column">Column number.</param>
        public void Select(int row, int column) =>
            this.CallDataGridCellCommand(SelectDataGridCell, row, column);

        #endregion

        #region Methods

        private Response CallDataGridCellCommand(string command, int row, int column) =>
            this.Execute(command, new Dictionary<string, object>
            {
                { "id", this.Id },
                { "row", row },
                { "column", column }
            });

        #endregion
    }
}
