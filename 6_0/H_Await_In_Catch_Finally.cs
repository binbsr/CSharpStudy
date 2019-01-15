using System.Net.Http;
using System.Threading.Tasks;

namespace _6_0
{
    class SCC8_Await_In_Catch_Finally
    {
        public static async Task<string> MakeRequestAndLogFailures()
        {
            await logMethodEntrance();
            var client = new HttpClient();
            var streamTask = client.GetStringAsync("https://www.google.com");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (HttpRequestException e) when (e.Message.Contains("301"))
            {
                await logError("Recovered from redirect", e);
                return "Site Moved";
            }
            finally
            {
                await logMethodExit();
                client.Dispose();
            }
        }

        private static Task logMethodExit()
        {
            return Task.FromResult("Httpclient disposed.");
        }

        private static Task logError(string v, HttpRequestException e)
        {
            return Task.FromResult("Httpclient invocation failed, logging...");
        }

        private static Task logMethodEntrance()
        {
            return Task.FromResult("Httpclient invocation started...");
        }
    }
}
