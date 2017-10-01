using System;
using System.Collections.Generic;
using System.Linq;

namespace Lection_18
{
    class MobileOperator
    {
        public List<MobileAccount> RegisteredAccounts { get; private set; }
        public List<AccountInfo> InfoAboutAccounts { get; private set; }

        public static Random random;

        private static int count = 0;
        private static MobileOperator instance = null;

        static MobileOperator()
        {
            random = new Random();
        }

        private MobileOperator()
        {
            RegisteredAccounts = new List<MobileAccount>();
            InfoAboutAccounts = new List<AccountInfo>();

            var newAccount = new MobileAccount(GetRandomNumber());
            var newAccountInfo = new AccountInfo(newAccount);

            Console.WriteLine(newAccount.uniqueNumber);

            RegisteredAccounts.Add(newAccount);
            InfoAboutAccounts.Add(newAccountInfo);

            ObserveCallsAndSms();
        }

        public static MobileOperator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MobileOperator();
                }
                return instance;
            }
        }

        public void AddAccount(MobileAccount newAccount)
        {
            this.RegisteredAccounts.Add(newAccount);
            Console.WriteLine(newAccount.uniqueNumber);

            var newAccountInfo = new AccountInfo(newAccount);
            this.InfoAboutAccounts.Add(newAccountInfo);

            ObserveCallsAndSms();

        }

        public void ObserveCallsAndSms()
        {
            RegisteredAccounts[count].makeCallEvent += new EventHandler<MobileAccount>(ReceiveCall);
            RegisteredAccounts[count].sendSMSEvent += new EventHandler<MobileAccount>(ReceiveSms);

            count++;
        }

        public void CreateNumber()
        {
            var newAccount = new MobileAccount(GetRandomNumber());
            if (this.NumberExist(newAccount))
            {
                Console.WriteLine("Number already exist");
            }
            else
            {
                Console.WriteLine(newAccount.uniqueNumber);
                this.RegisteredAccounts.Add(newAccount);

                var newAccountInfo = new AccountInfo(newAccount);
                this.InfoAboutAccounts.Add(newAccountInfo);

                ObserveCallsAndSms();
            }
        }

        public bool NumberExist(MobileAccount checkNumber)
        {
            foreach (MobileAccount ma in RegisteredAccounts)
            {
                if (checkNumber.uniqueNumber.Equals(ma.uniqueNumber))
                {
                    return true;
                }
            }
            return false;
        }
        public void PrintNumberStatistic(int number)
        {
            if (this.InfoAboutAccounts.Any(user => user.ConnectedAccount.uniqueNumber == number))
            {
                var accountInfo = this.InfoAboutAccounts.Find(account => account.ConnectedAccount.uniqueNumber == number);

                Console.WriteLine("\n**************************************************"+ 
                              "\nYou were searching statistic for this number: {0}\n" +
                              "Rating = {1}\nGetCalledRating = {2}\n", number, accountInfo.Rating, accountInfo.GetCalledRating);


                Console.WriteLine("\nPrinting Calls list:\n");
                var callList = accountInfo.CallsList;
                foreach (MobileInfo mi in callList)
                {
                    Console.WriteLine("Was calling to a number: {0},  date and time: {1}", mi.CallerNumber, mi.CallDateTime);
                }

                Console.WriteLine("\nPrinting SMS list:\n");
                var smsList = accountInfo.SmsList;
                foreach (MobileInfo mi in smsList)
                {
                    Console.WriteLine("Was sending sms to a number: {0},  date and time: {1}", mi.CallerNumber, mi.CallDateTime);
                }

                Console.WriteLine("\n**************************************************\n");
            }
        }

        public void ShowTopFiveActive()
        {
            var topFive = this.InfoAboutAccounts.OrderByDescending(user => user.Rating)
                .Take(5);

            Console.WriteLine("\nPrinting topFive callers:\n");
            foreach (AccountInfo ai in topFive)
            {
                Console.WriteLine("Number: {0}, rating = {1}", ai.ConnectedAccount.uniqueNumber, ai.Rating);
            }
        }

        public void ShowTopFiveGettingCalled()
        {
            var topFive = this.InfoAboutAccounts.OrderByDescending(user => user.GetCalledRating)
                .Take(5);

            Console.WriteLine("\nPrinting topFive getting called numbers:\n");
            foreach (AccountInfo ai in topFive)
            {
                Console.WriteLine("Number: {0}, getCalledRating = {1}", ai.ConnectedAccount.uniqueNumber, ai.GetCalledRating);
            }
        }

        private static int GetRandomNumber() => random.Next(1111111, 9999999);

        private void SetAdditionalCallInfo(MobileAccount caller, MobileAccount owner)
        {
            var index = this.InfoAboutAccounts.FindIndex(o => o.ConnectedAccount == owner);
            this.InfoAboutAccounts[index].SetGetCalledRating(owner);

            var callerIndex = this.InfoAboutAccounts.FindIndex(o => o.ConnectedAccount == caller);
            this.InfoAboutAccounts[callerIndex].AddCall(owner);

        }

        private void SetAdditionalSMSInfo(MobileAccount sender, MobileAccount owner)
        {
            var index = this.InfoAboutAccounts.FindIndex(o => o.ConnectedAccount == owner);
            this.InfoAboutAccounts[index].SetGetCallRatingBySMS(owner);

            var senderIndex = this.InfoAboutAccounts.FindIndex(o => o.ConnectedAccount == sender);
            this.InfoAboutAccounts[senderIndex].AddSms(owner);
        }

        private void ReceiveCall(object sender, MobileAccount mobileAcc)
        {
            var senderAcc = (MobileAccount)sender;
            if (mobileAcc.IsExist(senderAcc))
            {
                var name = mobileAcc.GetFriendName(senderAcc.uniqueNumber);
                Console.WriteLine("Your friend - {0} is calling", name);
            }
            else
            {
                Console.WriteLine("Receive Call from {0} to {1} ", senderAcc.uniqueNumber, mobileAcc.uniqueNumber);
            }
            SetAdditionalCallInfo(senderAcc, mobileAcc);
        }

        private void ReceiveSms(object sender, MobileAccount mobileAcc)
        {
            var senderAcc = (MobileAccount)sender;
            if (mobileAcc.IsExist(senderAcc))
            {
                var name = mobileAcc.GetFriendName(senderAcc.uniqueNumber);
                Console.WriteLine("Your friend - {0} is sending sms", name);
            }
            else
            {
                Console.WriteLine("Receive SMS from {0} to {1} ", senderAcc.uniqueNumber, mobileAcc.uniqueNumber);
            }
            SetAdditionalSMSInfo(senderAcc, mobileAcc);
        }
    }
}
