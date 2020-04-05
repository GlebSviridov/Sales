using System;
using System.Diagnostics.SymbolStore;
using Sales.DataLayer.Repositories;

namespace Sales.DataLayer.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public bool HasUsed { get; set; }
    }
}