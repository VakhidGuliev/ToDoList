using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.DataAccess.Dal.Entites;

namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    public interface IDataCategoryService
    {
       bool CreateCategory(Category category);
       Task<Category> UpdateCategory(Category category);
       void DeleteCategory(int? id);
       IEnumerable<Category> Categories();
    }
  
}