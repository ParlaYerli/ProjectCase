using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.Context
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new AppDbContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(Users);
                    context.SaveChanges();
                }
                if (context.Items.Count() == 0)
                {
                    context.Items.AddRange(Items);
                    context.SaveChanges();
                }
            }
        }
        private static User[] Users = {
            new User(){ Username="parla",  Role="user", Password="parla"},
            new User(){ Username="hazal", Role="user", Password="parla"},
            };

        private static Item[] Items = {
            new Item { Code = "0001", Name = "Notebook", Price = 6300},
            new Item { Code = "0002", Name = "Keyboard", Price = 230},
            new Item { Code = "0003", Name = "Mouse",  Price = 150},
        };
    }
}
