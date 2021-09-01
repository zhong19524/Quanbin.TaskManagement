using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ITaskService
    {

        Task<TaskResponseModel> CreateTask(TaskRequestModel model);

        Task<TaskResponseModel> DeleteTask(int taskId);

        Task<TaskResponseModel> UpdateTask(TaskUpdateRequestModel model);

        Task<IEnumerable<TaskResponseModel>> ListTasks();

        Task<TasksHistoryResponseModel> FinishTask(int id);
    }
}
