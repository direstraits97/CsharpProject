using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices.Marshalling;
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
                switch (input)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                        Console.WriteLine("Lägg till ny bok\n");
                        bool error = false;
                        string? title = null;
                        string? author = null;
                        string? genre = null;
                        string? year = null;
                        while (String.IsNullOrEmpty(title))
                        {
                            if(error)
                            {
                                Console.Clear();
                                Console.WriteLine("\x1b[3J");
                                Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                                Console.WriteLine("Ange bokens titel!\n");
                            }
                            Console.WriteLine("Titel:");
                            title = Console.ReadLine();
                            if(String.IsNullOrEmpty(title))
                            {
                                error = true;
                            }
                        }
                        error = false;
                        while (String.IsNullOrEmpty(author))
                        {
                            if(error)
                            {
                                Console.Clear();
                                Console.WriteLine("\x1b[3J");
                                Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                                Console.WriteLine("Ange bokens författare!\n");
                            }
                            Console.WriteLine("Författare:");
                            author = Console.ReadLine();
                            if (String.IsNullOrEmpty(author))
                            {
                                error = true;
                            }
                        }
                        error = false;
                        while (String.IsNullOrEmpty(genre))
                        {
                            if(error)
                            {
                                Console.Clear();
                                Console.WriteLine("\x1b[3J");
                                Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                                Console.WriteLine("Ange bokens genre!\n");
                            }
                            Console.WriteLine("Genre:");
                            genre = Console.ReadLine();
                            if (String.IsNullOrEmpty(genre))
                            {
                                error = true;
                            }
                        }
                        error = false;
                        while(String.IsNullOrEmpty(year))
                        {
                            if(error)
                            {
                                Console.Clear();
                                Console.WriteLine("\x1b[3J");
                                Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                                Console.WriteLine("Ange bokens utgivningsår!\n");
                            }
                            Console.WriteLine("År:");
                            year = Console.ReadLine();
                            if (String.IsNullOrEmpty(year))
                            {
                                error = true;
                            }
                        }
                        
                        Console.WriteLine("Lässtatus:");
                        Console.WriteLine("1. Oläst");
                        Console.WriteLine("2. Pågående");
                        Console.WriteLine("3. Utläst");
                        bool run = true;
                        error = false;
                        while(run)
                        {
                            int bookStatusInput = (int)Console.ReadKey(true).Key;
                            switch (bookStatusInput)
                            {
                                case '1':
                                    string status1 = "Oläst";
                                    bookregister.addBook(title, author, genre, year, status1);
                                    run = false;
                                    break;
                                case '2':
                                    string status2 = "Pågående";
                                    bookregister.addBook(title, author, genre, year, status2);
                                    run = false;
                                    break;
                                case '3':
                                    string status3 = "Utläst";
                                    bookregister.addBook(title, author, genre, year, status3);
                                    run = false;
                                    break;
                                default:
                                    if(!error)
                                    {
                                        Console.WriteLine("Du kan endast ange 1,2 eller 3!");
                                        error = true;
                                    } 
                                    break;
                            }
                        }
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                        Console.WriteLine("Mina böcker\n");
                        i = 0;
                        foreach (Book book in bookregister.GetBooks())
                        {
                            Console.WriteLine($"[{i++}] {book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n Lässtatus: {book.Status}\n");
                        }
                        Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn.");
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                        string? searchInput = null;
                        error = false;
                        while(String.IsNullOrEmpty(searchInput))
                        {
                            if(error)
                            {
                                Console.Clear();
                                Console.WriteLine("\x1b[3J");
                                Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                                Console.WriteLine("Du måste ange minst ett tecken för att söka!");
                            }
                            Console.WriteLine("Sök efter titel eller författare:");
                            searchInput = Console.ReadLine();
                            if(String.IsNullOrEmpty(searchInput))
                            {
                                error = true;
                            }
                        }
                        bookregister.filterBook(searchInput);
                        Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn.");
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
                            Console.WriteLine($"[{i++}] {book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n Lässtatus: {book.Status}\n");
                        }

                        Console.WriteLine("Ange index för boken som ska ändras:");
                        string? changeInput = Console.ReadLine();
                        string? newTitle = null;
                        string? newAuthor = null;
                        string? newGenre = null;
                        string? newYear = null;
                        error = false;
                        while (String.IsNullOrEmpty(newTitle))
                        {
                            if (error)
                            {
                                Console.Clear();
                                Console.WriteLine("\x1b[3J");
                                Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                                Console.WriteLine("Ange bokens titel!\n");
                            }
                            Console.WriteLine("Titel:");
                            newTitle = Console.ReadLine();
                            if (String.IsNullOrEmpty(newTitle))
                            {
                                error = true;
                            }
                        }
                        error = false;
                        while (String.IsNullOrEmpty(newAuthor))
                        {
                            if (error)
                            {
                                Console.Clear();
                                Console.WriteLine("\x1b[3J");
                                Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                                Console.WriteLine("Ange bokens författare!\n");
                            }
                            Console.WriteLine("Författare:");
                            newAuthor = Console.ReadLine();
                            if (String.IsNullOrEmpty(newAuthor))
                            {
                                error = true;
                            }
                        }
                        error = false;
                        while (String.IsNullOrEmpty(newGenre))
                        {
                            if (error)
                            {
                                Console.Clear();
                                Console.WriteLine("\x1b[3J");
                                Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                                Console.WriteLine("Ange bokens genre!\n");
                            }
                            Console.WriteLine("Genre:");
                            newGenre = Console.ReadLine();
                            if (String.IsNullOrEmpty(newGenre))
                            {
                                error = true;
                            }
                        }
                        error = false;
                        while (String.IsNullOrEmpty(newYear))
                        {
                            if (error)
                            {
                                Console.Clear();
                                Console.WriteLine("\x1b[3J");
                                Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
                                Console.WriteLine("Ange bokens utgivningsår!\n");
                            }
                            Console.WriteLine("År:");
                            newYear = Console.ReadLine();
                            if (String.IsNullOrEmpty(newYear))
                            {
                                error = true;
                            }
                        }
                        Console.WriteLine("Lässtatus:");
                        Console.WriteLine("1. Oläst");
                        Console.WriteLine("2. Pågående");
                        Console.WriteLine("3. Utläst");
                        run = true;
                        error = false;
                        while(run)
                        {
                            int putBookStatusInput = (int)Console.ReadKey(true).Key;
                            switch (putBookStatusInput)
                            {
                                case '1':
                                    string status1 = "Oläst";
                                    bookregister.putBook(Convert.ToInt32(changeInput), newTitle, newAuthor, newGenre, newYear, status1);
                                    run = false;
                                    break; 
                                case '2':
                                    string status2 = "Pågående";
                                    bookregister.putBook(Convert.ToInt32(changeInput), newTitle, newAuthor, newGenre, newYear, status2);
                                    run = false;
                                    break;
                                case '3':
                                    string status3 = "Utläst";
                                    bookregister.putBook(Convert.ToInt32(changeInput), newTitle, newAuthor, newGenre, newYear, status3);
                                    run = false;
                                    break;
                                default:
                                    if (!error)
                                    {
                                        Console.WriteLine("Du kan endast ange 1,2 eller 3!");
                                        error = true;
                                    }
                                    break;
                            }
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
                            
                            Console.WriteLine($"[{i++}] {book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n Lässtatus: {book.Status}\n");
                        }

                        Console.WriteLine("Ange index att radera:");
                        string? index = Console.ReadLine();
                        if (!String.IsNullOrEmpty(index))
                            try
                            {
                                bookregister.delBook(Convert.ToInt32(index));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Angivet index är ogiltigt!\nTryck på valfri tangent för att fortsätta.");
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
                            Console.WriteLine($"[{i++}] {book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n Lässtatus: {book.Status}\n");
                        }

                        Console.WriteLine("Ange index för att ändra lässtatus:");
                        string? statusInput = Console.ReadLine();
                        Console.WriteLine("Lässtatus:");
                        Console.WriteLine("1. Oläst");
                        Console.WriteLine("2. Pågående");
                        Console.WriteLine("3. Utläst");
                        int changeBookStatusInput = (int)Console.ReadKey(true).Key;
                        switch (changeBookStatusInput)
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
            static void ChangeColorOfWord(ConsoleColor color, string word)
            {
                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.Write(word);
                Console.ForegroundColor = defaultColor;
            
            }

        }
    }
}
