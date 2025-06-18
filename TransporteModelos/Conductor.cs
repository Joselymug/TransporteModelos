using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteModelos
{
    public class Conductor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Licencia { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public List<Mantenimiento>? Mantenimientos { get; set; }
        public List<Camion>? Camiones { get; set; }
    }
}
