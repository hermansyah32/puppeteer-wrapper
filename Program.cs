using puppeteer_wrapper.utils;
using System;
using System.IO;

namespace puppeteer_wrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger Logger = new Logger("Main");
            Console.WriteLine("Test take from URL");
            string url = "https://google.com";
            Directory.CreateDirectory("output");
            PuppeteerWrapper wrapper = new PuppeteerWrapper("output", url, PuppeteerWrapper.SourceType.URL);
            try
            {
                wrapper.GetPDF("test.pdf").GetAwaiter().GetResult();
                wrapper.GetScreenshots("test.jpg").GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                Logger.Error(e, "main");
            }
            Console.WriteLine("Finish screenshot");
        }
    }
}
