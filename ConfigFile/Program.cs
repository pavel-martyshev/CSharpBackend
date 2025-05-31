using System;
using System.Configuration;

namespace ConfigFile
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var siteUrl = ConfigurationManager.AppSettings["SiteUrl"];

            Console.WriteLine(siteUrl);
        }
    }
}
