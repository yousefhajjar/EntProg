using DataAccess.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ItemRepositories
    {

        private ShoppingCartContext context { get; set; }

        public ItemRepositories(ShoppingCartContext _context)
        {
            context = _context;
        }

        public IQueryable<Item> GetItems()
        { 
            return context.Items; 
        }

        public void AddItem(Item i)
        {
            context.Items.Add(i);
            context.SaveChanges();
        }

        public void DeleteItem(Item i)
        {
            context.Items.Remove(i);
            context.SaveChanges();
        }
    }
}
