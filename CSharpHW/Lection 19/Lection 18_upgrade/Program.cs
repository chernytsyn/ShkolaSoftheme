using System;
using System.Linq;

namespace Lection_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();

            Console.ReadLine();
        }

        public static void Test()
        {
            var MobOperator = MobileOperator.Instance;

            MobOperator.AddAccount(new MobileAccount(1111111));  // account for tests, that number will call 10 times and send sms 3 times

            for (var i = 0; i < 50; i++)
            {
                MobOperator.CreateNumber();
            }

            AddingFriend();
            RandomCallsAndSmsFromCreator();
            RandomCallsAndSmsForTest();

            MobOperator.ShowTopFiveActive();
            MobOperator.ShowTopFiveGettingCalled();
            MobOperator.PrintNumberStatistic(1111111);
        }

        public static void AddingFriend()
        {
            var MobOperator = MobileOperator.Instance;

            var MyAccount = MobOperator.RegisteredAccounts.First(user => user.uniqueNumber == 1111111);
            for (var i = 1; i < 50; i++) // every second registered number got friend Vladyslav Chernytsyn
            {
                if (i % 2 == 0)
                {
                    MobOperator.RegisteredAccounts[i].AddFriend(MyAccount, "Chernytsyn Vladyslav");
                }
            }
        }

        public static void RandomCallsAndSmsFromCreator()
        {
            var MobOperator = MobileOperator.Instance;

            for (var i = 0; i < 10; i++)
            {
                var randomNumber = MobileOperator.random.Next(0, 50);
                MobOperator.RegisteredAccounts[1].MakeCall(MobOperator.RegisteredAccounts[randomNumber]);
            }

            for (var i = 0; i < 3; i++)
            {
                var randomNumber = MobileOperator.random.Next(0, 50);
                MobOperator.RegisteredAccounts[1].SendSms(MobOperator.RegisteredAccounts[randomNumber]);
            }
        }

        public static void RandomCallsAndSmsForTest()
        {
            var MobOperator = MobileOperator.Instance;

            for (var i = 0; i < 100; i++)
            {
                var randomCallerNumber = MobileOperator.random.Next(0, 50);
                var randomGettingCalledNumber = MobileOperator.random.Next(0, 50);

                MobOperator.RegisteredAccounts[randomCallerNumber].MakeCall(MobOperator.RegisteredAccounts[randomGettingCalledNumber]);
            }

            for (var i = 0; i < 100; i++)
            {
                var randomCallerNumber = MobileOperator.random.Next(0, 50);
                var randomGettingCalledNumber = MobileOperator.random.Next(0, 50);

                MobOperator.RegisteredAccounts[randomCallerNumber].SendSms(MobOperator.RegisteredAccounts[randomGettingCalledNumber]);
            }
        }
    }
}
