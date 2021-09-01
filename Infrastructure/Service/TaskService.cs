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
    public class TaskService : ITaskService
    {


        private readonly ITaskRepository _taskRepository;

        private readonly ITasksHistoryRepository _tasksHistoryRepository;
        public TaskService(ITaskRepository taskRepository, ITasksHistoryRepository tasksHistoryRepository)
        {
            _taskRepository = taskRepository;
            _tasksHistoryRepository = tasksHistoryRepository;
        }


        public async Task<TasksHistoryResponseModel> FinishTask(int id)
        {
            //get task from task table
            var task = await _taskRepository.GetByIdAsync(id);
            //create new taskhistory instance
            var taskhistroy = new TasksHistory
            {
                UserId = task.UserId,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Completed = DateTime.Now,
                Remarks = task.Remarks
            };
            //update database
            var newTaskHistory = await _tasksHistoryRepository.AddAsync(taskhistroy);

            //remove task form task table
            var finished = await _taskRepository.DeleteAsync(task);

            var thmodel = new TasksHistoryResponseModel
            {
                TaskId = newTaskHistory.TaskId,
                Title = newTaskHistory.Title,
                Description = newTaskHistory.Description,
                DueDate = newTaskHistory.DueDate,
                Completed = newTaskHistory.Completed,
                Remarks = newTaskHistory.Remarks
            };
            return thmodel;
        }
        public async Task<TaskResponseModel> CreateTask(TaskRequestModel model)
        {
            //create task
            var task = new ApplicationCore.Entities.Task
            {
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Priority = model.Priority,
                Remarks = model.Remarks,
            };
            var createtask = await _taskRepository.AddAsync(task);

            //create responsemodel
            var taskResponseModel = new TaskResponseModel
            {
                Id = createtask.Id,
                UserId = createtask.UserId,
                Title = createtask.Title,
                Description = createtask.Description,
                DueDate = createtask.DueDate,
                Priority = createtask.Priority,
                Remarks = createtask.Remarks
            };

            return taskResponseModel;
            
        }

        public async Task<TaskResponseModel> DeleteTask(int taskId)
        {
            //get task by id
            var task = await _taskRepository.GetByIdAsync(taskId);
            //remove task from table
            var deletedtask = await _taskRepository.DeleteAsync(task);
            var taskResponseModel = new TaskResponseModel
            {
                Id = deletedtask.Id,
                UserId = deletedtask.UserId,
                Title = deletedtask.Title,
                Description = deletedtask.Description,
                DueDate = deletedtask.DueDate,
                Priority = deletedtask.Priority,
                Remarks = deletedtask.Remarks
            };
            return taskResponseModel;
        }

        public async Task<IEnumerable<TaskResponseModel>> ListTasks()
        {
            var tasks = await _taskRepository.ListAllAsync();
            var tasksmodels = new List<TaskResponseModel>();
            foreach (var task in tasks)
            {
                tasksmodels.Add(new TaskResponseModel
                {
                    Id = task.Id,
                    UserId = task.UserId,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Priority = task.Priority,
                    Remarks = task.Remarks
                });
            }
            return tasksmodels;
        }

        public async Task<TaskResponseModel> UpdateTask(TaskUpdateRequestModel model)
        {
            //var task = await _taskRepository.GetByIdAsync(model.Id);

            var updatetask = new ApplicationCore.Entities.Task
            {
                Id = model.Id,
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Priority = model.Priority,
                Remarks = model.Remarks

            };
            var updated = await _taskRepository.UpdateAsync(updatetask);

            var updatedmodel = new TaskResponseModel
            {
                Id = updated.Id,
                UserId = updated.UserId,
                Title = updated.Title,
                Description = updated.Description,
                DueDate = updated.DueDate,
                Priority = updated.Priority,
                Remarks = updated.Remarks
            };
            return updatedmodel;
            //throw new Exception();
        }
    }
}
