using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;

namespace Domain.Master
{
    public class ExceptionConfig
    {
        #region Methods
        public string Error(Exception ex, string _strMessage)
        {
            string strMessage = _strMessage;

            try
            {
                throw ex;
            }
            catch (ArgumentNullException)
            {
                strMessage += ", Null values";
            }
            catch (DirectoryNotFoundException)
            {
                strMessage += ", The directory is not valid";
            }
            catch (FormatException)
            {
                strMessage += ", The format is not valid";
            }
            catch (TimeoutException)
            {
                strMessage += ", The operation timed out";
            }
            catch (AuthenticationException)
            {
                strMessage += ", Authentication is required";
            }
            catch (ValidationException)
            {
                strMessage += ", Validation error";
            }
            catch (InvalidOperationException)
            {
                strMessage += ", Invalid operation";
            }

            strMessage += ", Error details: " + ex.Message;

            return strMessage;

        } 
        #endregion
    }
}
