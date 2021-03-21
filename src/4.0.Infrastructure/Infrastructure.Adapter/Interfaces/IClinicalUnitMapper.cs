using System;
using Domain.Entities;
using System.Collections.Generic;
using Application.DTO;

namespace Infrastructure.Adapter.Interfaces
{
    public interface IClinicalUnitMapper
    {
        ClinicalUnit MapperToEntity(ClinicalUnitDTO ClinicalUnitDTO);

        ICollection<ClinicalUnitDTO> MapperListClinicalUnit(ICollection<ClinicalUnit> ClinicalUnits);

        ClinicalUnitDTO MapperToDTO(ClinicalUnit ClinicalUnit);
    }
}