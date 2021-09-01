using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        //private readonly ITaskRepository _taskRepository;

        //private readonly ITasksHistoryRepository _taskHistoryRepository;

        public UserService(IUserRepository userRepository)//, ITaskRepository taskRepository, ITasksHistoryRepository taskHistoryRepository)
        {
            _userRepository = userRepository;
           // _taskRepository = taskRepository;
            //_taskHistoryRepository = taskHistoryRepository;
        }

        public async Task<UserResponseModel> AddUser(UserCreateRequestModel model)
        {
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if (dbUser != null)
            {
                throw new ConflictException("Email already exist");
            }

            //generate a unique salt/hashedpassword
            //var salt = GenerateSalt();
            //var hashedpassword = 
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
                Fullname = model.Fullname,
                Mobileno = model.Mobileno
            };

            var adduser = await _userRepository.AddAsync(user);

            var usermodel = new UserResponseModel
            {
                Id = adduser.Id,
                Email = adduser.Email,
                Fullname = adduser.Fullname,
                Mobileno = adduser.Mobileno
            };

            return usermodel;
        }
        //

        public async Task<UserResponseModel> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var deleteduser = await _userRepository.DeleteAsync(user);
            var usermodel = new UserResponseModel
            {
                Id = deleteduser.Id,
                Email = deleteduser.Email,
                Fullname = deleteduser.Fullname,
                Mobileno = deleteduser.Mobileno
            };
            return usermodel;
        }

        public async Task<IEnumerable<TaskResponseModel>> GetTasksById(int id)
        {
            var tasks = await _userRepository.GetTasksById(id);
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

        public async Task<IEnumerable<TasksHistoryResponseModel>> GetTasksHishtoryById(int id)
        {
            var histories = await _userRepository.GetTasksHistoryById(id);
            var historymodels = new List<TasksHistoryResponseModel>();
            foreach (var history in histories)
            {
                historymodels.Add(new TasksHistoryResponseModel
                {
                    TaskId = history.TaskId,
                    Title = history.Title,
                    Description = history.Description,
                    DueDate = history.DueDate,
                    Completed = history.Completed,
                    Remarks = history.Remarks
                });
            }
            return historymodels;
        }

        public async Task<IEnumerable<UserResponseModel>> ListUsers()
        {
            var users = await _userRepository.ListAllAsync();
            var usersmodels = new List<UserResponseModel>();
            foreach (var user in users)
            {
                usersmodels.Add(new UserResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Fullname = user.Fullname,
                    Mobileno = user.Mobileno
                });
            }
            return usersmodels;
        }

        public async Task<UserResponseModel> UpdateUser(UserUpdateRequestModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);

            var updateuser = new User
            {
                Id =user.Id,
                Email = model.Email,
                Password = model.Password,
                Fullname = model.Fullname,
                Mobileno = model.Mobileno

            };
            var updated = await _userRepository.UpdateAsync(updateuser);

            var updatedmodel = new UserResponseModel
            {
                Id = updated.Id,
                Email = updated.Email,
                Fullname = updated.Fullname,
                Mobileno = updated.Mobileno
            };
            return updatedmodel;



        }

       
    }
}
