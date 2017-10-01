using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_18
{
    [Serializable]
    public class FriendInfo
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public FriendInfo()
        {
            this.Number = 0;
            this.Name = "";
        }
        public FriendInfo(int number)
        {
            this.Number = number;
            this.Name = "";
        }
        public FriendInfo(MobileAccount mobAcc, string name)
        {
            this.Number = mobAcc.uniqueNumber;
            this.Name = name;
        }
    }
}
