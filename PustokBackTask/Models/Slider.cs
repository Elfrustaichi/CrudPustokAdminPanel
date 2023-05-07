using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokBackTask.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string HeaderThenbr { get; set; }
        [Required]
        public string Desc { get; set; }
        [Column(TypeName = "money")]
        public decimal  Price { get; set; }

        public string SliderImage { get; set; } 
    }
}
