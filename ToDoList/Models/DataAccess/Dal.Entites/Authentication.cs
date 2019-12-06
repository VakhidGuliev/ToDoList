using System.ComponentModel.DataAnnotations;


namespace ToDoList.Models.DataAccess.Dal.Entites
{
    public class Authentication
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
