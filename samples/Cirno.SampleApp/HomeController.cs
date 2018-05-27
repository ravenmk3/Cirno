using System;
using Cirno.Http;
using Cirno.Mvc;
using Cirno.Routing.Attributes;

namespace Cirno.SampleApp
{
    [Route("home")]
    public class HomeController : Controller
    {
        [Get("index")]
        public IResponse Index()
        {
            return this.Text("Hello World!");
        }

        [Get("user")]
        public UserInfo User()
        {
            return new UserInfo
            {
                Id = DateTime.Now.Second,
                Name = Environment.UserName,
                CreatedAt = DateTime.Now
            };
        }
    }
}