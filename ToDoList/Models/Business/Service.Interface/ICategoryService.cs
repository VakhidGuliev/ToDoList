using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.Business.Entites;

namespace ToDoList.Models.Business.Service.Interface
{
    public interface ICategoryService
    {
        bool CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        void DeleteCategory(int? id);
        IEnumerable<Category> Categories();
    }
}
