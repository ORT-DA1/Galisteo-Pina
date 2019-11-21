using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Entities
{
    public class Notification
    {
        public List<string> Errors { get; set; }
        public List<string> Success { get; set; }

        public Notification() {
            Errors = new List<string>();
            Success = new List<string>();
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
        public void AddSuccess(string success)
        {
            Success.Add(success);
        }
        public bool HasErrors()
        {
            return this.Errors.Count() > 0;
        }
        public bool HasSuccess()
        {
            return this.Success.Count() > 0;
        }
        public string Message()
        {
            return HasErrors() ? ErrorMessage() : SuccessMessage();
        }
        public string FormatMessages(List<string>notificationMessages)
        {
            return string.Join(".\n", notificationMessages);
        }
        public string ErrorMessage()
        {
            return FormatMessages(Errors);
        }
        public string SuccessMessage()
        {
            return FormatMessages(Success);
        }
        public void AppendNotificationMessages(Notification notification)
        {
                this.Errors = this.Errors.Concat(notification.Errors).ToList();
                this.Success = this.Success.Concat(notification.Success).ToList();
        }

    }
}
