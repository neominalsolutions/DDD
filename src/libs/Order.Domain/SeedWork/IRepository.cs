using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.SeedWork
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        void Create(AggregateRoot root);
        void Update(AggregateRoot root);
        void Delete(string Id);
        List<TAggregateRoot> FindAll();
        TAggregateRoot FindById(string Id);
    }
}
