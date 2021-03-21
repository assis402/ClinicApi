using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> InsertUser(User user);

        //Task<string> UpdateUser(User user);

        //Task<string> DeleteUserByCPF(string cpf);

        //Task<User> GetUserByCPF(string cpf);

        //Task<ICollection<User>> GetAllUsersByClinicalUnitId(int ClinicalUnitId);

        //Task<bool> CPFAlreadyUsed(string cpf);
    }
}