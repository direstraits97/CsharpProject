using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpProject
{
    public interface IBookRegisterStorage
    {
        List<Book> Load();

        void Save(List<Book> books);
    }
}


