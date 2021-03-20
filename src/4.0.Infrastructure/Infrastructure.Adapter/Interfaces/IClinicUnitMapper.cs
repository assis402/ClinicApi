using System;
using Domain.Entities;
using System.Collections.Generic;
using Application.DTO;

namespace Infrastructure.Adapter.Interfaces
{
    public interface IClinicUnitMapper
    {
        ClinicUnit MapperToEntity(ClinicUnitDTO clinicUnitDTO);

        ICollection<ClinicUnitDTO> MapperListClinicUnit(ICollection<ClinicUnit> ClinicUnits);

        ClinicUnitDTO MapperToDTO(ClinicUnit clinicUnit);
    }
}