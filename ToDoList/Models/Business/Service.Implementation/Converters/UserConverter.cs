namespace ToDoList.Models.Business.Service.Implementation.Converters
{
    using System;
    using RegistrationUser = ToDoList.Models.Business.Entites.RegistrationUser;

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

        public static RegistrationUser FromDalToBl(DataAccess.Dal.Entites.RegistrationUser authUser, DateTime today) =>
          new RegistrationUser
          {
              Email = authUser.Email,
              FirstName = authUser.FirstName,
              LastName = authUser.LastName,
              BirthDate = new DateTime(today.Year, authUser.DateOfBirth.Month, authUser.DateOfBirth.Day),
              Age = today.Year - authUser.DateOfBirth.Year,
              Password = authUser.Password,
              ConfirmPassword = authUser.ConfirmPassword,
          };

        public static DataAccess.Dal.Entites.RegistrationUser FromBlToDl(RegistrationUser authUser, DateTime today) =>
       new DataAccess.Dal.Entites.RegistrationUser
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
