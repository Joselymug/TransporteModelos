using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaModelos
{
    public class Log
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime Fecha { get; set; }

        public int SensorId { get; set; }

        public Sensor? Sensor { get; set; }
    }
}
