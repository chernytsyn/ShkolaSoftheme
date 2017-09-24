using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection15_generics
{
    class TwoWayListGeneric<TElement>
                      
    {
        public TwoWayListGeneric<TElement> _previous { get; private set; }
        public TwoWayListGeneric<TElement> _next { get; private set; }

        public int Length { get; private set; }

        public TElement value { get; private set; }

        public TwoWayListGeneric() 
            : this(default(TElement))
        { }

        public TwoWayListGeneric(TElement value, TwoWayListGeneric<TElement> previous = null, TwoWayListGeneric<TElement> next = null)
        {
            this.value = value;
            this._previous = previous;
            this._next = next;
            this.Length = 1;
        }

        public void Add(TElement value)
        {
            var temp = this;

            while (temp._next != null)
            {
                temp = temp._next;
            }

            temp._next = new TwoWayListGeneric<TElement>(value, previous: temp);
            Length++;
        }

        public void Delete(TElement valueForDeleting)
        {
            // TODO
            var temp = this.FindHead();

            while (temp != null)
            {
                if (temp.value.Equals(valueForDeleting))
                {
                    if (this.value.Equals(valueForDeleting))
                    {
                        this.value = this._next.value;
                        this._next = this._next._next;
                        this._previous = null;
                        Length--;
                        break;
                    } 

                    if (temp._previous != null)
                    {
                        temp._previous._next = temp._next;
                    }

                    if (temp._next != null)
                    {
                        temp._next._previous = temp._previous;
                    }

                    Length--;
                    break;
                }
                else
                {
                    if (temp._next != null)
                    {
                        temp = temp._next;
                    }
                    else
                    {
                        Console.WriteLine("There is no such value = {0} in sorted list",value);
                        break;
                    }  
                }
            }
        }

        public void PrintList()
        {
            var temp = this.FindHead();

            while (temp._next != null)
            {
                Console.WriteLine("type:{0}, value = {1}", temp.GetType(), temp.value.ToString());
                temp = temp._next;

                if (temp._next == null)
                {
                    Console.WriteLine("type:{0}, value = {1}", temp.GetType(), temp.value.ToString());
                }
            }
        }

        public bool IsElementExistInList(TElement value) 
        {
            var temp = this.FindHead();

            while (temp._next != null)
            {
                if (temp.value.Equals(value))
                {
                    return true;
                }
                else
                {
                    if (temp._next != null)
                    {
                        temp = temp._next;
                    }  
                }
            }
            return false;
        }

        public TElement[] ToArray()
        {
            var size = this.Length;

            var temp = this.FindHead();

            var array = new TElement[size];
            var index = 0;

            while (temp != null)
            {
                array[index] = temp.value;
                temp = temp._next;
                index++;
            }
            return array;
        }

        private TwoWayListGeneric<TElement> FindHead()
        {
            var temp = this;

            while (temp._previous != null)
            {
                temp = temp._previous;
            }
            return temp;
        }
    }
}
