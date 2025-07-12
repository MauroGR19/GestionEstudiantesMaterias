namespace GestionEstudiantesMaterias.Models
{
    public class StudentDto
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<EnrollmentDto> Enrollments { get; set; }   
        public StudentDto()
        {
            Document = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
            Enrollments = new List<EnrollmentDto>();   
        }
    }
}
