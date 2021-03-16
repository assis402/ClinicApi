using System;
using Domain.Entities;
using Infrastructure.Adapter.Interfaces;
using System.Collections.Generic;
using Application.DTO;

namespace Infrastructure.Adapter.Map
{
    public class ClinicUnitMapper : IClinicUnitMapper
    {
        ICollection<ClinicUnitDTO> clinicUnitDTOs { get; set; }

        public ClinicUnit MapperToEntity(ClinicUnitDTO clinicUnitDTO)
        {
            ClinicUnit clinicUnit = new ClinicUnit
            (
                clinicUnitDTO.CompanyName,
                clinicUnitDTO.Login,
                clinicUnitDTO.Password,
                DateTime.Now,
                DateTime.Now,
                null
            );

            return clinicUnit;
        }

        public ICollection<ClinicUnitDTO> MapperListClinicUnit(ICollection<ClinicUnit> clinicUnits)
        {
            foreach (var item in clinicUnits)
            {


                ClinicUnitDTO clinicUnitDTO = new ClinicUnitDTO
                {
                    CompanyName = item.CompanyName,
                    Login = item.Login,
                    Password = item.Password
                };



                clinicUnitDTOs.Add(clinicUnitDTO);

            }

            return clinicUnitDTOs;
        }

        public ClinicUnitDTO MapperToDTO(ClinicUnit clinicUnit)
        {

            ClinicUnitDTO clinicUnitDTO = new ClinicUnitDTO
            {
                CompanyName = clinicUnit.CompanyName,
                Login = clinicUnit.Login,
                Password = clinicUnit.Password
            };

            return clinicUnitDTO;

        }
    }
}
