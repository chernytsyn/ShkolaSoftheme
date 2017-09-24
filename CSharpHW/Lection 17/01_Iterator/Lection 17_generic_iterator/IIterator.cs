namespace Lection_17_generic_iterator
{
    public interface IIterator<T>
    {
        T First();

        T Next();

        bool IsDone();

        T CurrentItem();
    }
}
