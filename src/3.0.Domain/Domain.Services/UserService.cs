using System;
using Domain.Core.Interfaces.Services;
using Domain.Core.Interfaces.Repositories;
using Infrastructure.Repository;
using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        /*public async Task<User> GetUserByCPF(int cpf)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                return await uow.UserRepository.FindByExpressionAsync();                                                                                                                                                
            }
        }*/

        public async Task<string> InsertUser(User user)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                await uow.UserRepository.AddAsync(user);
                await uow.Commit();                                                                                                                                                                 
                return "Ok";
            }
        }
    }
}
