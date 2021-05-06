using System;
using System.Diagnostics;
using System.Threading.Tasks;
using JsonUnitTestProject.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerShellLibrary.Classes;
using PowerShellLibrary.Converters;

namespace JsonUnitTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        /// <summary>
        /// Validate returning date information using <seealso cref="UnixEpochDateTimeConverter"/> converter from Microsoft
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestTraits(Trait.UnixEpochDateTime)]
        public async Task Deserialize_Object_With_UpTime()
        {
            var cdi = await Operations.GetPartialComputerInformationTask("computerDateInfo.json");
            var up = GetUpTime();
            
            TimeSpan ts1 = new TimeSpan(cdi.OsUptime.Days, cdi.OsUptime.Hours, cdi.OsUptime.Minutes, 0);
            TimeSpan ts2 = new TimeSpan(up.Days, up.Hours, up.Minutes, 0);
            
            Assert.AreEqual(ts1, ts2);
        }
        
        [TestMethod]
        [TestTraits(Trait.UnixEpochDateTime)]
        public async Task Deserialize_Object_With_UnixEpochDateTime()
        {
            var cdi = await Operations.GetPartialComputerInformationTask("computerDateInfo.json");

            var today = new DateTime(
                cdi.OsLocalDateTime.Year, 
                cdi.OsLocalDateTime.Month,
                cdi.OsLocalDateTime.Day, 
                cdi.OsLocalDateTime.Hour,
                cdi.OsLocalDateTime.Minute,
                0);
            

            
            Debug.WriteLine($"{cdi.OsLocalDateTime.ToString("G")} -- {DateTime.Now.ToString("G")}");
            
        }
    }
}