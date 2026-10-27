/*
 * Filnamn: Program.cs
 * Författare: Josefine Backlund
 * Datum: 2026-10-26
 * Kurs: Programmering i C#.NET
 * 
 * Beskrivning:
 * Programmet skapar ett bokregister som kan lagra följande information om böcker: titel, författare, genre, utgivningsår och lässtatus.
 * Användaren kan lägga till en bok, se lagrade böcker, söka bland böcker efter titel och författare, ändra en bok, ta bort böcker samt justera lässtatus.
 */

using System;
namespace CsharpProject
{

    class Program
    {
        static void Main(string[] args)
        {
            IBookRegisterStorage storage = new JsonBookRegisterStorage("bookregister.json"); //Fil för lagring.
            BookRegister bookregister = new BookRegister(storage); //Skapar bokregister med filen ovan.

            int i = 0; //Index för lista med böcker

            while (true) //Programmet hålls igång tills det avslutas manuellt.
            {
                RecurrentTopMenu();
                Console.WriteLine("1. Lägg till ny bok");
                Console.WriteLine("2. Visa alla böcker");
                Console.WriteLine("3. Sök efter bok");
                Console.WriteLine("4. Ändra en bok");
                Console.WriteLine("5. Ta bort en bok");
                Console.WriteLine("6. Justera lässtatus\n");
                Console.WriteLine("X. Avsluta\n"); //Meny-alternativ.

                int menuInput = (int)Console.ReadKey(true).Key; //Avläsa val på tangentbord.
                switch (menuInput)
                {
                    case '1':
                        RecurrentTopMenu();
                        Console.WriteLine("Lägg till ny bok\n");

                        bool error = false; //Ändrar värde om input är tomt längre ner.

                        string? title = null;
                        string? author = null;
                        string? genre = null;
                        string? year = null;

                        while (String.IsNullOrEmpty(title)) //Loop som körs så länge input är tomt, och inputen kan ej få värde förrän den passerat felhantering.
                        {
                            if (error)
                            {
                                RecurrentTopMenu();
                                Console.WriteLine("Ange bokens titel!\n");
                            }
                            Console.WriteLine("Titel:");
                            title = Console.ReadLine();
                            if (String.IsNullOrEmpty(title))
                            {
                                error = true; //Om input är tomt blir error sant, och loopen börjar om och ger ett felmeddelande.
                            }
                        }
                        error = false;
                        while (String.IsNullOrEmpty(author))
                        {
                            if (error)
                            {
                                RecurrentTopMenu();
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
                            if (error)
                            {
                                RecurrentTopMenu();
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
                        bool validateNumberInput = true; //För att kontrollera rätt input av nummer.
                        while (validateNumberInput) //Detta är sant tills loopen slutar köra.
                        {
                            if (error)
                            {
                                RecurrentTopMenu();
                                Console.WriteLine("Du måste ange ett utgivningsår! Använd siffror.\n"); //Felmeddelande vid saknad input eller fel typ.
                            }
                            Console.WriteLine("År:");
                            year = Console.ReadLine();
                                if (String.IsNullOrEmpty(year))
                                {
                                    error = true;
                                    continue;
                                }
                                else if (!Int32.TryParse(year, out int number)) //Om false blir error sant, alltså om input ej är av typ number. Loop börjar om tills den passerar både if och if else.
                                {
                                    error = true;
                                    continue;
                                }
                                validateNumberInput = false; //Loop klar, validering lyckad.
                        }

                        Console.WriteLine("Lässtatus:");
                        Console.WriteLine("1. Oläst");
                        Console.WriteLine("2. Pågående");
                        Console.WriteLine("3. Utläst");

                        error = false;
                        bool run = true;

                        while (run) //Körs medan run är true, vid lyckade cases ändras run till false, och loopen bryts.
                        {
                            int bookStatusInput = (int)Console.ReadKey(true).Key; //Invänta input.
                            switch (bookStatusInput)
                            {
                                case '1':
                                    string status1 = "Oläst";
                                    bookregister.addBook(title, author, genre, Convert.ToInt32(year), status1);
                                    run = false;
                                    break;
                                case '2':
                                    string status2 = "Pågående";
                                    bookregister.addBook(title, author, genre, Convert.ToInt32(year), status2);
                                    run = false;
                                    break;
                                case '3':
                                    string status3 = "Utläst";
                                    bookregister.addBook(title, author, genre, Convert.ToInt32(year), status3);
                                    run = false;
                                    break;
                                default: //Om fel tangent försöker anges.
                                    if (!error) //Om error är false och inget meddelande skrivits ut så skrivs det ut en gång för användaren.
                                    {
                                        Console.WriteLine("Du kan endast ange 1,2 eller 3!");
                                        error = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    case '2':
                        RecurrentTopMenu();
                        Console.WriteLine("Mina böcker\n");

                        LoopBooks(bookregister, i); //Visar böcker.

                        Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn.");
                        Console.ReadKey(); //Tillbaka till menyn.
                        break;
                    case '3':
                        RecurrentTopMenu();
                        string? searchInput = null;
                        error = false;
                        while (String.IsNullOrEmpty(searchInput)) //Som tidigare while-loopar med felhantering kan användaren inte gå vidare förrän inputen har ett värde.
                        {
                            if (error)
                            {
                                RecurrentTopMenu();
                                Console.WriteLine("Du måste ange minst ett tecken för att söka!");
                            }
                            Console.WriteLine("Sök efter titel eller författare:");
                            searchInput = Console.ReadLine();
                            if (String.IsNullOrEmpty(searchInput))
                            {
                                error = true;
                            }
                        }
                        bookregister.filterBook(searchInput); //Lista med resultatet skrivs ut efter angedd input.
                        Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn.");
                        Console.ReadKey();
                        break;
                    case '4':
                        RecurrentTopMenu();
                        Console.WriteLine("Ändra bok\n");

                        LoopBooks(bookregister, i);

                        string? changeInput = null;
                        error = false;
                        validateNumberInput = true;
                        while (validateNumberInput)
                        {
                            RecurrentTopMenu();

                            LoopBooks(bookregister, i);

                            if (error)
                            {
                                Console.WriteLine("Du måste ange ett giltigt index från listan!");

                            }
                            Console.WriteLine("Ange index för boken som ska ändras:\n");

                            changeInput = Console.ReadLine();
                            if (String.IsNullOrEmpty(changeInput))
                            {
                                error = true; //Om input är tomt får error true och med continue körs loopen igen, och if(error) blir aktuellt högre upp.
                                continue;
                            }
                            else if (!Int32.TryParse(changeInput, out int number)) //Kontrollera om angivet index är ett nummer, tryparse är en bool, så om det inte går att parsa blir error sant och loopen körs igen.
                            {
                                error = true;
                                continue;
                            }
                            else if (Convert.ToInt32(changeInput) < 0 || Convert.ToInt32(changeInput) > (bookregister.GetBooks().Count - 1)) //Kontrollerar att endast existerande index i listan kan anges.
                            {
                                error = true;
                                continue;
                            }
                            validateNumberInput = false; //Om ingen if eller else if triggats under en loop slutar den köras då indexLoop blir false.
                        }
                        string? changeTitle = null;
                        string? changeAuthor = null;
                        string? changeGenre = null;
                        string? changeYear = null;
                        error = false;
                        while (String.IsNullOrEmpty(changeTitle)) //Samma felhantering som tidigare.
                        {
                            if (error)
                            {
                                RecurrentTopMenu();
                                Console.WriteLine("Ange bokens titel!\n");
                            }
                            Console.WriteLine("Titel:");
                            changeTitle = Console.ReadLine();
                            if (String.IsNullOrEmpty(changeTitle))
                            {
                                error = true;
                            }
                        }
                        error = false;
                        while (String.IsNullOrEmpty(changeAuthor))
                        {
                            if (error)
                            {
                                RecurrentTopMenu();
                                Console.WriteLine("Ange bokens författare!\n");
                            }
                            Console.WriteLine("Författare:");
                            changeAuthor = Console.ReadLine();
                            if (String.IsNullOrEmpty(changeAuthor))
                            {
                                error = true;
                            }
                        }
                        error = false;
                        while (String.IsNullOrEmpty(changeGenre))
                        {
                            if (error)
                            {
                                RecurrentTopMenu();
                                Console.WriteLine("Ange bokens genre!\n");
                            }
                            Console.WriteLine("Genre:");
                            changeGenre = Console.ReadLine();
                            if (String.IsNullOrEmpty(changeGenre))
                            {
                                error = true;
                            }
                        }
                        error = false;
                        validateNumberInput = true;
                        while (validateNumberInput)
                        {
                            if (error)
                            {
                                RecurrentTopMenu();
                                Console.WriteLine("Ange bokens utgivningsår! Använd siffror.\n");
                            }
                            Console.WriteLine("År:");
                            changeYear = Console.ReadLine();
                            if (String.IsNullOrEmpty(changeYear))
                            {
                                error = true;
                                continue;
                            }
                            else if (!Int32.TryParse(changeYear, out int number))
                            {
                                error = true;
                                continue;
                            }
                            validateNumberInput = false;
                        }
                        Console.WriteLine("Lässtatus:");
                        Console.WriteLine("1. Oläst");
                        Console.WriteLine("2. Pågående");
                        Console.WriteLine("3. Utläst");
                        run = true;
                        error = false;
                        while (run) //Samma felhantering som i Addbook högre upp.
                        {
                            int putBookStatusInput = (int)Console.ReadKey(true).Key;
                            switch (putBookStatusInput)
                            {
                                case '1':
                                    string status1 = "Oläst";
                                    bookregister.putBook(Convert.ToInt32(changeInput), changeTitle, changeAuthor, changeGenre, Convert.ToInt32(changeYear), status1);
                                    run = false;
                                    break;
                                case '2':
                                    string status2 = "Pågående";
                                    bookregister.putBook(Convert.ToInt32(changeInput), changeTitle, changeAuthor, changeGenre, Convert.ToInt32(changeYear), status2);
                                    run = false;
                                    break;
                                case '3':
                                    string status3 = "Utläst";
                                    bookregister.putBook(Convert.ToInt32(changeInput), changeTitle, changeAuthor, changeGenre, Convert.ToInt32(changeYear), status3);
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
                        RecurrentTopMenu();
                        Console.WriteLine("Radera bok\n");

                        LoopBooks(bookregister, i);

                        Console.WriteLine("Ange index att radera:");
                        string? deleteIndex = Console.ReadLine();
                        if (!String.IsNullOrEmpty(deleteIndex))
                            try
                            {
                                bookregister.delBook(Convert.ToInt32(deleteIndex));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Angivet index är ogiltigt!\nTryck på valfri tangent för att fortsätta.");
                                Console.ReadKey();
                            } //Om radering är möjlig körs koden, alltså om index är tillgänligt, annars visas ett felmeddelande.
                        break;
                    case '6':
                        RecurrentTopMenu();
                        Console.WriteLine("Ändra lässtatus\n");

                        LoopBooks(bookregister, i);

                        error = false;
                        validateNumberInput = true;
                        string? statusInput = null;
                        while (validateNumberInput) //Samma felhantering som tidigare.
                        {
                            RecurrentTopMenu();
                            LoopBooks(bookregister, i);
                            if (error)
                            {
                                Console.WriteLine("Du måste ange ett giltigt index från listan!");

                            }
                            Console.WriteLine("Ange index för att ändra lässtatus:\n");

                            statusInput = Console.ReadLine();
                            if (String.IsNullOrEmpty(statusInput))
                            {
                                error = true;
                                continue;
                            }
                            else if (!Int32.TryParse(statusInput, out int number))
                            {
                                error = true;
                                continue;
                            }
                            else if (Convert.ToInt32(statusInput) < 0 || Convert.ToInt32(statusInput) > (bookregister.GetBooks().Count - 1))
                            {
                                error = true;
                                continue;
                            }
                            validateNumberInput = false;
                        }
                        run = true;
                        error = false;
                        Console.WriteLine("Lässtatus:");
                        Console.WriteLine("1. Oläst");
                        Console.WriteLine("2. Pågående");
                        Console.WriteLine("3. Utläst");
                        while (run) //Liknande loop som tidigare men endast med justering av lässtatus.
                        {
                            int changeBookStatusInput = (int)Console.ReadKey(true).Key;
                            switch (changeBookStatusInput)
                            {
                                case '1':
                                    string newStatus1 = "Oläst";
                                    bookregister.putStatusBook(Convert.ToInt32(statusInput), newStatus1);
                                    run = false;
                                    break;
                                case '2':
                                    string newStatus2 = "Pågående";
                                    bookregister.putStatusBook(Convert.ToInt32(statusInput), newStatus2);
                                    run = false;
                                    break;
                                case '3':
                                    string newStatus3 = "Utläst";
                                    bookregister.putStatusBook(Convert.ToInt32(statusInput), newStatus3);
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
                    case 88: //X-tangenten.
                        Environment.Exit(0); //Programmet stängs på ett lyckat sätt.
                        break;

                }
            }
            //Nedan funktioner minskar redundans av kod en aning.
            static void RecurrentTopMenu()
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                Console.WriteLine("J O S E F I N E ' S  B O K R E G I S T E R\n\n");
            }
            static void LoopBooks(BookRegister bookregister, int i)
            {
                i = 0;
                foreach (Book book in bookregister.GetBooks())
                {
                    Console.WriteLine($"[{i++}] {book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n Lässtatus: {book.Status}\n");
                }
            }
        }
    }
}