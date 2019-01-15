using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace _6_0
{
    public class Exception_Filters
    {
        private static async Task Main()
        {
            //Scenario1
            await MakeRequest();

            ReadKey();
        }

        public static async Task<string> MakeRequest()
        {
            HttpClientHandler webRequestHandler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };

            using (HttpClient client = new HttpClient(webRequestHandler))
            {
                var stringTask = client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/about/");
                try
                {
                    var responseText = await stringTask;
                    return responseText;
                }
                catch (HttpRequestException e) when (e.Message.Contains("301"))
                {
                    return "Site Moved";
                }
                catch (HttpRequestException e) when (e.Message.Contains("304"))
                {
                    return "Use the Cache";
                }
                catch (Exception ex) when (!Debugger.IsAttached)
                {
                    return ex.ToString();
                    // Only catch exceptions when a debugger is not attached.
                    // Otherwise, this should stop in the debugger. 
                }
            }
        }
    }
}
