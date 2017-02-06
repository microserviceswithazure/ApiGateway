namespace ApiGateway.Controllers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    using ApiGateway.Models;

    using FireSharp;
    using FireSharp.Config;
    using FireSharp.Interfaces;

    public class EmployeeController : ApiController
    {
        private readonly IFirebaseClient client;

        public EmployeeController()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = ConfigurationManager.AppSettings["FirebaseSecret"],
                BasePath = ConfigurationManager.AppSettings["BasePath"]
            };

            this.client = new FirebaseClient(config);
        }

        public async Task<HttpResponseMessage> Delete(string alias)
        {
            var response = await this.client.DeleteAsync($"employees/{alias}");
            return new HttpResponseMessage { StatusCode = response.StatusCode };
        }

        public async Task<Employee> Get(string alias)
        {
            var response = await this.client.GetAsync($"employees/{alias}");
            return response.ResultAs<Employee>();
        }

        public async Task<IHttpActionResult> Post([FromBody] Employee employee)
        {
            var response = await this.client.SetAsync($"employees/{employee.Alias}", employee);
            return this.Ok(response.ResultAs<Employee>());
        }
    }
}