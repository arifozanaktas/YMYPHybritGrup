using System.Net.Http;

namespace AsyncProgramming
{
    internal class ServiceHelper
    {
        public async Task MakeRequestToGoogle2()
        {
            var httpClient = new HttpClient();


            httpClient.GetAsync("https://www.google.com");
        }

        public void MakeRequestToGoogleAsBad()
        {
            var httpClient = new HttpClient();


            var responseAsTask = httpClient.GetAsync("https://www.google.com").Result;
        }

        public Task MakeRequestToGoogleAsBad2()
        {
            var httpClient = new HttpClient();


            var responseAsTask = httpClient.GetAsync("https://www.google.com");

            var responseAsTask2 = httpClient.GetAsync("https://www.facebook.com");


            Task.WaitAll(responseAsTask, responseAsTask2);

            return Task.CompletedTask;
        }

        public async Task MakeRequestToGoogle()
        {
            var httpClient = new HttpClient();


            var responseAsTask = httpClient.GetAsync("https://www.google.com");

            var responseAsTask2 = httpClient.GetAsync("https://www.facebook.com");

            var responseAsTask3 = httpClient.GetAsync("https://www.hepsiburada.com");

            // db action


            var responseAsArray = await Task.WhenAll(responseAsTask, responseAsTask2, responseAsTask3);


            var x = responseAsArray[2];
        }


        public Task<HttpResponseMessage> MakeLogging(string message)
        {
            var httpClient = new HttpClient();
            return httpClient.GetAsync("https://www.google.com");
        }


        public Task MakeLogging2(string message)
        {
            var httpClient = new HttpClient();
            httpClient.GetAsync("https://www.google.com");

            return Task.CompletedTask;
            ;
        }


        public Task<HttpResponseMessage> MakeLogging4(string message)
        {
            var httpClient = new HttpClient();
            return httpClient.GetAsync("https://www.google.com");
        }

        public Task MakeLogging5(string message)
        {
            var httpClient = new HttpClient();
            httpClient.GetAsync("https://www.google.com").ContinueWith(x =>
            {
                if (x.IsFaulted)
                {
                    //logging
                }
            });
            return Task.CompletedTask;
        }

        public Task Calculate2()
        {
            var httpClient = new HttpClient();

            httpClient.Send(new HttpRequestMessage());


            return Task.CompletedTask;
        }


        public Task<int> Calculate3()
        {
            var httpClient = new HttpClient();

            httpClient.Send(new HttpRequestMessage());


            return Task.FromResult(10);
        }


        public async Task Calculate4()
        {
            var httpClient = new HttpClient();


            var response = await httpClient.GetAsync("https://www.google.com");
        }
    }
}