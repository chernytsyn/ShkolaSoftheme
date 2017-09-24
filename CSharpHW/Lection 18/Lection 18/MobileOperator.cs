using System;
using System.Collections.Generic;

namespace Lection_18
{
    class MobileOperator
    {      
        public List<MobileAccount> RegisteredAccounts { get; private set; }

        public static Random random;

        private static int count = 0;

        static MobileOperator()
        {
            random = new Random();
        }
        public MobileOperator()
        {
            RegisteredAccounts = new List<MobileAccount>();
            var newAccount = new MobileAccount(random.Next(1111111, 9999999));

            Console.WriteLine(newAccount.uniqueNumber);
            RegisteredAccounts.Add(newAccount);

            ObserveCallsAndSms();
        }

        public void AddAccount(MobileAccount newAccount)
        {
            this.RegisteredAccounts.Add(newAccount);
            Console.WriteLine(newAccount.uniqueNumber);

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
            var newAccount = new MobileAccount(random.Next(1111111, 9999999));
            if (this.NumberExist(newAccount))
            {
                Console.WriteLine("Number already exist");
            }
            else
            {
                Console.WriteLine(newAccount.uniqueNumber);
                RegisteredAccounts.Add(newAccount);

                ObserveCallsAndSms();
            }
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
    }
}
