using ClinicApi.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ClinicApi.Domain.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> InsertUser(User user);

        Task<string> UpdateUser(User user);

        Task<User> GetUserByCPF(string cpf);

        Task<IEnumerable<User>> GetAllUsers();

        Task<string> DeleteUserByCPF(string cpf);

        //Task<bool> CPFAlreadyUsed(string cpf);
    }
}