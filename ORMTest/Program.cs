using Linq2DB.Repository.Impl;
using Models;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ORMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BinaryPrimitives
            var intValue = 1;
            var bytes = new byte[sizeof(int)];
            BinaryPrimitives.WriteInt32BigEndian(bytes, intValue);
            #endregion

            #region Span<> 作为全局变量，或在异步中声明为变量报错
            //Span<byte> span = Encoding.UTF8.GetBytes("Hello World!").AsSpan();
            //Memory<byte> memory = new Memory<byte>();

            #endregion

            #region
            #endregion

            //DbElectricityNetworkDB.ConnStr = "server=192.168.0.82;uid=root;pwd=zkzl1-1=mysql;database=db_electricity_network;Pooling=true;Max Pool Size=20";
            //UserRepository resp = new UserRepository();
            #region LinqToDB
            //for (int i = 0; i < 30; i++)
            //{
            //    _ = GetData(resp);
            //}

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //for (int i = 0; i < 30; i++)
            //{
            //    _ = GetData(resp);
            //}
            //stopwatch.Stop();
            //Console.WriteLine($"LinqToDB平均耗时:{Convert.ToSingle(stopwatch.ElapsedMilliseconds) / 30}ms");
            #endregion

            #region dapper
            //DapperClient.DBConnStr = "server=192.168.0.82;uid=root;pwd=zkzl1-1=mysql;database=db_electricity_network;Pooling=true;Max Pool Size=20;";
            //Dapper.Repository.Impl.UserRepository resp = new Dapper.Repository.Impl.UserRepository();
            //bool rs = resp.AddEntity(new TUserinfo()
            //{
            //    Username = "asd",
            //    Password = "123",
            //    Sex = Convert.ToChar("女"),
            //    Email = "123qq.com",
            //    Idcard = "123123123412341234",
            //    Phone = "18811112222"
            //}).GetAwaiter().GetResult();
            #endregion
            Console.Read();
        }
        
        static async Task<TUserinfo> GetData(UserRepository resp)
        {
            return await resp.GetEntity(s => s.Id == 1);
        }
    }
}