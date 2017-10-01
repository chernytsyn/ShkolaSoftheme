using System;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.IO.Compression;

namespace Lection_18
{
    class Program
    {
        const string sourceFile = "MobileOperator.xml"; // исходный файл
        const string compressedFile = "MobileOperatorbook.gz"; // сжатый файл
        const string targetFile = "MobileOperator_new.xml"; // восстановленный файл

        static void Main(string[] args)
        {
            //Test(); // serialize is happening inside this method
            //Compress(sourceFile, compressedFile); // Compressing method

            Decompress(compressedFile, targetFile);
            var MobOperator = Deserialize();
            TestDeserializedInfo(MobOperator);

            Console.ReadLine();
        }

        public static void Compress(string sourceFile, string compressedFile)
        {
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(compressedFile))
                using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                {
                    sourceStream.CopyTo(compressionStream);
                    Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                        sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                }
            }
            try
            {
                File.Delete(sourceFile);
                File.Delete(targetFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong with deleting those files");
            }
        }

        public static void Decompress(string compressedFile, string targetFile)
        {
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(targetFile))
                {
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }

        public static void Serialize(MobileOperator MobOperator)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MobileOperator));

            using (FileStream fs = new FileStream("MobileOperator.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, MobOperator);
            }
        }

        public static MobileOperator Deserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MobileOperator));
            MobileOperator MobOperator;

            using (FileStream fs = new FileStream("MobileOperator_new.xml", FileMode.OpenOrCreate))
            {
                MobOperator = (MobileOperator)serializer.Deserialize(fs);
            }

            MobOperator.ForceSubcribe();

            File.Delete(targetFile);

            return MobOperator;
        }
        public static void TestDeserializedInfo(MobileOperator MobOperator)
        {
            MobOperator.ShowTopFiveActive();
            MobOperator.ShowTopFiveGettingCalled();
            MobOperator.PrintNumberStatistic(1111111);
            MobOperator.RegisteredAccounts[2].MakeCall(MobOperator.RegisteredAccounts[3]);
            MobOperator.RegisteredAccounts[2].MakeCall(MobOperator.RegisteredAccounts[4]);
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

            Console.WriteLine("Serializing this operator");
            Serialize(MobOperator);
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
