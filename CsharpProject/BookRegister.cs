/*
 * Filnamn: BookRegister.cs
 * Författare: Josefine Backlund
 * Datum: 2026-10-26
 * Kurs: Programmering i C#.NET
 * 
 * Beskrivning:
 * Klassfil som skapar bokregister och lagring. Lagrade böcker hämtas och metoder för att skapa, ändra, filtrera och radera böcker är inkluderade.
 */

namespace CsharpProject
{
    public class BookRegister
    {
        private readonly IBookRegisterStorage storage; //Lagring med metoder enligt IBookRegisterStorage.

        private List<Book> books = new List<Book>(); //Böcker hamnar under books.

        public BookRegister(IBookRegisterStorage storage) //Skapar bokregister.
        {
            this.storage = storage; //Filväg som anges i Program.cs.
            books = storage.Load(); //Hämtar filer från angedd sökväg.
        }

        public void addBook(string title, string author, string genre, int year, string status) //Lägger till ny bok med titel, författare, genre, år och lässtatus.
        {
            Book book = new Book(); //Ny instans av book enligt Book.cs.
            book.Title = title;
            book.Author = author;
            book.Genre = genre;
            book.Year = year;
            book.Status = status; //Angiven input i Program.cs får strukturen från Book.cs.

            books.Add(book); //Lägger till i slutet på listan.
            storage.Save(books); //Sparar och uppdaterar.
        }

        public void putBook(int index, string title, string author, string genre, int year, string status)
        {
            books[index].Title = title;
            books[index].Author = author;
            books[index].Genre = genre;
            books[index].Year = year;
            books[index].Status = status;
            storage.Save(books);
        } // Liknande upplägg som addBook, men istället för att skapa en ny instans så justeras varje property med hjälp av angivet index från listan.

        public void delBook(int index) //Raderar bok med angivet index.
        {
            books.RemoveAt(index);
            storage.Save(books);
        }

        public void putStatusBook(int index, string status)
        {
            books[index].Status = status;
            storage.Save(books);
        } //Fungerar som putBook men justerar endast lässtatus och inte alla properties.

        public void filterBook(string input)
        {
                List<Book> result = books.Where(book => book.Title.Contains(input, StringComparison.OrdinalIgnoreCase) ||
            book.Author.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
                foreach (Book book in result)
                {
                    {
                        Console.WriteLine($"{book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n Lässtatus: {book.Status}\n");
                    }
                }
        } //En ny lista skapas baserat på angiven input, där books kontrolleras baserat på titel och författare, samt ignorerar upper eller lower case-skillnander.
        //Denna lista loopas igenom och skrivs ut, alltså resultat av sökningen.

        public List<Book> GetBooks()
        {
            return books; //Returnerar lagrade böcker.
        }
    }
}
