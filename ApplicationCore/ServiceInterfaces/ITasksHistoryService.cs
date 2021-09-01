using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ITasksHistoryService
    {
        Task<TasksHistoryResponseModel> CreateTaskHistory(TasksHistoryRequestModel model);

        Task<TasksHistoryResponseModel> DeleteTaskHistory(int taskHistoryId);

        Task<TasksHistoryResponseModel> UpdateTaskHistory(TasksHistoryUpdateRequestModel model);

        Task<IEnumerable<TasksHistoryResponseModel>> ListTasksHistories();
    }
}
