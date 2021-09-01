using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(TaskManagementDbContext dbContext): base(dbContext)
        {

        }

        public async Task<IEnumerable<ApplicationCore.Entities.Task>> GetTasksById(int id)
        {
            var tasks = await _dbContext.Tasks.Where(th => th.UserId == id).ToListAsync();
            return tasks;
        }
        public async Task<IEnumerable<TasksHistory>> GetTasksHistoryById(int id)
        {
            var tasksHistories = await _dbContext.TasksHistory.Where(th => th.UserId == id).ToListAsync();
            return tasksHistories;
        }
        public override async Task<User> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new NotFoundException($"No user Found for the id {id}");
            }
            return  user;
        }

        public override async Task<User> UpdateAsync(User user)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if(entity == null)
            {
                throw new NotFoundException("Can not Update, the user does not exist");
            }
            _dbContext.Entry(entity).CurrentValues.SetValues(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        
    }
}
