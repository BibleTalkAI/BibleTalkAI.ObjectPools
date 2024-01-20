using Microsoft.Extensions.ObjectPool;

namespace BibleTalkAI.ObjectPools;

public class DictionaryPool(ObjectPool<Dictionary<string, string?>> pool) : IDictionaryPool
{
    public Dictionary<string, string?> Get() => pool.Get();

    public void Return(Dictionary<string, string?> instance) => pool.Return(instance);
}
