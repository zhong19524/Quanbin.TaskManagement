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
    public class TaskRepository : EfRepository<ApplicationCore.Entities.Task>, ITaskRepository
    {

        public TaskRepository(TaskManagementDbContext dbContext):base(dbContext)
        {

        }

        public override async Task<ApplicationCore.Entities.Task> GetByIdAsync (int id)
        {
            var task = await _dbContext.Tasks.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                throw new NotFoundException($"No task Found for the id {id}");
            }
            return task;
        }
        public override async Task<ApplicationCore.Entities.Task> UpdateAsync(ApplicationCore.Entities.Task task)
        {
            var entity = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id);
            if (entity == null)
            {
                throw new NotFoundException("Can not Update, the task does not exist");
            }
            _dbContext.Entry(entity).CurrentValues.SetValues(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        
    }
}
