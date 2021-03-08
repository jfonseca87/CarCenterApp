namespace CarCenter.Domain.DTOs
{
    public class ClienteDTO : PersonaDTO
    {
        public int ClienteId { get; set; }
        public string TipoCliente { get; set; }
    }
}
