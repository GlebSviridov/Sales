﻿using System.Collections.Generic;
using Sales.DataLayer.Dto;

namespace Sales.DataLayer.Interfaces
{
    public interface IBookRepository
    {
        BookDto Get(int bookId);
        List<BookDto> GetList();
        List<BookDto> GetList(List<int> bookIds);
        void UpdateCopiesNumber(int bookId, int changeValue);
    }
}