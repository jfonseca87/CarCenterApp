namespace CarCenter.Domain.DTOs
{
    public class CarroDTO
    {
        public int CarroId { get; set; }
        public string Marca { get; set; }
        public int? Modelo { get; set; }
        public string Placa { get; set; }
        public string Observaciones { get; set; }
    }
}
