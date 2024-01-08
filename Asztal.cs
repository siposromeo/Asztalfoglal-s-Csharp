using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asztalfoglalas
{
    public class Asztal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Megnevezes { get; set; }

        [Required]
        public int Ferohely { get; set; }
    }
}
