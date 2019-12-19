using System;
using ToDoList.Models.Business.Entites;

namespace ToDoList.Models.Business.Service.Implementation.Converters
{
    public class UserConverter
    {
        public static User FromBlToDal(DataAccess.Dal.Entites.User user, DateTime today) =>
           new User
           {
               Email = user.Email,
               FirstName = user.FirstName,
               LastName = user.LastName,
               BirthDate = new DateTime(today.Year, user.DateOfBirth.Month, user.DateOfBirth.Day),
               Age = today.Year - user.DateOfBirth.Year,
               Password = user.Password,
               ConfirmPassword = user.ConfirmPassword
           };

        public static DataAccess.Dal.Entites.User FromDalToBl(User user, DateTime today) =>
           new DataAccess.Dal.Entites.User
           {
               Email = user.Email,
               FirstName = user.FirstName,
               LastName = user.LastName,
               DateOfBirth = new DateTime(today.Year, user.BirthDate.Month, user.BirthDate.Day),
               Age = today.Year - user.BirthDate.Year,
               Password = user.Password,
               ConfirmPassword = user.ConfirmPassword
           };

        public static Category FromBlToDal(DataAccess.Dal.Entites.Category category) =>
        new Category
       {
            
           Name = category.Name
       };

        public static DataAccess.Dal.Entites.Category FromDalToBl(Category category) =>
           new DataAccess.Dal.Entites.Category
           {
               Name = category.Name
           };

        public static User.Role FromBlToDal(DataAccess.Dal.Entites.User.Role role) =>
        new User.Role();

        public static DataAccess.Dal.Entites.User.Role FromBlToDal(User.Role role) =>
         new DataAccess.Dal.Entites.User.Role();

        // Not using

        // #region Authentication
        // public static Entites.Authentication FromDalToBl(DataAccess.Dal.Entites.Authentication registrationUser)
        // {
        //    return new Entites.Authentication
        //    {
        //        Email = registrationUser.Email,
        //        Password = registrationUser.Password
        //    };

        // }
        // public static DataAccess.Dal.Entites.Authentication FromBlToDal(Entites.Authentication registrationUser)
        // {
        //    return new DataAccess.Dal.Entites.Authentication
        //    {
        //        Email = registrationUser.Email,
        //        Password = registrationUser.Password
        //    };

        // #endregion
    }
}
