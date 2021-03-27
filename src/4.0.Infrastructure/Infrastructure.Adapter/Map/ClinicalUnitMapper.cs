using System;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Adapter.Interfaces;
using System.Collections.Generic;
using Application.DTO;

namespace Infrastructure.Adapter.Map
{
    public class ClinicalUnitMapper : IClinicalUnitMapper
    {
        ICollection<ClinicalUnitDTO> ClinicalUnitDTOs { get; set; }

        public ClinicalUnit MapperToEntity(ClinicalUnitDTO ClinicalUnitDTO)
        {
            ClinicalUnit ClinicalUnit = new ClinicalUnit
            (
                ClinicalUnitDTO.CompanyName,
                ClinicalUnitDTO.TaxNumber,
                ClinicalUnitStatus.Registering,
                DateTime.Now,
                DateTime.Now,
                null
            );

            return ClinicalUnit;
        }

        public ICollection<ClinicalUnitDTO> MapperListClinicalUnit(ICollection<ClinicalUnit> ClinicalUnits)
        {
            foreach (var item in ClinicalUnits)
            {
                ClinicalUnitDTO ClinicalUnitDTO = new ClinicalUnitDTO
                {
                    CompanyName = item.CompanyName,
                    TaxNumber = item.TaxNumber
                };

                ClinicalUnitDTOs.Add(ClinicalUnitDTO);
            }

            return ClinicalUnitDTOs;
        }

        public ClinicalUnitDTO MapperToDTO(ClinicalUnit ClinicalUnit)
        {
            ClinicalUnitDTO ClinicalUnitDTO = new ClinicalUnitDTO
            {
                CompanyName = ClinicalUnit.CompanyName,
                TaxNumber = ClinicalUnit.TaxNumber
            };

            return ClinicalUnitDTO;
        }
    }
}
