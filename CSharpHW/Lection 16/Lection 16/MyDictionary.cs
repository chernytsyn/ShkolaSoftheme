using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_16
{
    class MyDictionary<TKey,TValue>
    {
        public ValueWrapper[] Dictionary { get; private set; }

        MyDictionary() { }

        public MyDictionary(TKey key,TValue value)
        {
            var wrapper = new ValueWrapper(key, value);
            this.Dictionary = new ValueWrapper[] { wrapper };
        }

        public void Add(TKey key, TValue value)
        {
            var wrapper = new ValueWrapper(key, value);
            for (int i = 0; i < Dictionary.Length; i++)
            {
                if (Dictionary[i].CheckKeys(wrapper))
                {
                    Console.WriteLine("Keys are matched, this value ({0} : {1}) won't be added \n",key,value);
                    return;
                }
            }
            var temp = new ValueWrapper[Dictionary.Length + 1];

            for (var i = 0; i < temp.Length - 1; i++)
            {
                temp[i] = Dictionary[i];
            }

            temp[temp.Length - 1] = wrapper;

            this.Dictionary = temp;
        }

        public void Remove(TKey key)
        {
            var temp = new ValueWrapper(key, default(TValue));
            try
            {
                var indexForRemove = GetIndex(temp);
                var tempArray = new ValueWrapper[Dictionary.Length - 1];
                for (int i = 0; i < Dictionary.Length - 1; i++)
                {
                    if (i < indexForRemove)
                    {
                        tempArray[i] = Dictionary[i];
                    }
                    else
                    {
                        tempArray[i] = Dictionary[i + 1];
                    }
                }
                this.Dictionary = tempArray;
            }
            catch (Exception) { }

        }

        public int GetIndex(ValueWrapper value)
        {
            for (var i = 0; i < Dictionary.Length; i++)
            {
                if (Dictionary[i].Key.Equals(value.Key))
                {
                    return i;
                }
            }
            throw new Exception();
        }

        public void PrintDictionary()
        {
            Console.WriteLine("Printing dictionary::");
            for (var i = 0; i < Dictionary.Length; i++)
            {
                Console.WriteLine("{0} : {1}",i , Dictionary[i].GetValue());
            }
        }

        public class ValueWrapper
        {
            public TKey Key { get; private set; }
            public TValue Value { get; private set; }

            public ValueWrapper(TKey key, TValue value)
            {
                this.Key = key;
                this.Value = value;
            }

            public bool CheckKeys(ValueWrapper obj)
            {
                if (this.Key.GetHashCode().Equals(obj.Key.GetHashCode()))
                {
                    return true;
                }
                else return false;
            }

            public bool Equals(ValueWrapper obj)
            {
                if (this.Key.GetHashCode().Equals(obj.Key.GetHashCode()))
                {
                    if (this.Key.Equals(obj.Key) && this.Value.Equals(obj.Value))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }

            public override int GetHashCode()
            {
                return this.Key.GetHashCode();
            }

            public string GetValue()
            {
                var temp = "Key: " + this.Key + ",  Value: " + this.Value + ";";
                return temp;
            }

        }
        
    }
    
}
