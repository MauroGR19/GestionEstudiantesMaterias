namespace GestionEstudiantesMaterias.Models
{
    public class EnrollmentDto
    {
        public int IdEnrollment { get; set; }
        public string Document { get; set; }
        public int Code { get; set; }
        public SubjectDto Subject { get; set; }
        public EnrollmentDto()
        {
            IdEnrollment = 0;
            Document = string.Empty;
            Code = 0;
        }
    }
}
