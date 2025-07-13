using System.ComponentModel;

namespace Domain.Master
{
    public static class BaseMessage
    {
        #region Methods
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }

        public enum ErrorStatus
        {
            [Description("Could not insert, please verify the data or contact the IT department")]
            Insert,
            [Description("Could not update, please verify the data or contact the IT department")]
            Update,
            [Description("Could not delete, please verify the data or contact the IT department")]
            Delete,
            [Description("Could not retrieve, please verify the data or contact the IT department")]
            Retrieve
        }

        public enum AdditionalError
        {
            [Description("The same subject cannot be inserted. ")]
            ValidadeSubjectRepeated,
            [Description("A student cannot enroll in more than 3 subjects with more than 4 credits each.")]
            ValidateLimitCredits,
        } 
        #endregion
    }
}
