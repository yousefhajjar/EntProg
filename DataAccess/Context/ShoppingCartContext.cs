using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{

    //add-migration <name> ShoppingCartContext
    //update-database

    public class ShoppingCartContext : IdentityDbContext
    {

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
               : base(options)
        {

        }

        public DbSet<Item> Items { get; set; } // an abstraction of the tables therefore plural name
        public DbSet<Item> Categories { get; set; }

    }
}
