using System;
using System.Collections.Generic;

namespace Lection_18
{
    [Serializable]
    public class AccountInfo
    {
        public double Rating { get; set; }

        public double GetCalledRating { get; set; }

        public MobileAccount ConnectedAccount { get; set; }

        public List<MobileInfo> CallsList = new List<MobileInfo>();
        public List<MobileInfo> SmsList = new List<MobileInfo>();

        public AccountInfo() { }

        public AccountInfo(MobileAccount ownerAcc)
        {
            this.Rating = 0.0;
            this.GetCalledRating = 0.0;
            this.ConnectedAccount = ownerAcc;
        }

        public void SetGetCalledRating(MobileAccount caller)
        {
            this.GetCalledRating++;
        }
        public void SetGetCallRatingBySMS(MobileAccount sender)
        {
            this.GetCalledRating = this.GetCalledRating + 0.5;
        }

        public void AddCall(MobileAccount calledNumber)
        {
            this.Rating++;
            var callInfo = new MobileInfo(calledNumber.uniqueNumber);
            this.CallsList.Add(callInfo);
        }

        public void AddSms(MobileAccount smsAchiever)
        {
            this.Rating = this.Rating + 0.5;
            var smsInfo = new MobileInfo(smsAchiever.uniqueNumber);
            this.SmsList.Add(smsInfo);
        }
    }
}
