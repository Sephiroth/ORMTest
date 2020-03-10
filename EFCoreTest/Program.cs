using EFCoreTest.Models;
using System;
using System.Linq;

namespace EFCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (db_electricity_networkContext db = new db_electricity_networkContext())
            {
                db.Set<TUserinfo>().Where(s => s.Id == 1);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
