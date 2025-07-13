namespace Domain.Model
{
    public class EnrollmentModel
    {
        #region Properties
        public int IdEnrollment { get; set; }
        public string Document { get; set; }
        public int Code { get; set; }
        public SubjectModel Subject { get; set; }
        public EnrollmentModel()
        {
            IdEnrollment = 0;
            Document = string.Empty;
            Code = 0;
        }
    } 
    #endregion
}
