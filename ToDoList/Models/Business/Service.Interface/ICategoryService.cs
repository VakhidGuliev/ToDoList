using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.Business.Entites;

namespace ToDoList.Models.Business.Service.Interface
{
    public interface ICategoryService
    {
        bool CreateCategory(Category category);
        Category UpdateCategory(Category category, int userAccountId);
        void DeleteCategory(int? id);
        int Count(int userAccountId);
        List<Category> Categories(int? userAccountId);
    }
}
