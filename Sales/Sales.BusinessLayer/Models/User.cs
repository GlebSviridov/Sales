﻿using System;

namespace Sales.BusinessLayer.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public bool HasUsed { get; set; }
    }
}