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

        public bool CreateCategory(Category category) =>
         _dataCategoryService.CreateCategory(UserConverter.FromDalToBl(category));

        public IEnumerable<Category> Categories() {
            List<DataAccess.Dal.Entites.Category> a = _dataCategoryService.Categories().ToList();
            List<Category> res = _dataCategoryService.Categories().Select(UserConverter.FromBlToDal).ToList();
            return res;
                }

        public Category UpdateCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        //public Category UpdateCategory(Category category)
        //{
        //    var dalCategory = UserConverter.FromDalToBl(category);
        //    var dalMethod = _dataCategoryService.UpdateCategory(dalCategory);
        //    var dalCategoryRes = UserConverter.FromBlToDal(dalMethod);
        //    return dalCategoryRes;
        //}
    }
}
