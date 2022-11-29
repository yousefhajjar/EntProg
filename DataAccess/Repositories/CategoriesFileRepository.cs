using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CategoriesFileRepository : ICategoriesRepository
    {
        private FileInfo fi;

        public CategoriesFileRepository(FileInfo _fi)
        {
            fi = _fi;
        }
        public IQueryable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            string line = "";
            using (StreamReader sr = fi.OpenText())
            {
                while(sr.Peek() != -1)
                {
                    line = sr.ReadLine();
                    categories.Add(new Category()
                    {
                        Id = Convert.ToInt32(line.Split(';')[0]),
                        Title = (line.Split(';')[1]).ToString()
                    });
                }
            }
            return categories.AsQueryable();
        }
    }
}
