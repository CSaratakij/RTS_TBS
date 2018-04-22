namespace LD41
{
    public interface IStatus<T>
    {
        bool IsEmpty { get; }
        void FullRestore();
        void Clear();
        void Restore(T value);
        void Remove(T value);
    }
}
