using System;

namespace FieldSupport.Api.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Notification
    {
        private decimal _price;

        /// <summary>
        /// 
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price == value)
                {
                    return;
                }

                _price = value;

                if (DayOpen == 0)
                {
                    DayOpen = _price;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal DayOpen { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Change
        {
            get
            {
                return Price - DayOpen;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double PercentChange
        {
            get
            {
                return (double)Math.Round(Change / Price, 4);
            }
        }
    }
}