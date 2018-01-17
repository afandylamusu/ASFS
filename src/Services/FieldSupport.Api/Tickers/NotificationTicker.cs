using FieldSupport.Api.Controllers;
using FieldSupport.Api.Model;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace FieldSupport.Api.Tickers
{
    /// <summary>
    /// 
    /// </summary>
    public class NotificationTicker
    {
        private readonly static Lazy<NotificationTicker> _instance = new Lazy<NotificationTicker>(() => new NotificationTicker(GlobalHost.ConnectionManager.GetHubContext<NotificationHub>().Clients));

        /// <summary>
        /// 
        /// </summary>
        public static NotificationTicker Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private readonly ConcurrentDictionary<string, Notification> _notifications = new ConcurrentDictionary<string, Notification>();
        private readonly Timer _timer;

        internal IEnumerable<Notification> GetAllNotifications()
        {
            return _notifications.Values;
        }


        private NotificationTicker(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;

            _notifications.Clear();
            var notifications = new List<Notification>
            {
                new Notification { Symbol = "MSFT", Price = 30.31m },
                new Notification { Symbol = "APPL", Price = 578.18m },
                new Notification { Symbol = "GOOG", Price = 570.30m }
            };
            notifications.ForEach(stock => _notifications.TryAdd(stock.Symbol, stock));

            _timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);

        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        private readonly object _updateStockPricesLock = new object();

        //stock can go up or down by a percentage of this factor on each change
        private readonly double _rangePercent = .002;

        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(250);
        private readonly Random _updateOrNotRandom = new Random();
        private volatile bool _updatingStockPrices = false;

        private void UpdateStockPrices(object state)
        {
            lock (_updateStockPricesLock)
            {
                if (!_updatingStockPrices)
                {
                    _updatingStockPrices = true;

                    foreach (var stock in _notifications.Values)
                    {
                        if (TryUpdateStockPrice(stock))
                        {
                            BroadcastStockPrice(stock);
                        }
                    }

                    _updatingStockPrices = false;
                }
            }
        }

        private bool TryUpdateStockPrice(Notification stock)
        {
            // Randomly choose whether to update this stock or not
            var r = _updateOrNotRandom.NextDouble();
            if (r > .1)
            {
                return false;
            }

            // Update the stock price by a random factor of the range percent
            var random = new Random((int)Math.Floor(stock.Price));
            var percentChange = random.NextDouble() * _rangePercent;
            var pos = random.NextDouble() > .51;
            var change = Math.Round(stock.Price * (decimal)percentChange, 2);
            change = pos ? change : -change;

            stock.Price += change;
            return true;
        }

        private void BroadcastStockPrice(Notification stock)
        {
            Clients.All.updateStockPrice(stock);
        }
    }
}