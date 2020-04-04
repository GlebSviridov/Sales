﻿using System.Collections.Generic;
using Sales.BusinessLayer.Models;

namespace Sales.BusinessLayer.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
    }
}