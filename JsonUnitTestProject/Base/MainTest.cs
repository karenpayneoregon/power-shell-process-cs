using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.DateTime;

// ReSharper disable once CheckNamespace - do not change
namespace JsonUnitTestProject
{
    public partial class MainTest
    {
        [DllImport("kernel32")]
        static extern UInt64 GetTickCount64();
        
        /// <summary>
        /// Perform any initialize for the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }

        public static TimeSpan GetUpTime() => 
            TimeSpan.FromMilliseconds(GetTickCount64());
        
        public static DateTime Now => 
            new(
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);


    }

}
