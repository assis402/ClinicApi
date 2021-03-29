using System;
using Domain.Core.Interfaces.Services;
using Domain.Core.Interfaces.Repositories;
using Infrastructure.Repository;
using Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class UserService : IUserService
    {

        public async Task<User> GetUserToLogin(int clinicalUnitId, string taxNumber, string password)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                Expression<Func<Patient, bool>> PatientLogin = (p) => p.TaxNumber == taxNumber && p.Password == password;
                Expression<Func<CompanyProfile, bool>> CompanyProfileLogin = (p) => p.TaxNumber == taxNumber && p.Password == password;

                Patient patient = await uow.PatientRepository.FindByExpressionAsync(PatientLogin);

                if (patient == null)
                {
                    CompanyProfile companyProfile = await uow.CompanyRepository.FindByExpressionAsync(CompanyProfileLogin);
                    var user = companyProfile == null ? null : companyProfile;
                    return user;
                }
                else
                {
                    return patient;
                }
            }
        }
    }
}
