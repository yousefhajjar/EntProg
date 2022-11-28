using BusinessLogic.ViewModels;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ItemsServices
    {
        private ItemRepositories ir;

        public ItemsServices(ItemRepositories _itemRepositories) 
        {
            ir = _itemRepositories;
        
        }

        public void AddItem(CreateItemViewModel item)
        {
            if (ir.GetItems().Any(i => i.Name == item.Name))
                throw new Exception("Item with the same name already exists");
            else
            {
                ir.AddItem(new Domain.Models.Item()
                {
                    CategoryId = item.CategoryId,
                    Name = item.Name,
                    Description = item.Description,
                    PhotoPath = item.PhotoPath,
                    Price = item.Price,
                    Stock = item.Stock,
                });
            }

        }

        public void RemoveItem(int id) 
        {

        }

        public void Checkout()
        {
            
        }

        public IQueryable<ItemViewModel> GetItems() 
        {
            var list = from i in ir.GetItems()
                       select new ItemViewModel()
                       {
                           Category = i.Category.Title,
                           Name = i.Name,
                           Id = i.Id,
                           Description = i.Description,
                           PhotoPath = i.PhotoPath,
                           Price = i.Price,
                           Stock = i.Stock,
                       };
            return list;
        }

        public ItemViewModel GetItem(int id)
        {
            return GetItems().SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<ItemViewModel> Search(string keyword)
        {
            return GetItems().Where(x => x.Name.Contains(keyword));
        }

        public IQueryable<ItemViewModel> Search(string keyword, double minPrice, double maxPrice)
        {
            return Search(keyword).Where(x => x.Price >= minPrice && x.Price <= maxPrice);
        }

    }
}
