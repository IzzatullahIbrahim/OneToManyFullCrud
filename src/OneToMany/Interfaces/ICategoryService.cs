using System.Collections.Generic;
using OneToMany.Models;

namespace OneToMany.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(Category cat);
        void DeleteCategory(Category cat);
        List<Category> GetCategories();
        Category GetCategory(int id);
        Category GetCategoryNoMovies(int id);
        void UpdateCategory(Category cat);
    }
}