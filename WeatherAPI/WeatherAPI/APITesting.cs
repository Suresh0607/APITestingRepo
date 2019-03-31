using NUnit.Framework;
using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using AventStack.ExtentReports;
using System.Configuration;


namespace APITesting
{
    [TestFixture]
    public class WeatherApiTesting
    {
        ExtentReports rep = ExtentManager.getInstance();
        ExtentTest test;

        [TestCase("Sydney", 20)]
        [Test]
        public void WeatherForCastTest(string City, int temperature)
        {
            test = rep.CreateTest("WeatherForeCast for Next 5 Days with Temp > 20 for the City-" + City);
            var client = new RestClient(ConfigurationManager.AppSettings["WeatherAPI_5dayForcast"] + City + "&APPID=" + ConfigurationManager.AppSettings["WeatherAPI_Key"]);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            dynamic api = JObject.Parse(response.Content);
            var categories = api.list;
            Dictionary<string, int> daysTemp = new Dictionary<string, int>();
            Dictionary<string, int> sunnyDays = new Dictionary<string, int>();

            foreach (var item in categories)
            {
                var tempinKelvin = item.main.temp;
                var tempinDegrees = tempinKelvin - 273.15;
                int tempDegree = tempinDegrees;

                if (tempDegree > temperature)
                {
                    string tdate = item.dt_txt;
                    string tempDate = tdate.Split(' ')[0];
                    string d = Convert.ToDateTime(tempDate).ToString("dddd, dd MMMM yyyy");

                    if (!daysTemp.ContainsKey(d))
                        daysTemp.Add(d, tempDegree);
                }

                int cloud_status = item.clouds.all;

                if (cloud_status == 0)
                {
                    string csdate = item.dt_txt;
                    string csDate = csdate.Split(' ')[0];

                    string cloud_status_date = Convert.ToDateTime(csDate).ToString("dddd, dd MMMM yyyy");

                    if (!sunnyDays.ContainsKey(cloud_status_date))
                        sunnyDays.Add(cloud_status_date, cloud_status);
                }
            }

            foreach (KeyValuePair<string, int> item in daysTemp)
            {
                Console.WriteLine("Date:--" + item.Key + "       Temperature:--" + item.Value);
                test.Log(Status.Info, "Date:--" + item.Key + "       Temperature:--" + item.Value);
            }

            test.Log(Status.Info, "Total Sunny Days :--" + sunnyDays.Count);
            rep.Flush();
        }


    }

}
