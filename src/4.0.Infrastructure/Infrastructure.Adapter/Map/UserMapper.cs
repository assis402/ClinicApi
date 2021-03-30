using System;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Adapter.Interfaces;
using System.Collections.Generic;
using Application.DTO;

namespace Infrastructure.Adapter.Map
{
    public class UserMapper : IUserMapper
    {
        public UserDTO MapperToDTO(User User)
        {
            UserDTO UserDTO = new UserDTO
            {
                Id = User.Id,
                TaxNumber = User.TaxNumber,
                Password = null,
                Name = User.Name,
                Email = User.Email,
                PhoneNumber = User.PhoneNumber,
                Role = User.Role.ToString(),
                ClinicalUnitId = User.ClinicalUnitId
            };

            return UserDTO;
        }
    }
}