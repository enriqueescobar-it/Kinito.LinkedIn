/**
* CsvFile.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 11-04-2019
* OR 4/11/2019 1:41:43 PM
**/

namespace WpfApp.DataAccessLayer
{
    using System.IO;

    /// <summary>
    /// Defines the <see cref="CsvFile" />
    /// </summary>
    public class CsvFile
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CsvFile"/> class.
        /// </summary>
        public CsvFile() => this.CsvFilter = "Csv files (*.tsv, *.csv)|*.tsv;*.csv|Other files (*.*sv, *.txt)|*.*sv;*.txt";
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the CsvFilter
        /// </summary>
        public string CsvFilter { get; internal set; }

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
