using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BusinessLogic
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

        public string ErrorMessage()
        {
            string errorMessage = string.Join(".", Errors);
            return errorMessage;
        }

        public void AppendNotificationErrors(Notification notification)
        {
            this.Errors = this.Errors.Concat(notification.Errors).ToList();
        }
    }
}
