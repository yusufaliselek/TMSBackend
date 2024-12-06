using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystemBackend.DataAccess;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects;
using TaskManagementSystemBackend.DataAccess.Entities;
using TaskManagementSystemBackend.DataAccess.IServices;

namespace TaskManagementSystemBackend.Business.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TaskService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TaskDto> GetTaskByIdAsync(int taskId)
        {
            try
            {
                var task = await _context.Tasks
                    .Include(t => t.User)
                    .FirstOrDefaultAsync(t => t.Id == taskId && !t.IsDeleted);

                if (task == null)
                    return null;

                return _mapper.Map<TaskDto>(task);
            }
            catch (Exception ex)
            {
                throw new Exception($"Görev getirilirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            try
            {
                var tasks = await _context.Tasks
                    .Where(t => !t.IsDeleted)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<TaskDto>>(tasks);
            }
            catch (Exception ex)
            {
                throw new Exception($"Tüm görevler alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto)
        {
            try
            {
                var task = _mapper.Map<TaskBase>(createTaskDto);
                task.CreatedAt = DateTime.Now;

                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();

                return _mapper.Map<TaskDto>(task);
            }
            catch (Exception ex)
            {
                throw new Exception($"Görev oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<TaskDto> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(taskId);
                if (task == null || task.IsDeleted)
                    return null;

                _context.Tasks.Update(_mapper.Map<TaskBase>(updateTaskDto));
                await _context.SaveChangesAsync();

                return _mapper.Map<TaskDto>(task);
            }
            catch (Exception ex)
            {
                throw new Exception($"Görev güncellenirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(taskId);
                if (task == null || task.IsDeleted)
                    return false;

                task.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Görev silinirken bir hata oluştu: {ex.Message}");
            }
        }

        public Task<IEnumerable<TaskDto>> GetTasksByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
