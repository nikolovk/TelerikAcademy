using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02BitCalculator.Models
{
    public class Units
    {
        public List<string> Bytes = new List<string>()
        {
                "Byte - B",
                "Kilobyte - KB",
                "Megabyte - MB",
                "Gigabyte - GB",
                "Terabyte - TB",
                "Petabyte - PB",
                "Exabyte - EB",
                "Zettabyte - ZB",
                "Yottabyte - YB"
        };

        public List<string> Bits = new List<string>()
        {
                "bit - b",
                "Kilobit - Kb",
                "Megabit - Mb",
                "Gigabit - Gb",
                "Terabit - Tb",
                "Petabit - Pb",
                "Exabit - Eb",
                "Zettabit - Zb",
                "Yottabit - Yb",
        };
        public const int OneByteValue = 8;
        public List<Unit> AllBits { get; set; }
        public List<Unit> AllBytes { get; set; }
        public double BaseNumber { get; set; }
        public int Multiplayer { get; set; }
        public string BaseName { get; set; }
        public void LoadUnits(string baseName, int multiplayer, double baseNumber)
        {
            this.BaseName = baseName;
            this.Multiplayer = multiplayer;
            this.BaseNumber = baseNumber;

            bool isFound = false;
            Unit firstBit = new Unit()
            {
                Name = Bits[0],
                Type = Type.Bit,
                Value = 1
            };
            if (firstBit.Name == baseName)
            {
                isFound = true;
            }
            Unit firstByte = new Unit()
            {
                Name = Bytes[0],
                Type = Type.Byte,
                Value = 1
            };
            if (isFound)
            {
                firstByte.Value = firstBit.Value / OneByteValue;
            }
            else
            {
                firstBit.Value *= OneByteValue;
            }
            if (firstByte.Name == baseName)
            {
                isFound = true;
            }
            this.AllBits = new List<Unit>();
            this.AllBytes = new List<Unit>();
            this.AllBits.Add(firstBit);
            this.AllBytes.Add(firstByte);

            for (int i = 1; i < Bytes.Count; i++)
            {
                Unit bitUnit = new Unit
                {
                    Name = Bits[i],
                    Type = Type.Bit,
                };
                if (!isFound)
                {
                    this.AllBits.ForEach(unit => unit.Value *= multiplayer / OneByteValue);
                    this.AllBytes.ForEach(unit => unit.Value *= multiplayer / OneByteValue);
                    bitUnit.Value = 1;
                }
                else
                {
                    bitUnit.Value = this.AllBits.LastOrDefault().Value / multiplayer;
                }
                this.AllBits.Add(bitUnit);
                if (Bits[i] == baseName)
                {
                    isFound = true;
                }
                Unit byteUnit = new Unit
                {
                    Name = Bytes[i],
                    Type = Type.Byte,
                };
                if (!isFound)
                {
                    this.AllBits.ForEach(unit => unit.Value *= OneByteValue);
                    this.AllBytes.ForEach(unit => unit.Value *= OneByteValue);
                    byteUnit.Value = 1;
                }
                else
                {
                    byteUnit.Value = this.AllBytes.LastOrDefault().Value / multiplayer;
                }
                this.AllBytes.Add(byteUnit);
                if (Bytes[i] == baseName)
                {
                    isFound = true;
                }
            }
        }
    }
}