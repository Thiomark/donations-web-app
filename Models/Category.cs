using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donations.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
