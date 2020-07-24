using ErrorCentral.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ErrorCentral.Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> Add(UserDTO user);

        Task<string> Login(LoginDTO login);

        Task<bool> Update(UserIdDTO user);

        Task<bool> Delete(string id);

        UserIdDTO FindByEmail(string email);
    }
}