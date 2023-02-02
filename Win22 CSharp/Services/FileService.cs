
namespace Win22_CSharp.Services
{
    public class FileService
    {
        public string FilePath { get; set; } = null!;

        public void Save(string FilePath, string content)
        {
            using var sw = new StreamWriter(FilePath);
            sw.Write(content);
            
        }
        public string Read(string FilePath)
        {
            try
            {
                using var sr = new StreamReader(FilePath);
                return sr.ReadToEnd();
            }
            catch { return null!; }
        }
    }
}
