using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteModelos
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }

        [ForeignKey ("Taller")] public int TallerId { get; set; }
        [ForeignKey("Camion")] public int CamionId { get; set; }

        public Camion? Camion { get; set; }
        public Taller? Taller { get; set; }
    }
}
