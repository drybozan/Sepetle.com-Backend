using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object data, int duration);
        bool IsAdd(string key); //cache de var mı diye kontrol eder
        void Remove(string key); //cache den uçurma metotu
        void RemoveByPattern(string pattern); //başı sonu önemli değil içinde category vs. olanları uçur
    }
}
