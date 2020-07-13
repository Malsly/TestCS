using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IUnitOfWork
    {
        IGenericRepository<ShipmentRegistration> ShipmentRegistrationRepository { get; }
        void Save();
        void Dispose();
    }
}
