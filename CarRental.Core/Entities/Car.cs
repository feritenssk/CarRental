using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Core.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display (Name="Araç Adı")]
        public string Name { get; set; }

        [Required]
        [Display (Name ="Açıklama")]
        public string Description { get; set; }

        [Required]
        [Display(Name="Günlük Ücret")]
        [Range(0,10000)]
        public double DailyRate { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }


    }
}
