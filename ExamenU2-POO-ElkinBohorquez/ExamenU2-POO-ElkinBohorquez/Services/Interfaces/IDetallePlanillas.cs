using ExamenU2_POO_ElkinBohorquez.Dtos.Common;
using ExamenU2_POO_ElkinBohorquez.Dtos.DetallePlanilla;
using ExamenU2_POO_ElkinBohorquez.Dtos.Planilla;

namespace ExamenU2_POO_ElkinBohorquez.Services.Interfaces
{
    public interface IDetallePlanillas
    {
        Task<ResponseDto<DetallePlanillaActionResponseDto>> CreateAsync(DetallePlanillaCreateDto person);
        Task<ResponseDto<DetallePlanillaActionResponseDto>> DeleteAsync(Guid id);
        Task<ResponseDto<DetallePlanillaActionResponseDto>> EditAsync(DetallePlanillaEditDto dto, Guid id);
        Task<ResponseDto<List<DetallePlanillaDto>>> GetListAsync();
        Task<ResponseDto<DetallePlanillaDto>> GetOneByIdAsync(Guid id);
    }
}
