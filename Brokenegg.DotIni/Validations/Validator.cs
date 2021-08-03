using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brokenegg.DotIni.Validations
{
    public class Validator
    {
        public List<String> Notifications { get; set; }

        public bool IsValid() => this.Notifications.Any();

        public Validator IsNullOrEmpty(string value, string response)
        {
            return this;
        }

        public string GetNotification() => String.Join(",", this.Notifications?.Select(p => p));
        public string[] GetNotifications() => this.Notifications?.ToArray();
    }
}
