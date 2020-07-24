using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCentral.Domain.Repository
{
    public interface IUserRepository
    {
        Task<bool> Add(string name, string email, string password);

        Task<bool> Update(IdentityUser user);

        Task<bool> Delete(IdentityUser user);

        Task<IdentityUser> FindById(string id);

        Task<IdentityUser> FindByEmail(string email);

        Task<IdentityUser> Login(string email, string password);
    }
}