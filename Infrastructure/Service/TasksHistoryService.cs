using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class TasksHistoryService : ITasksHistoryService
    {

        private readonly ITasksHistoryRepository _tasksHistoryRepository;
        public TasksHistoryService(ITasksHistoryRepository taskshHistoryRepository)
        {
            _tasksHistoryRepository = taskshHistoryRepository;
        }
      
    public async Task<TasksHistoryResponseModel> CreateTaskHistory(TasksHistoryRequestModel model)
        {
            //create task
            var taskhistory = new TasksHistory
            {
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Completed = model.Completed,
            Remarks = model.Remarks
        };
        var createtaskhistory = await _tasksHistoryRepository.AddAsync(taskhistory);

        //create responsemodel
        var taskHistoryResponseModel = new TasksHistoryResponseModel
        {
            TaskId = createtaskhistory.TaskId,
            UserId = createtaskhistory.UserId,
            Title = createtaskhistory.Title,
            Description = createtaskhistory.Description,
            DueDate = createtaskhistory.DueDate,
            Completed = createtaskhistory.Completed,
            Remarks = createtaskhistory.Remarks
        };

        return taskHistoryResponseModel;
    }

        public async Task<TasksHistoryResponseModel> DeleteTaskHistory(int taskHistoryId)
        {
            //get task by id
            var taskhistory = await _tasksHistoryRepository.GetByIdAsync(taskHistoryId);
            //remove task from table
            var deletedtaskhistory = await _tasksHistoryRepository.DeleteAsync(taskhistory);

            var taskhistoryResponseModel = new TasksHistoryResponseModel
            {
                TaskId = deletedtaskhistory.TaskId,
                UserId = deletedtaskhistory.UserId,
                Title = deletedtaskhistory.Title,
                Description = deletedtaskhistory.Description,
                DueDate = deletedtaskhistory.DueDate,
                Completed = deletedtaskhistory.Completed,
                Remarks = deletedtaskhistory.Remarks     
            };
            return taskhistoryResponseModel;    
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<TasksHistoryResponseModel>> ListTasksHistories()
        {
            var taskshisotries = await _tasksHistoryRepository.ListAllAsync();
            var taskshistoriesmodels = new List<TasksHistoryResponseModel>();
            foreach (var taskhistory in taskshisotries)
            {
                taskshistoriesmodels.Add(new TasksHistoryResponseModel
                {
                    TaskId = taskhistory.TaskId,
                    UserId = taskhistory.UserId,
                    Title = taskhistory.Title,
                    Description = taskhistory.Description,
                    DueDate = taskhistory.DueDate,
                    Completed = taskhistory.Completed,
                    Remarks = taskhistory.Remarks
                });
            }
            return taskshistoriesmodels;    
        }

        public async Task<TasksHistoryResponseModel> UpdateTaskHistory(TasksHistoryUpdateRequestModel model)
        {
            //var taskhistory = await _tasksHistoryRepository.GetByIdAsync(model.TaskId);

            var updatetaskhistory = new TasksHistory
            {
                TaskId = model.TaskId,
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Completed = model.Completed,
                Remarks = model.Remarks

            };
            var updated = await _tasksHistoryRepository.UpdateAsync(updatetaskhistory);

            var updatedmodel = new TasksHistoryResponseModel
            {
                TaskId = updated.TaskId,
                UserId = updated.UserId,
                Title = updated.Title,
                Description = updated.Description,
                DueDate = updated.DueDate,
                Completed = updated.Completed,
                Remarks = updated.Remarks
            };
            return updatedmodel;

        }
    }
}
