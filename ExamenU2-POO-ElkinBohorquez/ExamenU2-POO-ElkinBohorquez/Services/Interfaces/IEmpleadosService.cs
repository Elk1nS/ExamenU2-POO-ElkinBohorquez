using ExamenU2_POO_ElkinBohorquez.Dtos.Common;
using ExamenU2_POO_ElkinBohorquez.Dtos.Empleados;

namespace ExamenU2_POO_ElkinBohorquez.Services.Interfaces
{
    public interface IEmpleadosService
    {
        Task<ResponseDto<EmpleadoActionResponseDto>> CreateAsync(EmpleadoCreateDto person);
        Task<ResponseDto<EmpleadoActionResponseDto>> DeleteAsync(Guid id);
        Task<ResponseDto<EmpleadoActionResponseDto>> EditAsync(EmpleadoEditDto dto, Guid id);
        Task<ResponseDto<List<EmpleadoDto>>> GetListAsync();
        Task<ResponseDto<EmpleadoDto>> GetOneByIdAsync(Guid id);
        //Task<ResponseDto<EmpleadoDto>> GetOnlyActive();
    }
}
