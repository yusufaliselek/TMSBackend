using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystemBackend.DataAccess;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Task;
using TaskManagementSystemBackend.DataAccess.Entities;
using TaskManagementSystemBackend.DataAccess.IServices;

namespace TaskManagementSystemBackend.Business.Services
{
    public class OrganizationProjectTaskService : IOrganizationProjectTaskService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrganizationProjectTaskService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrganizationProjectTaskDto> GetTaskByIdAsync(int taskId)
        {
            try
            {
                var task = await _context.OrganizationProjectTasks
                    .Include(t => t.User)
                    .FirstOrDefaultAsync(t => t.Id == taskId && !t.IsDeleted);

                if (task == null) throw new Exception("Görev bulunamadı.");

                return _mapper.Map<OrganizationProjectTaskDto>(task);
            }
            catch (Exception ex)
            {
                throw new Exception($"Görev getirilirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IEnumerable<OrganizationProjectTaskDto>> GetAllTasksAsync()
        {
            try
            {
                var tasks = await _context.OrganizationProjectTasks
                    .Where(t => !t.IsDeleted)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<OrganizationProjectTaskDto>>(tasks);
            }
            catch (Exception ex)
            {
                throw new Exception($"Tüm görevler alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<OrganizationProjectTaskDto> CreateTaskAsync(CreateOrganizationProjectTaskDto createTaskDto)
        {
            try
            {
                var task = _mapper.Map<OrganizationProjectTask>(createTaskDto);
                task.CreatedAt = DateTime.Now;

                await _context.OrganizationProjectTasks.AddAsync(task);
                await _context.SaveChangesAsync();

                return _mapper.Map<OrganizationProjectTaskDto>(task);
            }
            catch (Exception ex)
            {
                throw new Exception($"Görev oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<OrganizationProjectTaskDto> UpdateTaskAsync(int taskId, UpdateOrganizationProjectTaskDto updateTaskDto)
        {
            try
            {
                var task = await _context.OrganizationProjectTasks.FindAsync(taskId);
                if (task == null || task.IsDeleted)
                    return null;

                _context.OrganizationProjectTasks.Update(_mapper.Map<OrganizationProjectTask>(updateTaskDto));
                await _context.SaveChangesAsync();

                return _mapper.Map<OrganizationProjectTaskDto>(task);
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
                var task = await _context.OrganizationProjectTasks.FindAsync(taskId);
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

        public Task<IEnumerable<OrganizationProjectTaskDto>> GetTasksByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
