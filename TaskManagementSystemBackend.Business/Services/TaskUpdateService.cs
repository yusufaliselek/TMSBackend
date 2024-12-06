using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystemBackend.DataAccess;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects;
using TaskManagementSystemBackend.DataAccess.Entities;
using TaskManagementSystemBackend.DataAccess.IServices;

namespace TaskManagementSystemBackend.Business.Services
{
    public class TaskUpdateService : ITaskUpdateService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TaskUpdateService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TaskUpdateDto> GetTaskUpdateByIdAsync(int taskUpdateId)
        {
            try
            {
                var taskUpdate = await _context.TaskUpdates
                    .Where(t => t.Id == taskUpdateId && !t.IsDeleted)
                    .FirstOrDefaultAsync();

                if (taskUpdate == null)
                    throw new KeyNotFoundException("Task güncellemesi bulunamadı.");

                return _mapper.Map<TaskUpdateDto>(taskUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Task güncellemesi alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IEnumerable<TaskUpdateDto>> GetAllTaskUpdatesAsync()
        {
            try
            {
                var taskUpdates = await _context.TaskUpdates
                    .Where(t => !t.IsDeleted)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<TaskUpdateDto>>(taskUpdates);
            }
            catch (Exception ex)
            {
                throw new Exception($"Task güncellemeleri alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<TaskUpdateDto> CreateTaskUpdateAsync(CreateTaskUpdateDto createTaskUpdateDto)
        {
            try
            {
                var taskUpdate = _mapper.Map<TaskUpdate>(createTaskUpdateDto);
                await _context.TaskUpdates.AddAsync(taskUpdate);
                await _context.SaveChangesAsync();

                return _mapper.Map<TaskUpdateDto>(taskUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Task güncellemesi oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<TaskUpdateDto> UpdateTaskUpdateAsync(int taskUpdateId, UpdateTaskUpdateDto updateTaskUpdateDto)
        {
            try
            {
                var taskUpdate = await _context.TaskUpdates
                    .FirstOrDefaultAsync(t => t.Id == taskUpdateId && !t.IsDeleted);

                if (taskUpdate == null)
                    throw new KeyNotFoundException("Task güncellemesi bulunamadı.");

                _context.TaskUpdates.Update(_mapper.Map(updateTaskUpdateDto, taskUpdate));
                await _context.SaveChangesAsync();

                return _mapper.Map<TaskUpdateDto>(taskUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Task güncellemesi güncellenirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<bool> DeleteTaskUpdateAsync(int taskUpdateId)
        {
            try
            {
                var taskUpdate = await _context.TaskUpdates
                    .FirstOrDefaultAsync(t => t.Id == taskUpdateId && !t.IsDeleted);

                if (taskUpdate == null)
                    throw new KeyNotFoundException("Task güncellemesi bulunamadı.");

                taskUpdate.IsDeleted = true;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Task güncellemesi silinirken bir hata oluştu: {ex.Message}");
            }
        }

    }
}
