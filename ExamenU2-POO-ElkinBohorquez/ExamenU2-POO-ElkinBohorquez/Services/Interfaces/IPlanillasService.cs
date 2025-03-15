using ExamenU2_POO_ElkinBohorquez.Dtos.Common;
using ExamenU2_POO_ElkinBohorquez.Dtos.Planilla;

namespace ExamenU2_POO_ElkinBohorquez.Services.Interfaces
{
    public interface IPlanillasService
    {
        Task<ResponseDto<PlanillaActionResponseDto>> CreateAsync(PlanillaCreateDto person);
        Task<ResponseDto<PlanillaActionResponseDto>> DeleteAsync(Guid id);
        Task<ResponseDto<PlanillaActionResponseDto>> EditAsync(PlanillaEditDto dto, Guid id);
        Task<ResponseDto<List<PlanillaDto>>> GetListAsync();
        Task<ResponseDto<PlanillaDto>> GetOneByIdAsync(Guid id);
    }
}
