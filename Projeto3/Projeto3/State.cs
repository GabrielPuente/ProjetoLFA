using System.Collections.Generic;
using System.Linq;

namespace AFNToAFD
{
    class State
    {
        public string Name { get; set; }
        public bool? IsStart { get; set; }
        public List<QOrder> Qs { get; set; }
        public List<ColumnTransition> Columns { get; set; }

        public State()
        {
            Columns = new List<ColumnTransition>();
        }

        public void CreateName()
        {
            if (Qs.Count > 0)
            {
                foreach (var q in Qs.OrderBy(o => o.Order))
                {
                    Name += $"{q.Q},";
                }

                Name = Name.TrimEnd(',');
                Name = "{" + Name + "}";
            }
        }
    }
}
