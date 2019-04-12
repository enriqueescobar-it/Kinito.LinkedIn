/**
* ExcelFile.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 11-04-2019
* OR 4/11/2019 1:41:43 PM
**/

namespace WpfApp.DataAccessLayer
{
    using System.IO;

    /// <summary>
    /// Defines the <see cref="ExcelFile" />
    /// </summary>
    public class ExcelFile
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelFile"/> class.
        /// </summary>
        public ExcelFile() => this.Filter = "Excel files (*.xlsx, *.xls)|*.xlsx;*.xls|Other files (*.tsv, *.csv)|*.tsv;*.csv";
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Filter
        /// </summary>
        public string Filter { get; internal set; }

        /// <summary>
        /// Gets or sets the FileInfo
        /// </summary>
        public FileInfo FileInfo { get; internal set; }
        #endregion

        #region Methods
        /// <summary>
        /// The SetFileInfo
        /// </summary>
        /// <param name="fileInfo">The fileInfo<see cref="FileInfo"/></param>
        internal void SetFileInfo(FileInfo fileInfo) => FileInfo = fileInfo;

        #endregion
    }
}
