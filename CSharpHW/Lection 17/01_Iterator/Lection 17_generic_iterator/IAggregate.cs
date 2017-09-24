namespace Lection_17_generic_iterator
{
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }
}
