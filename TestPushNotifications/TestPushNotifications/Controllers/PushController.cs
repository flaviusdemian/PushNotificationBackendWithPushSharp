using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PushSharp;
using PushSharp.Android;
using PushSharp.Core;

namespace TestPushNotifications.Controllers
{
    public class PushController : ApiController
    {
        // GET: api/Push
        public HttpResponseMessage Get()
        {
            try
            {
                WebApiApplication.PushBroker.QueueNotification(new GcmNotification().ForDeviceRegistrationId(
                    "APA91bHMG6xNUzXW9K-eWDWVKEcoMz1OCUBKgYvKYCyb6RgzOfktlMNvHvg83GcrvytLnC2f0-8m4tqxN7IOt5DauTFk-OVwL1tU1A1lO0JSnCSk8Du7w7Z3s_EutI4WvzRTdwP-eCLPHXgDZXFJx-hHPWqN-zO_CbyuSLmA1MkoDSGrQDxNkTE")
                    .WithJson(@"{""alert"":""Hello World!"",""badge"":7,""sound"":""sound.caf""}"));


                ////Stop and wait for the queues to drains
                //PushBroker.StopAllServices();
                return Request.CreateResponse(HttpStatusCode.OK, "Notification successfully sent");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Notification failed sent");
            }
        }
    }
}