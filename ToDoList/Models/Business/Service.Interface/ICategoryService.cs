﻿namespace ToDoList.Models.Business.Service.Interface
{
    using System.Threading.Tasks;
    using ToDoList.Models.Business.Entites;

    public interface ICategoryService
    {
      bool CreateCategory(Category category);
    }
}