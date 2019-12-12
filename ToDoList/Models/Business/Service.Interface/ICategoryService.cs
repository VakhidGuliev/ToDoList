namespace ToDoList.Models.Business.Service.Interface
{
    using ToDoList.Models.Business.Entites;

    public interface ICategoryService
    {
        bool CreateCategory(Category category);
    }
}
