using System.Collections.Generic;
using ToDoList.Models.Business.Entites;

namespace ToDoList.Models.Business.Service.Interface
{
    public interface ICategoryService
    {
      bool CreateCategory(Category category);
      IEnumerable<Category> Categories();
    }
}
