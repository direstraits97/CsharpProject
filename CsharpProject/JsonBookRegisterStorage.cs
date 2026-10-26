<<<<<<< Updated upstream
﻿
=======
﻿/*
 * Filnamn: JsonBookRegisterStorage.cs
 * Författare: Josefine Backlund
 * Datum: 2026-10-26
 * Kurs: Programmering i C#.NET
 * 
 * Beskrivning:
 * Klassfil som skapar ett bokregister enligt ett interface med etablerade metoder: att spara och hämta lagrade inlägg i json-format.
 */

using System.Text;
using System.Text.Json;

namespace CsharpProject
{
    public class JsonBookRegisterStorage : IBookRegisterStorage //Följer interface.
    {
        private readonly string filename;

        public JsonBookRegisterStorage(string filename)
        {
            this.filename = filename; //Används som argument vid skapad lagring.
        }

        public List<Book> Load()
        {
            if (!File.Exists(filename))
                return new List<Book>(); //Om filen ej finns.

            string jsonString = File.ReadAllText(filename, Encoding.UTF8); //Läser upp filen som sträng.

            return JsonSerializer.Deserialize<List<Book>>(jsonString)
                ?? new List<Book>(); //Hämtar json-fil omvandlad till lista enligt Book.cs, om null en tom lista.
        }

        public void Save(List<Book> books)
        {
            string jsonString = JsonSerializer.Serialize(books); //Omvandlar lagrade inlägg till json.
            File.WriteAllText(filename, jsonString, Encoding.UTF8); //Skapar eller skriver över fil med de lagrade böckerna.
        }
    }
}
>>>>>>> Stashed changes
