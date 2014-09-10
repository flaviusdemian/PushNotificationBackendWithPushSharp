using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestPushNotifications.Models
{
    public class PushNotification
    {
        [Key]
        public String SenderId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public String Picture { get; set; }

    }
}