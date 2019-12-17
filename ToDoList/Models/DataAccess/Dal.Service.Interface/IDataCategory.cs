namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    using ToDoList.Models.DataAccess.Dal.Entites;

    public interface IDataCategoryService
    {
       bool CreateCategory(Category category);
    }
  
}