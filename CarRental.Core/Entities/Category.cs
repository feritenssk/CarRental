using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Core.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display (Name = "Kategori Adı")]
        [MaxLength (50)]
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
