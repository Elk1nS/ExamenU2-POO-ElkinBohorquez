using ExamenU2_POO_ElkinBohorquez.Dtos.Common;
using ExamenU2_POO_ElkinBohorquez.Dtos.DetallePlanilla;
using ExamenU2_POO_ElkinBohorquez.Dtos.Empleados;
using ExamenU2_POO_ElkinBohorquez.Services;
using ExamenU2_POO_ElkinBohorquez.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamenU2_POO_ElkinBohorquez.Controllers
{
    [ApiController]
    [Route("api/detalleplanillas")]
    public class DetallePlanillaController : ControllerBase
    {
        private readonly IDetallePlanillas _DplanillasService;

        public DetallePlanillaController(IDetallePlanillas DplanillasService)
        {
            _DplanillasService = DplanillasService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<DetallePlanillaDto>>>> GetList()
        {
            var response = await _DplanillasService.GetListAsync();

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data

            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<DetallePlanillaDto>>> GetOne(Guid id)
        {
            var response = await _DplanillasService.GetOneByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<DetallePlanillaActionResponseDto>>> Post([FromBody] DetallePlanillaEditDto dto)
        {
            var response = await _DplanillasService.CreateAsync(dto);

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<DetallePlanillaActionResponseDto>>> Edit([FromBody] DetallePlanillaEditDto dto, Guid Id)
        {
            var response = await _DplanillasService.EditAsync(dto, Id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<DetallePlanillaActionResponseDto>>> Delete(Guid id)
        {
            var response = await _DplanillasService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
