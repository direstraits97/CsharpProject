<<<<<<< Updated upstream
﻿
=======
﻿/*
 * Filnamn: IBookRegisterStorage.cs
 * Författare: Josefine Backlund
 * Datum: 2026-10-26
 * Kurs: Programmering i C#.NET
 * 
 * Beskrivning:
 * Interface som anger metoder för lagring av böcker.
 */

namespace CsharpProject
{
    public interface IBookRegisterStorage
    {
        List<Book> Load(); //Hämtar lagrade böcker.

        void Save(List<Book> books); //Sparar böcker.
    }
}


>>>>>>> Stashed changes
