using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOE_Test
{
    public class CustomFilter : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var name = GetStepName(context);
            Console.WriteLine(name + "excute before");

            await next(context);

            Console.WriteLine(name + "excute after");
        }

        private string GetStepName(AspectContext context)
        {
            var implement = context.Implementation.GetType().Name;
            var method = context.ProxyMethod.Name;
            return $"{implement}-{method}";
        }
    }
}