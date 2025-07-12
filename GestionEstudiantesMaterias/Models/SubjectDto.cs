namespace GestionEstudiantesMaterias.Models
{
    public class SubjectDto
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public SubjectDto()
        {
            Code = 0;
            Name = string.Empty;
            Credits = 0;
        }
    }
}
