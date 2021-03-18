using NUnit.Framework;
using System.Data.SqlClient;
using EnAruhazam.DataAccess;
/// <summary>
/// This project does tests on database
/// </summary>
namespace DatabaseConnectionTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //Init DB connection

        }


        [Test]
        public void TestDBConnection()
        {/*
            bool Connected = false;
            //Modify Conval string value to the desired DB name
            using (var conn = new SqlConnection(MSSQLHelper.GetConStr()))
            {
                try
                {
                    conn.Open();
                    Connected = true;
                }
                catch (SqlException e)
                {
                    System.Console.WriteLine(e);
                    Connected = false;
                }


            }

                Assert.IsTrue(Connected);*/
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}