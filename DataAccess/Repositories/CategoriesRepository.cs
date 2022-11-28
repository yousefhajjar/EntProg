﻿using DataAccess.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private ShoppingCartContext context { get; set; }
        public CategoriesRepository(ShoppingCartContext _context) 
        {
            context = _context;
        }

        public IQueryable<Category> GetCategories() 
        {
            return (IQueryable<Category>)context.Categories;
        }
    }
}
