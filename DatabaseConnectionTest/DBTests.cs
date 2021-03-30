using NUnit.Framework;
using System.Data.SqlClient;
using EnAruhazam.DataAccess;
using System.Data;
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
           

        }

        //Database test before doing other tests.
        [Test]
        public void TestDBConnection()
        {
           // SqlConnection con = new SqlConnection(MSSQLHelper.GetConStr());
           // Assert.AreEqual(con.State, ConnectionState.Open);

        }

        [Test]
        public void TestRequiredTables()
        {
            
        }
    }
}