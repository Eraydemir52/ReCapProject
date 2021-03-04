using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Core.Aspects.AutoFac.Caching
{
    public class CacheAspect : MethodInterception//Olay burda oluşturulan keye göre mesala get all daha önce bu keyle kullanılmışsa cache den al yoksa veri tabanından al ve cache ekle
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)//60 dk cache de durur
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();//Hangi cache managere kullanıcamı verir
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//Metodu bul namespace I..service verir,çalış metod ismi 
            var arguments = invocation.Arguments.ToList();//metodun parametrelerini listeye çevirir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//Parametreleri birleştirir ,ayırır ona göre key oluşturur
            //metodun para metre değeri varsa tek getall ekler vermezsen null girer
            if (_cacheManager.IsAdd(key))//daha önce bu keyde varsa
            {
                invocation.ReturnValue = _cacheManager.Get(key);//sen metodu hiç çalıştırmadan geri dön ve cache den al
                return;
            }
            invocation.Proceed();//yoksa veri tabanından metodu çalıştırarakçağır
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//ve cache ekle
        }
    }
}
