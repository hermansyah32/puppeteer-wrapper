using PuppeteerSharp;
using System.Threading.Tasks;

namespace puppeteer_wrapper.utils
{
    public class PuppeteerWrapper
    {
        private string outputPath;
        private string sourceData;
        private SourceType sourceType;

        public enum SourceType
        {
            URL,
            HTML_STRING,
            HTML_FILE
        }

        /// <summary>
        /// Initialize puppeteerwrapper setting
        /// </summary>
        /// <param name="outputPath">Output folder</param>
        /// <param name="sourceData">Source data. It can be Url, HTML file, or HTML string depend on sourceType</param>
        /// <param name="sourceType">Source data type</param>
        public PuppeteerWrapper(string outputPath, string sourceData, SourceType sourceType)
        {
            this.outputPath = outputPath;
            this.sourceData = sourceData;
            this.sourceType = sourceType;
        }

        public async Task GetPDF(string fileName)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            switch (sourceType)
            {
                case SourceType.URL:
                    {
                        var page = await browser.NewPageAsync();
                        await page.GoToAsync("http://www.google.com");
                        await page.PdfAsync(outputPath + "\\" + fileName);
                        break;
                    }
                case SourceType.HTML_FILE:
                    {
                        var page = await browser.NewPageAsync();
                        await page.GoToAsync(sourceData);
                        await page.PdfAsync(outputPath + "\\" + fileName);
                        break;
                    }
                case SourceType.HTML_STRING:
                    {
                        using (var page = await browser.NewPageAsync())
                        {
                            await page.SetContentAsync(sourceData);
                            var result = await page.GetContentAsync();
                            await page.PdfAsync(outputPath + "\\" + fileName);
                        }
                        break;
                    }
            }
        }

        public async Task GetScreenshots(string fileName)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            switch (sourceType)
            {
                case SourceType.URL:
                    {
                        var page = await browser.NewPageAsync();
                        await page.GoToAsync("http://www.google.com");
                        await page.ScreenshotAsync(outputPath + "\\" + fileName);
                        break;
                    }
                case SourceType.HTML_FILE:
                    {
                        var page = await browser.NewPageAsync();
                        await page.GoToAsync(sourceData);
                        await page.ScreenshotAsync(outputPath + "\\" + fileName);
                        break;
                    }
                case SourceType.HTML_STRING:
                    {
                        using (var page = await browser.NewPageAsync())
                        {
                            await page.SetContentAsync(sourceData);
                            var result = await page.GetContentAsync();
                            await page.ScreenshotAsync(outputPath + "\\" + fileName);
                        }
                        break;
                    }
            }
        }

        public async Task GetScreenshots(string fileName, ViewPortOptions viewPortOptions)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            switch (sourceType)
            {
                case SourceType.URL:
                    {
                        var page = await browser.NewPageAsync();
                        await page.GoToAsync("http://www.google.com");
                        await page.SetViewportAsync(viewPortOptions);
                        await page.ScreenshotAsync(outputPath + "\\" + fileName);
                        break;
                    }
                case SourceType.HTML_FILE:
                    {
                        var page = await browser.NewPageAsync();
                        await page.GoToAsync(sourceData);
                        await page.SetViewportAsync(viewPortOptions);
                        await page.ScreenshotAsync(outputPath + "\\" + fileName);
                        break;
                    }
                case SourceType.HTML_STRING:
                    {
                        using (var page = await browser.NewPageAsync())
                        {
                            await page.SetContentAsync(sourceData);
                            var result = await page.GetContentAsync();
                            await page.SetViewportAsync(viewPortOptions);
                            await page.ScreenshotAsync(outputPath + "\\" + fileName);
                        }
                        break;
                    }
            }
        }
    }
}
