using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDBController mongoDBController = new MongoDBController();
            //Tüm koleksiyonları listelemek için
            //mongoDBController.ListCollections();
            //Loginleri excel dosyasından okuma
            string[] allLines = System.IO.File.ReadAllLines(@"logins.csv");
            for (int i = 1; i < 5; i++)
            {
                string[] line = allLines[i].Split(';');
                Login l = new Login(line);
                mongoDBController.AddLogin(l);
            }
            // Tüm loginleri almak için
            // List<Login> logins = mongoDBController.GetAllLogins();

            //Session Id ile login arama
            Login login = mongoDBController.GetLoginWithSessionId("1dbb7975-e2b2-4b44-a86e-7ceddad97532");
            Console.WriteLine("Account Name : "+login.AccountName);

            //login sayısına erişmek için
            //Console.WriteLine("Size:"+mongoDBController.GetLoginSize());
            Console.ReadKey();
        }
    }
}
