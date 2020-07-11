using BL.Abstract.ResultWrappers;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IShipmentRegistrationService : IGenericService<ShipmentRegistrationDTO>
    {
        IDataResult<List<ShipmentRegistrationDTO>> GetAll();
        IDataResult<ShipmentRegistrationDTO> Get(int id);
        IResult Add(ShipmentRegistrationDTO dto);
        IResult Update(ShipmentRegistrationDTO dto);
        IResult Delete(int id);
    }
}
