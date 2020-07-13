using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Implementation;
using DAL.Abstract;

namespace DAL.Implementation
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private TestCSContext context = new TestCSContext();
        private IGenericRepository<ShipmentRegistration> shipmentRegistrationRepository;
        
        public IGenericRepository<ShipmentRegistration> ShipmentRegistrationRepository
        {
            get
            {

                if (this.shipmentRegistrationRepository == null)
                {
                    this.shipmentRegistrationRepository = new GenericRepository<ShipmentRegistration>(context);
                }
                return shipmentRegistrationRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
