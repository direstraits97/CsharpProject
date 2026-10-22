using System;
using System.Linq;
namespace CsharpProject
{

    class Program
    {
        static void Main(string[] args)
        {
            IBookRegisterStorage storage = new JsonBookRegisterStorage("bookregister.json");
            BookRegister bookregister = new BookRegister(storage);

            int i = 0;

            while(true)
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                Console.WriteLine("1. Lägg till ny bok");
                Console.WriteLine("2. Visa alla böcker");
                Console.WriteLine("3. Sök efter bok");
                Console.WriteLine("4. Ändra en bok");
                Console.WriteLine("5. Ta bort en bok");
                Console.WriteLine("6. Justera lässtatus\n");
                Console.WriteLine("X. Avsluta\n");

                int input = (int)Console.ReadKey(true).Key;
                switch(input)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                        Console.WriteLine("Lägg till ny bok\n");
                        Console.WriteLine("Titel:");
                        string? title = Console.ReadLine();
                        Console.WriteLine("Författare:");
                        string? author = Console.ReadLine();
                        Console.WriteLine("Genre:");
                        string? genre = Console.ReadLine();
                        Console.WriteLine("År:");
                        string? year = Console.ReadLine();
                        Console.WriteLine("Status:");
                        Console.WriteLine("1. Oläst");
                        Console.WriteLine("2. Pågående");
                        Console.WriteLine("3. Utläst");
                        int bookStatusInput = (int)Console.ReadKey(true).Key;
                        switch(bookStatusInput)
                        {
                            case '1':
                                string status1 = "Oläst";
                                bookregister.addBook(title, author, genre, Convert.ToInt32(year), status1);
                                break;
                            case '2':
                                string status2 = "Pågående";
                                bookregister.addBook(title, author, genre, Convert.ToInt32(year), status2);
                                break;
                            case '3':
                                string status3 = "Utläst";
                                bookregister.addBook(title, author, genre, Convert.ToInt32(year), status3);
                                break;
                        }
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                        Console.WriteLine("Mina böcker\n");
                        i = 0;
                        foreach(Book book in bookregister.GetBooks())
                        {
                            Console.WriteLine($"[{i++}] {book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n Status: {book.Status}\n");
                        }
                        Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn...");
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                        Console.WriteLine("Sök efter titel eller författare:");
                        string searchInput = Console.ReadLine();
                        List<Book> result = bookregister.GetBooks().Where(book => book.Title.Contains(searchInput, StringComparison.OrdinalIgnoreCase) || 
                        book.Author.Contains(searchInput, StringComparison.OrdinalIgnoreCase)).ToList();
                        foreach(Book book in result)
                        {
                            Console.WriteLine($"{book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n");
                        }
                        Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn...");
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                        Console.WriteLine("Ändra bok\n");
                        i = 0;
                        foreach (Book book in bookregister.GetBooks())
                        {
                            Console.WriteLine($"[{i++}] {book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n Status: {book.Status}\n");
                        }
                        
                        Console.WriteLine("Ange index för boken som ska ändras:");
                        string changeInput = Console.ReadLine();
                        Console.WriteLine("Titel:");
                        string newTitle = Console.ReadLine();
                        Console.WriteLine("Författare:");
                        string newAuthor = Console.ReadLine();
                        Console.WriteLine("Genre:");
                        string newGenre = Console.ReadLine();
                        Console.WriteLine("År:");
                        string newYear = Console.ReadLine();
                        Console.WriteLine("Status:");
                        Console.WriteLine("1. Oläst");
                        Console.WriteLine("2. Pågående");
                        Console.WriteLine("3. Utläst");
                        int putBookStatusInput = (int)Console.ReadKey(true).Key;
                        switch (putBookStatusInput)
                        {
                            case '1':
                                string status1 = "Oläst";
                                bookregister.putBook(Convert.ToInt32(changeInput), newTitle, newAuthor, newGenre, Convert.ToInt32(newYear), status1);
                                break;
                            case '2':
                                string status2 = "Pågående";
                                bookregister.putBook(Convert.ToInt32(changeInput), newTitle, newAuthor, newGenre, Convert.ToInt32(newYear), status2);
                                break;
                            case '3':
                                string status3 = "Utläst";
                                bookregister.putBook(Convert.ToInt32(changeInput), newTitle, newAuthor, newGenre, Convert.ToInt32(newYear), status3);
                                break;
                        }
                        break;
                    case '5':
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                        Console.WriteLine("Radera bok\n");

                        i = 0;
                        foreach (Book book in bookregister.GetBooks())
                        {
                            Console.WriteLine($"[{i++}] {book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n Status: {book.Status}\n");
                        }

                        Console.WriteLine("Ange index att radera:");
                        string index = Console.ReadLine();
                        if(!String.IsNullOrEmpty(index))
                            try
                            {
                                bookregister.delBook(Convert.ToInt32(index));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Angivet index är ogiltigt!\nTryck på valfri tangent för att fortsätta...");
                                Console.ReadKey();
                            }
                        break;
                    case '6':
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                        Console.WriteLine("Ändra lässtatus\n");

                        i = 0;
                        foreach (Book book in bookregister.GetBooks())
                        {
                            Console.WriteLine($"[{i++}] {book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n Status: {book.Status}\n");
                        }

                        Console.WriteLine("Ange index för att ändra lässtatus:");
                        string statusInput = Console.ReadLine();
                        Console.WriteLine("Status:");
                        Console.WriteLine("1. Oläst");
                        Console.WriteLine("2. Pågående");
                        Console.WriteLine("3. Utläst");
                        int changeBookStatusInput = (int)Console.ReadKey(true).Key;
                        switch(changeBookStatusInput)
                        {
                            case '1':
                                string newStatus1 = "Oläst";
                                bookregister.putStatusBook(Convert.ToInt32(statusInput), newStatus1);
                                break;
                            case '2':
                                string newStatus2 = "Pågående";
                                bookregister.putStatusBook(Convert.ToInt32(statusInput), newStatus2);
                                break;
                            case '3':
                                string newStatus3 = "Utläst";
                                bookregister.putStatusBook(Convert.ToInt32(statusInput), newStatus3);
                                break;
                        }

                        break;
                    case 88:
                        Environment.Exit(0);
                        break;

                }
            }

        }

    }
}
