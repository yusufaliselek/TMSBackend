using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystemBackend.DataAccess;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.TaskUpdate;
using TaskManagementSystemBackend.DataAccess.Entities;
using TaskManagementSystemBackend.DataAccess.IServices;

namespace TaskManagementSystemBackend.Business.Services
{
    public class OrganizationProjectTaskUpdateService : IOrganizationProjectTaskUpdateService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrganizationProjectTaskUpdateService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrganizationProjectTaskUpdateDto> GetTaskUpdateByIdAsync(int taskUpdateId)
        {
            try
            {
                var taskUpdate = await _context.OrganizationProjectTaskUpdates
                    .Where(t => t.Id == taskUpdateId && !t.IsDeleted)
                    .FirstOrDefaultAsync();

                if (taskUpdate == null)
                    throw new KeyNotFoundException("Task güncellemesi bulunamadı.");

                return _mapper.Map<OrganizationProjectTaskUpdateDto>(taskUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Task güncellemesi alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IEnumerable<OrganizationProjectTaskUpdateDto>> GetAllTaskUpdatesAsync()
        {
            try
            {
                var taskUpdates = await _context.OrganizationProjectTaskUpdates
                    .Where(t => !t.IsDeleted)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<OrganizationProjectTaskUpdateDto>>(taskUpdates);
            }
            catch (Exception ex)
            {
                throw new Exception($"Task güncellemeleri alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<OrganizationProjectTaskUpdateDto> CreateTaskUpdateAsync(CreateOrganizationProjectTaskUpdateDto createTaskUpdateDto)
        {
            try
            {
                var taskUpdate = _mapper.Map<OrganizationProjectTaskUpdate>(createTaskUpdateDto);
                await _context.OrganizationProjectTaskUpdates.AddAsync(taskUpdate);
                await _context.SaveChangesAsync();

                return _mapper.Map<OrganizationProjectTaskUpdateDto>(taskUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Task güncellemesi oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<OrganizationProjectTaskUpdateDto> UpdateTaskUpdateAsync(int taskUpdateId, UpdateOrganizationProjectTaskUpdateDto updateTaskUpdateDto)
        {
            try
            {
                var taskUpdate = await _context.OrganizationProjectTaskUpdates
                    .FirstOrDefaultAsync(t => t.Id == taskUpdateId && !t.IsDeleted);

                if (taskUpdate == null)
                    throw new KeyNotFoundException("Task güncellemesi bulunamadı.");

                _context.OrganizationProjectTaskUpdates.Update(_mapper.Map(updateTaskUpdateDto, taskUpdate));
                await _context.SaveChangesAsync();

                return _mapper.Map<OrganizationProjectTaskUpdateDto>(taskUpdate);
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
                var taskUpdate = await _context.OrganizationProjectTaskUpdates
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
