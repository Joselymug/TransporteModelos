
namespace TransporteModelos
{
    public class Camion
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public string Placa { get; set; }
        public int KmActual { get; set; }
        public string Estado { get; set; }

        public List<Mantenimiento>? Mantenimientos { get; set; }
        public List<Conductor>? Conductor { get; set; }
        

    }
}
