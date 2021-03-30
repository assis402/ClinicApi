using System;
using Domain.Core.Interfaces.Services;
using Infrastructure.Repository;
using Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Application.DTO;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetUserToLogin(UserDTO userDTO)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                Expression<Func<Patient, bool>> PatientLogin = (p) => p.TaxNumber == userDTO.TaxNumber && p.Password == userDTO.Password && p.ClinicalUnitId == userDTO.ClinicalUnitId;
                Expression<Func<CompanyProfile, bool>> CompanyProfileLogin = (c) => c.TaxNumber == userDTO.TaxNumber && c.Password == userDTO.Password && c.ClinicalUnitId == userDTO.ClinicalUnitId;

                Patient patient = await uow.PatientRepository.FindByExpressionAsync(PatientLogin);

                if (patient == null)
                {
                    CompanyProfile companyProfile = await uow.CompanyProfileRepository.FindByExpressionAsync(CompanyProfileLogin);
                    var user = companyProfile == null ? null : companyProfile;
                    return user;
                }

                else
                    return patient;
            }
        }
    }
}
