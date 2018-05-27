using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Cirno.Http;
using Cirno.Mvc.Responses;

namespace Cirno.Mvc.Invocation
{
    public class InvokeActionHandler : IHttpHandler
    {
        public InvokeActionHandler(IServiceProvider services, Type contollerType, MethodInfo actionMethod)
        {
            this.Services = services ?? throw new ArgumentNullException(nameof(services));
            this.ContollerType = contollerType ?? throw new ArgumentNullException(nameof(contollerType));
            this.ActionMethod = actionMethod ?? throw new ArgumentNullException(nameof(actionMethod));
            // TODO 验证类型和方法关系
            this.Constructor = this.FindConstructor(contollerType);
            this.ParameterProviders = this.BuildParameterProviders(this.Constructor, services);
        }

        protected IServiceProvider Services { get; }

        protected Type ContollerType { get; }

        protected ConstructorInfo Constructor { get; }

        protected MethodInfo ActionMethod { get; }

        protected IParameterProvider[] ParameterProviders { get; }

        public Task HandleAsync(IHttpContext context)
        {
            return Task.Run(() => this.InvokeAction(context));
        }

        private void InvokeAction(IHttpContext context)
        {
            // TODO 使用Expression编译委托代替默认反射
            var parameters = this.ParameterProviders.Select(p => p.GetValue()).ToArray();
            var controller = (Controller)this.Constructor.Invoke(parameters);
            controller.Services = this.Services;
            controller.Context = context;
            controller.Request = context.Request;
            // TODO 获取ActionMethod的参数值
            var value = this.ActionMethod.Invoke(controller, new object[0]);
            if (value is IResponse response)
            {
                context.Response = response;
            }
            if (value is string stringValue)
            {
                context.Response = new TextResponse(stringValue);
            }
            else if (value != null)
            {
                context.Response = new JsonResponse(value);
            }
        }

        private ConstructorInfo FindConstructor(Type type)
        {
            var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (ctors.Length > 1 || ctors.Length < 0)
            {
                throw new InvalidOperationException(); // TODO provide a error message
            }
            return ctors[0];
        }

        private IParameterProvider[] BuildParameterProviders(ConstructorInfo ctor, IServiceProvider services)
        {
            return ctor
                .GetParameters()
                .Select(p => new ServiceParameterProvider(services, p.ParameterType))
                .ToArray();
        }
    }
}