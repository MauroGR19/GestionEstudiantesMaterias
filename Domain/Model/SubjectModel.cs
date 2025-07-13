namespace Domain.Model
{
    public class SubjectModel
    {
        #region Properties
        public int Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public SubjectModel()
        {
            Code = 0;
            Name = string.Empty;
            Credits = 0;
        } 
        #endregion
    }
}
