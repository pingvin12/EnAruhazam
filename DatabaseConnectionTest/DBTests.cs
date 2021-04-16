using NUnit.Framework;
using EnAruhazam.DataAccess;
/// <summary>
/// This project does tests on database
/// </summary>
namespace DatabaseConnectionTest
{
/// <summary>
    /// Testing database by mocking.
    /// </summary>
    public class DatabaseTests
    {
       

        /// <summary>
        ///  Testing Db connection
        /// </summary>
        [Test]
        public void TestDBConnection()
        {
        
            Assert.That(MSSQLHelper.testHashSet.Count != 0);
           
        }

        /// <summary>
        /// Checking if our db is not null
        /// </summary>
        [Test]
        public void TestIfNotEmpty()
        {



            Assert.NotNull(MSSQLHelper.testHashSet);
            

        }


        /// <summary>
        /// Checking that we have all the tables we need.
        /// </summary>
        [Test]
        public void TestRequiredTables()
        {
            string[] s = { "dbo.Workers", "dbo.Riports", "dbo.Managers", "dbo.Equipments", "dbo.Products", "dbo.Schedules", "dbo.Shifts", "dbo.Traffic" };

            for (int i = 0; i < MSSQLHelper.testHashSet.Count; i++)
            {
                Assert.That(MSSQLHelper.testHashSet.Contains(s[i]));
            }
            
        }
    }
}