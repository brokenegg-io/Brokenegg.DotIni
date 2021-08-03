using Brokenegg.DotIni.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brokenegg.DotIni.Validations
{
    public class Validator
    {
        public List<String> Notifications { get; set; }

        public Validator()
        {
            this.Notifications = new List<string>();
        }

        public string GetNotification() => String.Join(",", this.Notifications?.Select(p => p));
        public string[] GetNotifications() => this.Notifications?.ToArray();
        public bool IsValid() => this.Notifications.Any();

        public Validator IsNullOrEmpty(string value, string response)
        {
            if (String.IsNullOrEmpty(value)) this.Notifications.Add(response);
            return this;
        }

        public Validator ContainSpaces(string sectionName, string response)
        {
            if(sectionName?.Split(' ').Length > 1) this.Notifications.Add(response);
            return this;
        }

        public Validator OnlyContainCharacters(string sectionName, string response, bool allowAllCases)
        {
            if (!IniUtils.OnlyLetters(sectionName)) this.Notifications.Add(response);
            return this;
        }
    }
}
