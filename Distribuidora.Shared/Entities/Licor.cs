using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Distribuidora.Shared.Entities
{
    public class Licor
    {
        public int Id { get; set; }

        [Display(Name = "Licores")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int TipoLicorId { get; set; }
        public TipoLicor? TipoLicor { get; set; }

    }
}
