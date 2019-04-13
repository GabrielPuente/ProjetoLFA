using System;
using System.Text.RegularExpressions;

namespace AFNToAFD
{
    public class QOrder
    {
        private string q;
        public int Order { get; set; }
        public int OrderForSequence { get; set; }

        public string Q
        {
            get
            {
                return this.q;
            }
            set
            {
                try
                {
                    Order = Convert.ToInt32(Regex.Replace(value, "[^0-9]", ""));
                } catch (Exception) { }
                this.q = value;
            }
        }
    }
}
