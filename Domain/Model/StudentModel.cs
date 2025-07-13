namespace Domain.Model
{
    public class StudentModel
    {
        #region Properties
        public string Document { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public StudentModel()
        {
            Document = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
        } 
        #endregion
    }
}
