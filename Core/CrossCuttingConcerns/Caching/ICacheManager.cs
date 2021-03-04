using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
     public interface ICacheManager//Başka bir Caching kullanabiliriz
    {
        T Get<T>(string key); //ben sana bir key vereyim bana o key e karşılık gelenleri lisetele
        object Get(string key);
        void Add(string key, object value, int duration);//cache gelicek anahtar ,değer ,cache de kalıcak zaman
        bool IsAdd(string key);//Cahce de varmı veri tabanındaki veri ona bakar

        void Remove(string key);
        void RemoveByPattern(string pattern);//sana bir desen vereyim başı sonu önemli değil içinde get olanları mesala kaldır
    }
}
