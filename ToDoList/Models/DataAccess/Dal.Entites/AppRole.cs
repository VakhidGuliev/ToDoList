namespace ToDoList.Models.DataAccess.Dal.Entites
{
    using System.ComponentModel.DataAnnotations;

    public class AppRole
    {
           public int Id { get; set; }

           [EmailAddress]

           public string Email { get; set; }

           [Required]

           public string Name { get;set; }
    }
}
