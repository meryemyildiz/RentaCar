using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core1.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //öncelik sırasını belirleyeceğiz.ör:1.validation 2.loglama

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
