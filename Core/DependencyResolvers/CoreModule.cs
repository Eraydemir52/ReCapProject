using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
   public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)//DependencyResolversı bağımlılıkları gidermek için kullanırız
        {
            serviceCollection.AddMemoryCache();//IMemorycache in çalışması için otomatik injection yapar microsoft
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();//constracra vermek için önce burda tanımlarız ileride Redise geçersen memory yerine redis yaz yeter(15.gün 1.32.40)
            serviceCollection.AddSingleton<Stopwatch>();//Performance aspect için 
        }
    }
}
