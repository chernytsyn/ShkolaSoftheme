using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Lection_18
{
    [Serializable]
    public class MobileAccount : EventArgs
    {
        public int uniqueNumber { get; set; }
        public string Name { get; set; }

        public event EventHandler<MobileAccount> makeCallEvent;
        public event EventHandler<MobileAccount> sendSMSEvent;

        public List<FriendInfo> Friends { get; set; }

        public MobileAccount()
        {
            this.Friends = new List<FriendInfo>();
        }

        public MobileAccount(int number)
        {
            this.Friends = new List<FriendInfo>();
            this.uniqueNumber = number;
            this.Name = "";
            this.Friends.Add(new FriendInfo(this,"My number"));
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

                Friends.Add(new FriendInfo(friendMobile, friendName));
                Console.WriteLine("\nAdding Friend to {0} : \nFriend was added, name: {1}, number: {2} \n",
                                           this.uniqueNumber, friendMobile.Name, friendMobile.uniqueNumber);
            }
        }
        public string GetFriendName(int number)
        {
            var friendName = "";

            var searchedIndex = this.Friends.FirstOrDefault(friend => friend.Number == number);
            friendName = searchedIndex.Name;

            return friendName;
        }

        public bool IsExist(MobileAccount mobileAcc)
        {
            bool isExist = this.Friends.Any(friend => friend.Number == mobileAcc.uniqueNumber);
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
