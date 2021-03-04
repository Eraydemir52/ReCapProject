using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
  public  interface ICoreModule//bağımlılıkları yüklemek için metod(IHttp...falan)
    {
        void Load(IServiceCollection serviceCollection);//start uptaki işi yapıcağı için IServiceCollecition verilir
    }
}
