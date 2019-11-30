namespace ToDoList.Models.Business.Service.Implementation.Converters
{
    using System;
    using AuthUser = ToDoList.Models.Business.Entites.AuthUser;

    public class UserConverter
    {
        public static Entites.User FromDalToBl(DataAccess.Dal.Entites.User user, DateTime today) =>
           new Entites.User
           {

               Email = user.Email,
               Name = user.FirstName + " " + user.LastName,
               BirthDate = new DateTime(today.Year, user.DateOfBirth.Month, user.DateOfBirth.Day),
               Age = today.Year - user.DateOfBirth.Year
           };

        public static AuthUser FromDalToBl(DataAccess.Dal.Entites.AuthUser authUser, DateTime today) =>
          new AuthUser
          {
              Email = authUser.Email,
              FirstName = authUser.FirstName,
              LastName = authUser.LastName,
              BirthDate = new DateTime(today.Year, authUser.DateOfBirth.Month, authUser.DateOfBirth.Day),
              Age = today.Year - authUser.DateOfBirth.Year,
              Password = authUser.Password,
              ConfirmPassword = authUser.ConfirmPassword,
          };

        public static DataAccess.Dal.Entites.AuthUser FromBlToDl(AuthUser authUser, DateTime today) =>
       new DataAccess.Dal.Entites.AuthUser
       {
           Email = authUser.Email,
           FirstName = authUser.FirstName,
           LastName = authUser.LastName,
           DateOfBirth = new DateTime(today.Year, authUser.BirthDate.Month, authUser.BirthDate.Day),
           Age = today.Year - authUser.BirthDate.Year,
           Password = authUser.Password,
           ConfirmPassword = authUser.ConfirmPassword,
       };
    }
}
