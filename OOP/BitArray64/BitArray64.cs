using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    public class BitArray64 : IEnumerable<int>
    {
        public ulong Number { get; private set; }

        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public int this[int index]
        {
            get
            {
                int num = (int)(this.Number >> index) % 10;
                return num & 1;
            }
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;
            BitArray64 objAs64 = obj as BitArray64;
            if (objAs64 != null)
            {
                isEqual = objAs64.Number.Equals(this.Number);
            }
            return isEqual;
        }
        public override int GetHashCode()
        {
            return (int)(this.Number % 1000) ^ (int)(this.Number % 1000);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return this[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            if (first.Number == second.Number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            if (first.Number != second.Number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
