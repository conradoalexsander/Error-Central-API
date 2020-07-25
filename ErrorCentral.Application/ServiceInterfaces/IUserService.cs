using ErrorCentral.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErrorCentral.Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> Add(UserDTO user);

        Task<string> Login(LoginDTO login);

        IdentityResult Update(UserIdDTO user);

        Task<bool> Delete(string id);

        List<UserIdDTO> SelectAll();

        UserIdDTO FindByEmail(string email);
    }
}