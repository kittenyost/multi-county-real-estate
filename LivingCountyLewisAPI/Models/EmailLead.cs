using System;
using System.ComponentModel.DataAnnotations;

namespace LivingCountyLewisAPI.Models
{
    public class EmailLead
    {
        [Key]
        public int Id { get; set; }  // ✅ Must be "Id" and of type int
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}