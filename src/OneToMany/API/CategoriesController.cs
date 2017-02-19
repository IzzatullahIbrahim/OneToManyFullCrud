using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneToMany.Data;
using OneToMany.Models;
using OneToMany.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OneToMany.API
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ICategoryService _catService;
        public CategoriesController(ICategoryService catService)
        {
            _catService = catService;
        }

        [HttpGet]
        public List<Category>  Get()
        {
            List<Category> categories = _catService.GetCategories();
            return categories;
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            Category cat = _catService.GetCategory(id);
            return cat;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Category cat)
        {
            if (cat == null)
            {
                return BadRequest();
            }
            else if (cat.Id == 0)
            {
                _catService.AddCategory(cat);
                return Ok();
            }
            else
            {
                _catService.UpdateCategory(cat);
                return Ok();
            }
        }

        
    }
}
