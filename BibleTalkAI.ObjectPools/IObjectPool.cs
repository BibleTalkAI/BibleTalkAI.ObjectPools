namespace BibleTalkAI.ObjectPools;

public interface IObjectPool<T>
{
    T Get();

    void Return(T instance);
}
