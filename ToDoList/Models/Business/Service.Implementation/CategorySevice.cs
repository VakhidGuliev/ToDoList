namespace ToDoList.Models.Business.Service.Implementation
{
    using System.Threading.Tasks;
    using ToDoList.Models.Business.Entites;
    using ToDoList.Models.Business.Service.Implementation.Converters;
    using ToDoList.Models.Business.Service.Interface;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;

    public class CategorySevice : ICategoryService
    {
        private readonly IDataCategoryService dataCategoryService;

        public CategorySevice(IDataCategoryService dataCategoryService)
        {
            this.dataCategoryService = dataCategoryService;
        }

        /// <inheritdoc/>
        public async Task<bool> CreateCategory(Category category) =>
         await Task.Run(() => this.dataCategoryService.CreateCategory(UserConverter.FromDalToBl(category)));
    }
}
