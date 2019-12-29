using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Models.Business.Entites;
using ToDoList.Models.Business.Service.Interface;
using ToDoList.Models.DataAccess.Dal.Service.Interface;
using ToDoList.Models.Helpers;
using Task = System.Threading.Tasks.Task;

namespace ToDoList.Models.Business.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IDataCategoryService _dataCategoryService;

        public CategoryService(IDataCategoryService dataCategoryService)
        {
            _dataCategoryService = dataCategoryService;
        }

        public bool CreateCategory(Category category)
        {
            var convert = CommonConverter.FromBlToDal(category);
            return _dataCategoryService.CreateCategory(convert);
        }

        public List<Category> Categories() =>
            _dataCategoryService.Categories().Select(CommonConverter.FromDalToBl).ToList();
          
          public async void DeleteCategory(int? id)
        {
           await Task.Run(()=>_dataCategoryService.DeleteCategory(id));
        }

 
       
        Category ICategoryService.UpdateCategory(Category category, int userAccountId)
        {
            DataAccess.Dal.Entites.Category convert = CommonConverter.FromBlToDal(category);
            return CommonConverter.FromDalToBl(_dataCategoryService.UpdateCategory(convert));
        }




       
    }
}
