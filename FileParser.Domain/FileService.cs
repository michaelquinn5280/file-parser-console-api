
namespace FileParser.Domain
{
    /// <summary>
    /// File Service
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Person Service
        /// </summary>
        private readonly IPersonService _personService;

        /// <summary>
        /// Person Service
        /// </summary>
        /// <param name="personService"></param>
        public FileService(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Load files from file path
        /// </summary>
        /// <param name="filePath">File Path</param>
        /// <returns>Success Indicator</returns>
        public bool LoadFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) return false;

            char? fileDelimiter = null;
            string line;
            var file = new System.IO.StreamReader(filePath);

            while ((line = file.ReadLine()) != null)
            {
                if (fileDelimiter == null)
                    fileDelimiter = Helpers.Parser.GetDelimeter(line);
                _personService.AddPerson(Helpers.Parser.ParsePerson(line, fileDelimiter));
            }
            file.Close();
            return true;
        }
    }
}
