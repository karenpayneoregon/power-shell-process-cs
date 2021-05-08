﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);

        public static DateTime RemoveMilliseconds(DateTime dateTime) =>
            ParseExact(dateTime.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", null);
        public static DateTime RemoveSeconds(DateTime dateTime) =>
            ParseExact(dateTime.ToString("yyyy-MM-dd HH:mm"), "yyyy-MM-dd HH:mm", null);

        public static DateTime RemoveMillisecondsAndSeconds(DateTime dateTime) =>
            ParseExact(dateTime.ToString("yyyy-MM-dd HH:mm"), "yyyy-MM-dd HH:mm", null);
    }

}
