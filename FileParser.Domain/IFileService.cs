namespace FileParser.Domain
{
    public interface IFileService
    {
        /// <summary>
        /// Load files from file path
        /// </summary>
        /// <param name="filePath">File Path</param>
        /// <returns>Success Indicator</returns>
        bool LoadFile(string filePath);
    }
}