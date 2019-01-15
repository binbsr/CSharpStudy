using System;
using System.Collections.Generic;

namespace _6_0
{
    public class Auto_Properties
    {        
        public string Name { get; private set; }

        //Read-only auto-properties (creating immutable types), can only be set in body of a constructor
        public string Address { get; }
        public DateTime DeliveryDate { get; }

        //Auto-property initializers
        public ICollection<double> Grades { get; } = new List<double>();
        public AgeGroup Group { get; set; } = AgeGroup.Adult;
    }

    public enum AgeGroup
    {
        Child,
        Adult,
        Old
    }
}
