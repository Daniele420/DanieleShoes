﻿using DiplomenProektNo7.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomenProektNo7.Abstraction
{
    public interface IShoeService
    {
        bool Create(string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount);
        bool Update(int shoeId, string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount);
        List<Shoe> GetShoes();
        Shoe GetShoeById(int productId);
        bool RemoveById(int sportshoeId);
        List<Shoe> GetShoes(string searchStringCategoryName, string searchStringBrandName);
    }
}
