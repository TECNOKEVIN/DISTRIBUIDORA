using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Distribuidora.Shared.Entities
{
    public class TipoLicor
    {
        public int Id { get; set; }

        [Display(Name = "Tipo Licor")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int SedeId { get; set; }
        public Sede? Sede { get; set; }

        public ICollection<Licor>? Licors { get; set; }

        [Display(Name = "Licores")]
        public int LicorsNumber => Licors == null ? 0 : Licors.Count;


    }
}
