﻿using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.Aspects.Autofac.Performance
{
    class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwach;


        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwach = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwach.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwach.Elapsed.TotalSeconds>_interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwach.Elapsed.TotalSeconds}");
            }
            _stopwach.Reset();
        }

    }
}
