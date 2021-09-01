using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository: IAsyncRepository<User>
    {
        Task<IEnumerable<ApplicationCore.Entities.Task>> GetTasksById(int id);
        Task<IEnumerable<TasksHistory>> GetTasksHistoryById(int id);

        Task<User> GetUserByEmail(string email);
    }
}
