using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.AutoFac.Performance
{
    //Not :istersek AspectInterceptorSelectora gidip hepsine ekleye biliriz(15.ders (3.11.30))
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)//interval=geçensaniye
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)//kronometre çalışır metod çalışmadan önce
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)//metod işlemi bitince //eğer girilen değeri eçerse uyrı veya log alına bilir bildirim açısından
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
