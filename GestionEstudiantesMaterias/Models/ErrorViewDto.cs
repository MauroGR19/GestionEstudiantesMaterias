namespace GestionEstudiantesMaterias.Models
{
    public class ErrorViewDto
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
