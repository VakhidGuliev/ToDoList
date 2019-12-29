namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ToDoList.Models.DataAccess.Dal.Entites;

    public interface IDataCategoryService
    {
      bool CreateCategory(Category category);

      Category UpdateCategory(Category category);

       void DeleteCategory(int? id);

       List<Category> Categories();
    }
  
}