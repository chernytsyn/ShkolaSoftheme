using System.Collections.Generic;

namespace Lection_18
{
    public class AccountInfo
    {
        public double Rating { get; private set; }

        public double GetCalledRating { get; private set; }

        public MobileAccount ConnectedAccount { get; private set; }

        public List<MobileInfo> CallsList = new List<MobileInfo>();
        public List<MobileInfo> SmsList = new List<MobileInfo>();

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
