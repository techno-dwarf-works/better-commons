namespace Better.Commons.Runtime.Interfaces
{
    public interface ICopyable<T>
    {
        public void Copy(T source);
    }

    public interface ICopyable : ICopyable<object>
    {
    }
}