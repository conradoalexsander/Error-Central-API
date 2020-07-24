using ErrorCentral.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCentral.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Add(string name, string email, string password)
        {
            var user = new IdentityUser()
            {
                UserName = name,
                Email = email,
                EmailConfirmed = true
            };

            var addUserProccess = await _userManager.CreateAsync(user, password);

            return addUserProccess.Succeeded;
        }

        public async Task<IdentityUser> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null &&
                await _userManager.CheckPasswordAsync(user, password))
            {
                _userManager.Dispose();
                return user;
            }
            _userManager.Dispose();
            return null;
        }

        public async Task<bool> Update(IdentityUser user)
        {
            var updateUserProccess = await _userManager.UpdateAsync(user);
            _userManager.Dispose();

            return updateUserProccess.Succeeded;
        }

        public async Task<bool> Delete(IdentityUser user)
        {
            var deleteUserProccess = await _userManager.DeleteAsync(user);
            return deleteUserProccess.Succeeded;
        }

        public async Task<IdentityUser> FindByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<IdentityUser> FindById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return user;
            }

            return null;
        }
    }
}