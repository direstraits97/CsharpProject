using System.Text;
using System.Text.Json;

namespace CsharpProject
{
    public class JsonBookRegisterStorage : IBookRegisterStorage
    {
        private readonly string filename;

        public JsonBookRegisterStorage(string filename)
        {
            this.filename = filename;
        }

        public List<Book> Load()
        {
            if (!File.Exists(filename))
                return new List<Book>();

            string jsonString = File.ReadAllText(filename, Encoding.UTF8);

            return JsonSerializer.Deserialize<List<Book>>(jsonString)
                ?? new List<Book>();
        }

        public void Save(List<Book> books)
        {
            string jsonString = JsonSerializer.Serialize(books);
            File.WriteAllText(filename, jsonString, Encoding.UTF8);
        }
    }
}
