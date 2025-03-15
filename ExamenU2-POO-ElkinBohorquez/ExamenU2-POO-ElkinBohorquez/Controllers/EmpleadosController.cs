using ExamenU2_POO_ElkinBohorquez.Dtos.Common;
using ExamenU2_POO_ElkinBohorquez.Dtos.Empleados;
using ExamenU2_POO_ElkinBohorquez.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamenU2_POO_ElkinBohorquez.Controllers
{
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosService _empleadosService;

        public EmpleadosController(IEmpleadosService empleadosService)
        {
            _empleadosService = empleadosService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<EmpleadoDto>>>> GetList()
        {
            var response = await _empleadosService.GetListAsync();

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data

            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<EmpleadoDto>>> GetOne(Guid id)
        {
            var response = await _empleadosService.GetOneByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<EmpleadoActionResponseDto>>> Post([FromBody] EmpleadoCreateDto dto)
        {
            var response = await _empleadosService.CreateAsync(dto);

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<EmpleadoActionResponseDto>>> Edit([FromBody] EmpleadoEditDto dto, Guid Id)
        {
            var response = await _empleadosService.EditAsync(dto, Id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<EmpleadoActionResponseDto>>> Delete(Guid id)
        {
            var response = await _empleadosService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
