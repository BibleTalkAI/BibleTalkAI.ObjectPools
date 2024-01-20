using Microsoft.Extensions.ObjectPool;
using System.Text;

namespace BibleTalkAI.ObjectPools;

public class StringBuilderPool(ObjectPool<StringBuilder> pool) : IStringBuilderPool
{
    public StringBuilder Get() => pool.Get();

    public void Return(StringBuilder instance) => pool.Return(instance);
}
