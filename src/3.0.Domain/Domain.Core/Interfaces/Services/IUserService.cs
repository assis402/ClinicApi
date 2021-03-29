using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserToLogin(int clinicalUnitId, string taxNumber, string password);
    }
}