using System.Collections.Generic;
using System.Linq;
using ToDoList.Models.Business.Entites;
using ToDoList.Models.Business.Service.Implementation.Converters;
using ToDoList.Models.Business.Service.Interface;
using ToDoList.Models.DataAccess.Dal.Service.Interface;

namespace ToDoList.Models.Business.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IDataCategoryService _dataCategoryService;

        public CategoryService(IDataCategoryService dataCategoryService)
        {
            _dataCategoryService = dataCategoryService;
        }

        public  bool CreateCategory(Category category) =>
         _dataCategoryService.CreateCategory(UserConverter.FromDalToBl(category));

        public IEnumerable<Category> Categories() =>
            _dataCategoryService.Categories().Select(UserConverter.FromBlToDal).ToList();
        
  }
}
