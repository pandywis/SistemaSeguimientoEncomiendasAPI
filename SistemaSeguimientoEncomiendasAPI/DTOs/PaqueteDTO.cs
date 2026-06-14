namespace SistemaSeguimientoEncomiendasAPI.DTOS
{
    public class PaqueteDTO
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public DateTime FechaEnvio { get; set; }

        public int ClienteId { get; set; }
    }
}
