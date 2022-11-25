using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Donation.Models
{
    public class AllocateGoods
    {
        public int Id { get; set; }
        public string Goods { get; set; }
        [Display(Name = "Resources Needed")]
        public string AllocatedTo { get; set; }
        public string Description { get; set; }
    }
}
