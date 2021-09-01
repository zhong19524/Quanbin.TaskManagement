using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<TasksHistoryResponseModel>> GetTasksHishtoryById(int id);

        Task<IEnumerable<TaskResponseModel>> GetTasksById(int id);

        Task<UserResponseModel> AddUser(UserCreateRequestModel model);

        Task<UserResponseModel> UpdateUser(UserUpdateRequestModel model);
        Task<UserResponseModel> DeleteUser(int id);

        Task<IEnumerable<UserResponseModel>> ListUsers();

    }
}
