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
    public class TasksHistoryRepository:EfRepository<TasksHistory>, ITasksHistoryRepository
    {
        public TasksHistoryRepository(TaskManagementDbContext dbContext) :base(dbContext)
        {

        }

        public override async Task<TasksHistory> GetByIdAsync(int id)
        {
            var taskhistory = await _dbContext.TasksHistory.FirstOrDefaultAsync(th => th.TaskId == id);

            if (taskhistory == null)
            {
                throw new NotFoundException($"No taskhistory Found for the id {id}");
            }
            return taskhistory;
        }

        public override async Task<TasksHistory> UpdateAsync(TasksHistory th)
        {
            var entity = await _dbContext.TasksHistory.FirstOrDefaultAsync(t => t.TaskId == th.TaskId);
            if (entity == null)
            {
                throw new NotFoundException("Can not Update, the user does not exist");
            }
            _dbContext.Entry(entity).CurrentValues.SetValues(th);
            await _dbContext.SaveChangesAsync();
            return th;
        }
    }
}
