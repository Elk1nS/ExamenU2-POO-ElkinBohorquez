using ExamenU2_POO_ElkinBohorquez.Dtos.Common;
using ExamenU2_POO_ElkinBohorquez.Dtos.Empleados;
using ExamenU2_POO_ElkinBohorquez.Dtos.Planilla;
using ExamenU2_POO_ElkinBohorquez.Services;
using ExamenU2_POO_ElkinBohorquez.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamenU2_POO_ElkinBohorquez.Controllers
{
    [ApiController]
    [Route("api/planillas")]
    public class PlanillaController : ControllerBase
    {
        private readonly IPlanillasService _planillasService;

        public PlanillaController(IPlanillasService planillasService)
        {
            _planillasService = planillasService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<PlanillaDto>>>> GetList()
        {
            var response = await _planillasService.GetListAsync();

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data

            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<PlanillaDto>>> GetOne(Guid id)
        {
            var response = await _planillasService.GetOneByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<PlanillaActionResponseDto>>> Post([FromBody] PlanillaCreateDto dto)
        {
            var response = await _planillasService.CreateAsync(dto);

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<PlanillaActionResponseDto>>> Edit([FromBody] PlanillaEditDto dto, Guid Id)
        {
            var response = await _planillasService.EditAsync(dto, Id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<PlanillaActionResponseDto>>> Delete(Guid id)
        {
            var response = await _planillasService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
