using Microsoft.EntityFrameworkCore;
using P1TaskFlow.Models;
using P1TaskFlow.DataAcess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P1TaskFlow.DataAcess.Tasks
{
    public class TodoTaskGroupRepository
    {
        private readonly DatabaseContext _context;

        public TodoTaskGroupRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<TodoTaskGropup>> GetTaskGroupsAsync()
        {
            return await _context.todoTaskGropups.ToListAsync();
        }

        public async Task<TodoTaskGropup> GetTaskGroupByIdAsync(int id)
        {
            return await _context.todoTaskGropups.FindAsync(id);
        }

        public async Task<TodoTaskGropup> CreateTaskGroupAsync(TodoTaskGropup taskGroup)
        {
            _context.todoTaskGropups.Add(taskGroup);
            await _context.SaveChangesAsync();
            return taskGroup;
        }

        public async Task<TodoTaskGropup> UpdateTaskGroupAsync(TodoTaskGropup taskGroup)
        {
            _context.Entry(taskGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return taskGroup;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.todoTaskGropups.Any(t => t.Id == taskGroup.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<TodoTaskGropup> DeleteTaskGroupAsync(int id)
        {
            var taskGroup = await _context.todoTaskGropups.FindAsync(id);
            if (taskGroup != null)
            {
                _context.todoTaskGropups.Remove(taskGroup);
                await _context.SaveChangesAsync();
            }
            return taskGroup;
        }
    }
}
