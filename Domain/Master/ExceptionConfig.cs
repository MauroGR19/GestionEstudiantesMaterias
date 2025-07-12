using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Master
{
    public class ExceptionConfig
    {
        public Exception Error(Exception ex, string _strMessage)
        {
            string strMessage = _strMessage;

            try
            {
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

            throw new Exception(strMessage);

        }
    }
}
