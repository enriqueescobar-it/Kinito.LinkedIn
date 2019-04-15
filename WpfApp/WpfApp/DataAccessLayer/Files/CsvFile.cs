/**
* CsvFile.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 11-04-2019
* OR 4/11/2019 1:41:43 PM
**/

namespace WpfApp.DataAccessLayer.Files
{
    using System.Collections.Generic;
    using System.Linq;
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
        public CsvFile() => this.Filter = "Csv files (*.tsv, *.csv)|*.tsv;*.csv|Other files (*.*sv, *.txt)|*.*sv;*.txt";
        #endregion

        #region Properties
        /// <summary>Gets a value indicating whether this instance is readable.</summary>
        /// <value><SPAN class=code>true</SPAN> if this instance is readable; otherwise, <SPAN class=code>false</SPAN>.</value>
        public bool IsReadable { get; internal set; }

        /// <summary>Gets a value indicating whether this instance is locked.</summary>
        /// <value><SPAN class=code>true</SPAN> if this instance is locked; otherwise, <SPAN class=code>false</SPAN>.</value>
        public bool IsLocked { get; internal set; }

        /// <summary>
        /// Gets or sets the Filter
        /// </summary>
        public string Filter { get; internal set; }

        /// <summary>Gets the extension.</summary>
        /// <value>The extension.</value>
        public string Extension { get; internal set; }

        /// <summary>
        /// Gets or sets the FileInfo
        /// </summary>
        public FileInfo FileInfo { get; internal set; }

        /// <summary>Gets the directory information.</summary>
        /// <value>The directory information.</value>
        public DirectoryInfo DirectoryInfo { get; internal set; }

        /// <summary>Gets the ur ls.</summary>
        /// <value>The ur ls.</value>
        public List<UrlLink> URLs { get; internal set; }
        #endregion

        #region Methods
        /// <summary>
        /// The SetFileInfo
        /// </summary>
        /// <param name="fileInfo">The fileInfo<see cref="FileInfo"/></param>
        internal void SetFileInfo(FileInfo fileInfo)
        {
            if(string.IsNullOrWhiteSpace(fileInfo.FullName)) throw new FileLoadException();

            if(!fileInfo.Exists) throw new FileNotFoundException();

            this.FileInfo = fileInfo;
            this.Extension = fileInfo.Extension;
            this.DirectoryInfo = fileInfo.Directory;
            this.IsLocked = IsFileUsedbyAnotherProcess(fileInfo.FullName);
            this.IsReadable = fileInfo.Exists && !this.IsLocked;
        }

        /// <summary>Reads this instance.</summary>
        /// <returns></returns>
        internal bool Read()
        {
            if (this.IsReadable)
            {
                List<string> stringList = new List<string>();

                using (StreamReader streamReader = new StreamReader(File.OpenRead(this.FileInfo.FullName)))
                    while (!streamReader.EndOfStream)
                        stringList.Add(streamReader.ReadLine().TrimStart('"').TrimEnd('"').Trim());

                stringList = stringList.OrderByDescending(q => q).Distinct().ToList();
                List<UrlLink> urlLinks = new List<UrlLink>();

                foreach (string s in stringList)
                    urlLinks.Add(new UrlLink(s));

                urlLinks.RemoveAll(item => item == null);
                this.URLs = urlLinks;

                return urlLinks.Count !=0;
            }
            else return false;
        }

        /// <summary>Determines whether [is file usedby another process] [the specified filename].</summary>
        /// <param name="filename">The filename.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is file usedby another process] [the specified filename]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private static bool IsFileUsedbyAnotherProcess(string filename)
        {
            try
            {
                using (FileStream file = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                }
            }
            catch (IOException exp)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
