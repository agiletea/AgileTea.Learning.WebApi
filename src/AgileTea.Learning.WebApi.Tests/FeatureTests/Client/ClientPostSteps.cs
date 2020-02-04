using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;
using Xunit;

namespace AgileTea.Learning.WebApi.Tests.FeatureTests.Client
{
    [Binding]
    public class ClientPostSteps
    {
        private readonly ScenarioContext context;
        private readonly WebApplicationFactory<Startup> webApplicationFactory;

        public ClientPostSteps(
            ScenarioContext context,
            WebApplicationFactory<Startup> webApplicationFactory)
        {
            this.context = context;
            this.webApplicationFactory = webApplicationFactory;
        }

        [Given(@"I have the following request body:")]
        public void GivenIHaveTheFollowingRequestBody(string json)
        {
            // add the request into the scenario context for later use
            context.Set(json, "Request");
        }
        
        [When(@"I post this request to the ""(.*)"" operation")]
        public async Task WhenIPostThisRequestToTheOperation(string operation)
        {
            // retrieve request
            var requestBody = context.Get<string>("Request");

            // set up Http Request Message
            var request = new HttpRequestMessage(HttpMethod.Post, $"/{operation}")
            {
                Content = new StringContent(requestBody)
                {
                    Headers = 
                    { 
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };

            // create an http client
            var client = webApplicationFactory.CreateClient();

            // let's post
            var response = await client.SendAsync(request).ConfigureAwait(false);

            try
            {
                context.Set(response.StatusCode, "ResponseStatusCode");
                context.Set(response.ReasonPhrase, "ResponseReasonPhrase");
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                context.Set(responseBody, "ResponseBody");
            }
            finally
            {
                // move along, move along
            }
        }
        
        [Then(@"the result should be a (.*) \(""(.*)""\) response")]
        public void ThenTheResultShouldBeAResponse(int statusCode, string reasonPhrase)
        {
            Assert.Equal(statusCode, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
            Assert.Equal(reasonPhrase, context.Get<string>("ResponseReasonPhrase"));
        }
        
        [Then(@"the response body description should include the following text: ""(.*)""")]
        public void ThenTheResponseBodyDescriptionShouldIncludeTheFollowingText(string error)
        {
            Assert.Contains(context.Get<string>("ResponseBody"), error);
        }
    }
}
