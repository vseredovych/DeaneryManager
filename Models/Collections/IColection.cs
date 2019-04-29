using Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Collections
{
    public interface IEntityCollection
    {
        void Add(IEntity entity);
        void Update(IEntity entity);
        void Delete(int id);
        int TableCount { get; }
        ObservableCollection<IEntity> GetAll();
    }
}
