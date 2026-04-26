using System.ComponentModel.DataAnnotations;

namespace LivingCountyLewisAPI.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }   // 👈 required primary key

        public string Username { get; set; }
        public string Password { get; set; }
    }
}