using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Shared
{
    public class Money : ValueObject
    {
        // Immutable Types init aşamasında set ettik
        public Money(decimal amount, string currency)
        {
            Amount = amount;

            ArgumentNullException.ThrowIfNull(currency, nameof(currency));

            Currency = currency.Trim();
        }

        public decimal Amount { get; init; }
        public string Currency { get; init; }

        public static Money Zero()
        {
            return new Money(0,"TL");
        }

        // iki nesne eşitliğinde değeri yuvarlayı 2 küsüratlı olarak eşitlik kontrolü yapsın diye yaptık
        // bunu test edelim.
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Math.Round(Amount,2);
            yield return Currency == string.Empty ? "TL": Currency;
        }
    }
}
