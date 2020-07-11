using DAL.Abstract;
using DAL_Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class ShipmentRegistrationMapper : IMapper<ShipmentRegistration, ShipmentRegistrationDTO, IGenericRepository<ShipmentRegistration>>
    {
        public IGenericRepository<ShipmentRegistration> repo;

        public ShipmentRegistrationMapper(IGenericRepository<ShipmentRegistration> repo)
        {
            this.repo = repo;
        }

        public ShipmentRegistration DeMap(ShipmentRegistrationDTO dto)
        {
            ShipmentRegistration entity = (ShipmentRegistration)repo.GetByID(dto.Id);
            if (entity == null)
                return new ShipmentRegistration()
                {
                    Id = dto.Id,
                    Date = dto.Date,
                    Organisation = dto.Organisation,
                    City = dto.City,
                    Country = dto.Country,
                    Manager = dto.Manager,
                    Count = dto.Count,
                    Summa = dto.Summa,
                };
            entity.Id = dto.Id;
            entity.Date = dto.Date;
            entity.Organisation = dto.Organisation;
            entity.City = dto.City;
            entity.Country = dto.Country;
            entity.Manager = dto.Manager;
            entity.Count = dto.Count;
            entity.Summa = dto.Summa;
            return entity;
        }

        public ShipmentRegistrationDTO Map(ShipmentRegistration entity)
        {
            return new ShipmentRegistrationDTO()
            {
                Id = entity.Id,
                Date = entity.Date,
                Organisation = entity.Organisation,
                City = entity.City,
                Country = entity.Country,
                Manager = entity.Manager,
                Count = entity.Count,
                Summa = entity.Summa,
            };
        }
    }
}
