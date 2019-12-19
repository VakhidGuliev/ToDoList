using System.Collections.Generic;
using ToDoList.Models.DataAccess.Dal.Entites;

namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    public interface IDataCategoryService
    {
       bool CreateCategory(Category category);
       Category UpdateCategory(Category category);
       IEnumerable<Category> Categories();
    }
  
}