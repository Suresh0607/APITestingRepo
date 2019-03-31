﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Configuration;


namespace APITesting
{
    public class ExtentManager
    {
        public static ExtentHtmlReporter htmlReporter;

        private static ExtentReports extent;

        private ExtentManager()
        {

        }

        public static ExtentReports getInstance()
        {
            if (extent == null)
            {
                string reportFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".html";
                string testRptPath = ConfigurationManager.AppSettings["Path"] + "\\APITestingRepo\\WeatherAPI\\TestReport\\";
                string extenConfigFile = ConfigurationManager.AppSettings["Path"] + "\\APITestingRepo\\WeatherAPI\\WeatherAPI\\extent-config.xml";
                htmlReporter = new ExtentHtmlReporter(@testRptPath + "Report" + reportFile);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                htmlReporter.LoadConfig(@extenConfigFile);
            }
            return extent;
        }
    }
}
