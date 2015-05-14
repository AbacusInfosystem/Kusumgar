using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Cors;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(KusumgarNotificationService.Startup))] 
namespace KusumgarNotificationService
{
    public partial class NotificationService : ServiceBase
    {
        IDisposable SignalR; 

        public NotificationService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (!System.Diagnostics.EventLog.SourceExists("SignalRChat"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "SignalRChat", "Application");
            }
            eventLog1.Source = "SignalRChat";
            eventLog1.Log = "Application";

            eventLog1.WriteEntry("In OnStart");
            string url = "http://localhost:8080";
            SignalR = WebApp.Start(url); 
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop");
            SignalR.Dispose(); 
        }

        public void Process()
        {
            string url = "http://localhost:8080";
            SignalR = WebApp.Start(url); 
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }

    public class MyHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    } 
}
