
using System.IO;

namespace Win22_CSharp.Services
{
    public class FileService
    {
        public string FilePath { get; set; } = null!;

        public void Save(string content)
        {
            using var sw = new StreamWriter(FilePath);
            sw.Write(content);

        }
        public string Read()
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