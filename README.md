# ❄️Cirno Project

Cirno is a simple and lightweight web framework for .NET Standard.

## Components

- ✔️ HTTP Abstraction
- ✔️ Request Handling Pipeline
- ✔️ Dependency Injection
- ✔️ Logging
- ✔️ Simple Routing
- ⏰ Full Featured Routing
- ✔️ JSON Web API
- ⏰ Cookies
- ⏰ Authentication
- ⏰ Model Binding
- ⏰ Validation
- ⏰ API Documents
- ⏰ Static File Support
- ⏰ View Rendering
- ✔️ Default Http Server
- ✔️ Bootstrapper
- ⏰ DotNetty Http Server
- ⏰ Health Indicators
- ⏰ Metrics

## Sample

```csharp
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
```