using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteModelos
{
    public class Taller
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public int CapacidadMaxReparaciones { get; set; }

        public List<Mantenimiento>? Mantenimientos { get; set; }
    }
}
