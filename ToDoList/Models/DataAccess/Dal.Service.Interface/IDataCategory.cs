namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    using System.Threading.Tasks;
    using ToDoList.Models.DataAccess.Dal.Entites;
    public interface IDataCategoryService
    {
       Task<bool> CreateCategory(Category category);
    }
  
}