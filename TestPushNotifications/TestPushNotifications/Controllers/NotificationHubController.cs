using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.ServiceBus.Notifications;

namespace TestPushNotifications.Controllers
{
    public class NotificationHubController : ApiController
    {
        // GET: api/Push
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                string payload = "{ \"data\" : {\"msg\":\"Hello from Azure!\"}}";
                NotificationOutcome outcome = null;
                string trackingId = null;
                //outcome = await WebApiApplication.Hub.SendGcmNativeNotificationAsync("{ \"data\" : {\"msg\":\"Hello from Azure!\"}}");
                //trackingId = outcome.TrackingId;
                payload = "{ \"aps\" : { \"alert\" : \"Hello World!\" } }";
                outcome = await WebApiApplication.Hub.SendAppleNativeNotificationAsync(payload);
                trackingId = outcome.TrackingId;
                //             GooglePushMessage message = new GooglePushMessage();
                //2: message.Data.Add("greeting", "Hello World!");
                //3: message.DelayWhileIdle = true;
                //4: message.TimeToLiveInSeconds = 60 * 60 * 2;
                //5: message.Add("myKey1", "myValue");
                //6: await Services.Push.SendAsync(message);

                return Request.CreateResponse(HttpStatusCode.OK, "Notification successfully sent");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Notification failed sent");
            }
        }
    }
}
