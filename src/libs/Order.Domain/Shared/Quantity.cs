using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Shared
{
    public class Quantity : ValueObject
    {
        public Quantity(int value, string unit)
        {
            Value = value;
            Unit = unit;
        }

        public int Value { get; init; }
        public string Unit { get; init; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Unit;
        }
    }
}
