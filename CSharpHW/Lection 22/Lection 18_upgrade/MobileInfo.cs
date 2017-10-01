using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_18
{
    [Serializable]
    public class MobileInfo
    {
        public int CallerNumber { get; set; }
        public DateTime CallDateTime { get; set; }

        public MobileInfo() { }

        public MobileInfo(int number)
        {
            this.CallerNumber = number;
            this.CallDateTime = DateTime.Now;
        }
    }
}
