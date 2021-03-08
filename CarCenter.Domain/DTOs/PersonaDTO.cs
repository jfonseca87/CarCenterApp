namespace CarCenter.Domain.DTOs
{
    public class PersonaDTO
    {
        public int PersonaId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Celular { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
