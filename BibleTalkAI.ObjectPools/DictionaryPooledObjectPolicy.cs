using Microsoft.Extensions.ObjectPool;

namespace BibleTalkAI.ObjectPools;

public class DictionaryPooledObjectPolicy : IPooledObjectPolicy<Dictionary<string, string?>>
{
    private const int Capacity = 23;

    public Dictionary<string, string?> Create() => new(Capacity);

    public bool Return(Dictionary<string, string?> obj)
    {
        obj.Clear();
        return true;
    }
}
