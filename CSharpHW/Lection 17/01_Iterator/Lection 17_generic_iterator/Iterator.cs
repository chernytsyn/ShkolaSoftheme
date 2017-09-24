namespace Lection_17_generic_iterator
{
    public class Iterator<Type> : IIterator<Type>
    {
        private readonly Aggregate<Type> _aggregate;
        private int _current;

        public Iterator(Aggregate<Type> aggregate)
        {
            _aggregate = aggregate;
        }

        public Type CurrentItem()
        {
            return _aggregate[_current];
        }

        public Type First()
        {
            return _aggregate[0];
        }

        public bool IsDone()
        {
            return _current >= _aggregate.Count;
        }

        public Type Next()
        {
            Type ret = default(Type);

            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }
    }
}
