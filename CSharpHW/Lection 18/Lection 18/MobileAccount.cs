using System;
using System.Collections.Generic;
using System.Linq;

namespace Lection_18
{
    public class MobileAccount : EventArgs
    {
        public int uniqueNumber { get; private set; }
        public string Name { get; private set; }

        public event EventHandler<MobileAccount> makeCallEvent;
        public event EventHandler<MobileAccount> sendSMSEvent;

        public List<MobileAccount> Friends;
        public MobileAccount(int number)
        {
            this.Friends = new List<MobileAccount>();
            this.uniqueNumber = number;
            this.Name = "";
            this.Friends.Add(this);
        }

        public void AddFriend(MobileAccount friendMobile, string friendName)
        {
            if (this.IsExist(friendMobile))
            {
                Console.WriteLine("Friend already exist");
            }
            else
            {
                friendMobile.Name = friendName;

                Friends.Add(friendMobile);
                Console.WriteLine("\nAdding Friend to {0} : \nFriend was added, name: {1}, number: {2} \n", this.uniqueNumber,friendMobile.Name,friendMobile.uniqueNumber);
            }
        }
        public string GetFriendName(int number)
        {
            var friendName = "";

            foreach (MobileAccount mob in Friends)
            {
                if (mob.uniqueNumber.Equals(number))
                {
                    return mob.Name;
                }
            }
            return friendName;
        }

        public bool IsExist(MobileAccount mobileAcc)
        {
            bool isExist = this.Friends.Any(friend => friend.uniqueNumber == mobileAcc.uniqueNumber);
            return isExist;
        }

        public void NotifyMakeCall(MobileAccount eventParameter)
        {
            if (makeCallEvent != null)
            {
                makeCallEvent(this, eventParameter);
            }
        }
        public void NotifySendSms(MobileAccount eventParameter)
        {
            if (sendSMSEvent != null)
            {
                sendSMSEvent(this, eventParameter);
            }
        }
        public void MakeCall(MobileAccount mobileAcc)
        {
            NotifyMakeCall(mobileAcc);
        }
        public void SendSms(MobileAccount mobileAcc)
        {
            NotifySendSms(mobileAcc);
        }



    }
}
