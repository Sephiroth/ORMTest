using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;

namespace DapperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "server=127.0.0.1;uid=root;pwd=123456;database=db_cdz;Pooling=true;Max Pool Size=20;";

            TbUser user = null;
            using (IDbConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                user = conn.QueryFirst<TbUser>("SELECT * FROM tb_user WHERE id =@id", new { id = "2a633ebf87684421b1aa75633c611210" });
            }
            Console.WriteLine(user?.Id);
            user = null;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                using (IDbConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    user = conn.QueryFirst<TbUser>("SELECT * FROM tb_user WHERE id =@id", new { id = "2a633ebf87684421b1aa75633c611210" }) as TbUser;
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"平均耗时!{Convert.ToSingle(stopwatch.ElapsedMilliseconds) / 1000}ms");
            Console.ReadLine();
        }
    }

    public class TbUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public string WechatId { get; set; }
        public int DiscountBalance { get; set; }
        public int WithdrawalBalance { get; set; }
        public string CarNum { get; set; }
        public string Openid { get; set; }
        public string Pwd { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public int? Gender { get; set; }
        public int State { get; set; }
        public DateTime CreateTime { get; set; }
    }

}