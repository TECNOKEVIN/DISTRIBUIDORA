using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.Shared.Entities
{
    public class Sede
    {

        public int Id { get; set; }

        [Display(Name = "Sede")]
        [MaxLength(100, ErrorMessage ="Cuidado el campo {0} no permite mas de {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Name { get; set; } = null;

    }
}
