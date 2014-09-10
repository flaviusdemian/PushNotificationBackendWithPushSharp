using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.ServiceBus.Notifications;
using PushSharp;
using PushSharp.Android;
using PushSharp.Apple;
using PushSharp.Core;

namespace TestPushNotifications
{
    public class WebApiApplication : HttpApplication
    {
        public static NotificationHubClient Hub;
        public static PushBroker PushBroker = new PushBroker();

        static WebApiApplication()
        {
            try
            {
                PushBroker.RegisterGcmService(new GcmPushChannelSettings("113513198717", "AIzaSyCuUseU--wCWpBbTYyh_ry9VMn5L2JNBdo", "com.fundora.mobileservices.demo"));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            try
            {
                string appleCertificatePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "PushNotifications/Apple/CertificateNotificationHubs.p12");
                var appleCertificate = File.ReadAllBytes(appleCertificatePath);
                PushBroker.RegisterAppleService(new ApplePushChannelSettings(false, appleCertificate, "slowarad1@"));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //Wire up the events for all the services that the broker registers
            PushBroker.OnNotificationSent += NotificationSent;
            PushBroker.OnChannelException += ChannelException;
            PushBroker.OnServiceException += ServiceException;
            PushBroker.OnNotificationFailed += NotificationFailed;
            PushBroker.OnDeviceSubscriptionExpired += DeviceSubscriptionExpired;
            PushBroker.OnDeviceSubscriptionChanged += DeviceSubscriptionChanged;
            PushBroker.OnChannelCreated += ChannelCreated;
            PushBroker.OnChannelDestroyed += ChannelDestroyed;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterNotificationHub();
        }

        private async Task RegisterNotificationHub()
        {
            try
            {
                Hub = NotificationHubClient.CreateClientFromConnectionString(
                    @"Endpoint=sb://fundoraxamarinhub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=L5pOQdUuSBd7klcuHXE6fAN69It5iLRDnm7q3mm2tfo=",
                    "fundoraxamarinhub");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private static void ChannelDestroyed(object sender)
        {
        }

        private static void ChannelCreated(object sender, IPushChannel pushchannel)
        {
        }

        private static void DeviceSubscriptionChanged(object sender, string oldsubscriptionid, string newsubscriptionid,
            INotification notification)
        {
        }

        private static void DeviceSubscriptionExpired(object sender, string expiredsubscriptionid, DateTime expirationdateutc,
            INotification notification)
        {
        }

        private static void NotificationFailed(object sender, INotification notification, Exception error)
        {
        }

        private static void ServiceException(object sender, Exception error)
        {
        }

        private static void ChannelException(object sender, IPushChannel pushchannel, Exception error)
        {
        }

        private static void NotificationSent(object sender, INotification notification)
        {
        }
    }
}