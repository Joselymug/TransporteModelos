using System;
using TransporteModelos;

namespace SistemaModelos
{
    public class Sensor
    {
        public int Id { get; set; }
        public int CamionId { get; set; }
        public string TipoSensor { get; set; }
        public double Valor { get; set; }
        public DateTime Timestamp { get; set; }

        public Camion? Camion { get; set; }

    }
}
