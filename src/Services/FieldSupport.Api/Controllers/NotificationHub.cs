using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FieldSupport.Api.Model;
using FieldSupport.Api.Tickers;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace FieldSupport.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [HubName("notification")]
    public class NotificationHub : Hub
    {
        private readonly NotificationTicker _ticker;

        /// <summary>
        /// 
        /// </summary>
        public NotificationHub() : this(NotificationTicker.Instance) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticker"></param>
        public NotificationHub(NotificationTicker ticker)
        {
            _ticker = ticker;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Notification> GetAllNotifications()
        {
            return _ticker.GetAllNotifications();
        }

        
    }
}