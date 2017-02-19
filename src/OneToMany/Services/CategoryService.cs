using Microsoft.AspNetCore.Mvc;
using OneToMany.Interfaces;
using OneToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneToMany.Services
{
    public class CategoryService: ICategoryService
    {
        private IGenericRepository _repo;
        public CategoryService(IGenericRepository repo)
        {
            _repo = repo;
        }
       
        public List<Category> GetCategories()
        {
            List<Category> catList = (from c in _repo.Query<Category>()
                                      select new Category
                                      {
                                          Id = c.Id,
                                          Name = c.Name,
                                          Movies = c.Movies
                                      }).ToList();
            return catList;
        }
        
        public Category GetCategory(int id)
        {
            Category cat = (from c in _repo.Query<Category>()
                            where c.Id == id
                            select new Category
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Movies = c.Movies
                            }).FirstOrDefault();
            return cat;
        }

        public  void AddCategory(Category cat)
        {
            _repo.Add(cat);
        }
        
        public void UpdateCategory(Category cat)
        {
            _repo.Update(cat);
        }

        public void DeleteCategory(Category cat)
        {
            _repo.Delete(cat);
        }

        public Category GetCategoryNoMovies(int id)
        {
            Category catQuery = (from c in _repo.Query<Category>()
                                 where c.Id == id
                                 select c).FirstOrDefault();
            return catQuery;
        }

    }
}
