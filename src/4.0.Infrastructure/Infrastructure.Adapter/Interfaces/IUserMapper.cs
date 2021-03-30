using System;
using Domain.Entities;
using System.Collections.Generic;
using Application.DTO;

namespace Infrastructure.Adapter.Interfaces
{
    public interface IUserMapper
    {
        UserDTO MapperToDTO(User User);
    }
}