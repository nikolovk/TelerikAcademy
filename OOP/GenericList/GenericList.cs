using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class GenericList<T>
    {
        //Fields
        private T[] list;
        private uint count;

        //Constructor
        public GenericList(uint size)
        {
            if (size > 0)
            {
                this.list = new T[size];
                this.count = 0;
            }
            else
            {
                throw new ArgumentOutOfRangeException("size");
            }
        }
        //Properties
        public uint Count
        {
            get
            {
                return this.count;
            }
        }
        //Indexer
        public T this[uint index]
        {
            get
            {
                if (index >= this.count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return this.list[index];
            }
        }
        //Methods
        private void DoubleSize()
        {
            int currentSize = this.list.Length;
            T[] tempArray = new T[currentSize * 2];
            Array.Copy(list, tempArray, currentSize);
            this.list = tempArray;
        }
        public void AddElement(T value)
        {
            if (this.count == this.list.Length)
            {
                DoubleSize();
            }
            list[this.count] = value;
            this.count++;
        }
        public T ReadElement(uint index)
        {
            T value;
            if (index < this.count)
            {
                value = list[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return value;
        }
        public void RemoveElement(uint index)
        {
            if (index < this.count)
            {
                for (uint i = index; i < this.count - 1; i++)
                {
                    this.list[i] = this.list[i + 1];
                }
                this.list[this.count - 1] = default(T);
                this.count--;
            }
            else
            {
                throw new ArgumentOutOfRangeException("index");
            }
        }
        public void InsertAtPosition(uint index, T value)
        {
            if (index < this.count)
            {
                if (this.count == this.list.Length)
                {
                    DoubleSize();
                }
                T[] tempArray = new T[this.count - index];
                for (uint i = this.count; i > index; i--)
                {
                    this.list[i] = this.list[i - 1];
                }
                this.list[index] = value;
                this.count++;
            }
            else
            {
                throw new ArgumentOutOfRangeException("index");
            }
        }
        public void ClearList()
        {
            this.count = 0;
        }
        //Search element by its value, if missing return -1
        public int SearchByValue(T value)
        {
            int index = -1;
            for (int i = 0; i < this.count; i++)
            {
                if (value.Equals(this.list[i]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < this.count; i++)
            {
                text.Append(string.Format("[{0}]={1};", i, this.list[i]));
            }
            return text.ToString();
        }
    }
}
