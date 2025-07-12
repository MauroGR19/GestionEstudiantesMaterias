using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Master
{
    public static class BaseMessage
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }

        public enum SuccessStatus
        {
            [Description("Inserted successfully")]
            Inserted,
            [Description("Updated successfully")]
            Updated,
            [Description("Deleted successfully")]
            Deleted
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
        public enum ErrorStatusFront
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
            [Description("Comment cannot be empty for a high-priority task.")]
            ValidateComment,
            [Description("A task with that code and start date already exists.")]
            ValidateTask,
            [Description("End date cannot be more than 15 days after the start date.")]
            ValidateDate15,
            [Description("End date cannot be more than 2 days after the start date.")]
            ValidateDate2,
            [Description("Start date cannot be earlier than the current date.")]
            ValidateStartDate,
            [Description("Tasks with status Finished or In Progress cannot be deleted.")]
            ValidateDeleteStatus,
            [Description("Can only be deleted when the status is New.")]
            ValidatePriorityStatus,
            [Description("Tasks that have exceeded the execution time limit (End Date) cannot be deleted.")]
            ValidateDeadlineExceeded,
            [Description("A task with status Finished cannot be edited.")]
            ValidateFinalStatus,
            [Description("A task with priority High and status In Progress cannot be edited.")]
            ValidateInProgressStatus,
            [Description("End date cannot be earlier than the start date.")]
            ValidateStartEndDate,
            [Description("End date is earlier than the current date, only status can be changed to Cancelled.")]
            ValidateEndDateForCancel,
            [Description("Assigned person cannot be updated when status is not New.")]
            ValidateAssignedPersonStatus,
        }
    }
}
