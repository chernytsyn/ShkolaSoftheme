using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_18
{
    public class MobileInfo
    {
        public int CallerNumber { get; private set; }
        public DateTime CallDateTime { get; private set; }

        public MobileInfo(int number)
        {
            this.CallerNumber = number;
            this.CallDateTime = DateTime.Now;
        }
    }
}
