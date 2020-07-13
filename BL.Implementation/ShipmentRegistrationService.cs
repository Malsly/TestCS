using BL.Abstract;
using BL.Abstract.ResultWrappers;
using BL.Implementation.ResultWrappers;
using DAL.Abstract;
using DAL.Implementation;
using DAL.Implementation.Mappers;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Implementation
{
    public class ShipmentRegistrationService : IShipmentRegistrationService
    {
        readonly IMapper<ShipmentRegistration, ShipmentRegistrationDTO, IGenericRepository<ShipmentRegistration>> Mapper;
        readonly IGenericRepository<ShipmentRegistration> Repo;
        readonly IUnitOfWork UoW;
        public ShipmentRegistrationService()
        {
            UoW = new UnitOfWork();
            Repo = UoW.ShipmentRegistrationRepository;
            Mapper = new ShipmentRegistrationMapper(Repo);
        }

        public IDataResult<List<ShipmentRegistrationDTO>> GetAll()
        {
            return new DataResult<List<ShipmentRegistrationDTO>>()
            {
                Data = Repo.Get().Select(e => Mapper.Map(e)).ToList(),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IDataResult<ShipmentRegistrationDTO> Get(int id)
        {
            return new DataResult<ShipmentRegistrationDTO>()
            {
                Data = Mapper.Map(Repo.GetByID(id)),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Add(ShipmentRegistrationDTO dto)
        {
            Repo.Insert(Mapper.DeMap(dto));
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Update(ShipmentRegistrationDTO dto)
        {
            Repo.Update(Mapper.DeMap(dto));
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Delete(int id)
        {
            Repo.Delete(id);
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }
        public void Save()
        {
            UoW.Save();
        }
    }
}
