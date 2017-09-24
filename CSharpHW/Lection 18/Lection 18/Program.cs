using System;

namespace Lection_18
{
    class Program
    {
        static void Main(string[] args)
        {
            var MobOperator = new MobileOperator();

            var simpleAcc = new MobileAccount(1111111);
            MobOperator.AddAccount(simpleAcc); // [1]

            MobOperator.CreateNumber(); // [2]
            MobOperator.RegisteredAccounts[2].AddFriend(simpleAcc, "Chernytsyn Vladyslav");

            MobOperator.CreateNumber();
            MobOperator.CreateNumber();

            MobOperator.RegisteredAccounts[0].MakeCall(MobOperator.RegisteredAccounts[1]); // simple call

            MobOperator.RegisteredAccounts[1].SendSms(MobOperator.RegisteredAccounts[2]); // sms from friend
            MobOperator.RegisteredAccounts[1].MakeCall(MobOperator.RegisteredAccounts[2]); // call from friend

            Console.ReadLine();
        }
    }
}
