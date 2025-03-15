using AutoMapper;
using ExamenU2_POO_ElkinBohorquez.Constants;
using ExamenU2_POO_ElkinBohorquez.Database;
using ExamenU2_POO_ElkinBohorquez.Database.Entities;
using ExamenU2_POO_ElkinBohorquez.Dtos.Common;
using ExamenU2_POO_ElkinBohorquez.Dtos.DetallePlanilla;
using ExamenU2_POO_ElkinBohorquez.Dtos.Planilla;
using ExamenU2_POO_ElkinBohorquez.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamenU2_POO_ElkinBohorquez.Services
{
    public class DetallePlanillasService : IDetallePlanillas
    {
        private readonly ExamenDbContext _context;
        private readonly IMapper _mapper;

        public DetallePlanillasService(ExamenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<DetallePlanillaDto>>> GetListAsync()
        {
            var DplanillasEntity = await _context.DetallePlanilla.ToListAsync();

            var DplanillasDto = _mapper.Map<List<DetallePlanillaDto>>(DplanillasEntity);

            return new ResponseDto<List<DetallePlanillaDto>>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = DplanillasEntity.Count() > 0 ? "Registros encontrados" : "No se encontraron registros",
                Data = DplanillasDto
            };
        }

        public async Task<ResponseDto<DetallePlanillaDto>> GetOneByIdAsync(Guid id)
        {
            var DplanillaEntity = await _context.DetallePlanilla.FirstOrDefaultAsync(x => x.Id == id);

            if (DplanillaEntity is null)
            {
                return new ResponseDto<DetallePlanillaDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado"
                };
            }

            return new ResponseDto<DetallePlanillaDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = "Registro encontrado",
                Data = _mapper.Map<DetallePlanillaDto>(DplanillaEntity)
            };
        }

        public async Task<ResponseDto<DetallePlanillaActionResponseDto>> CreateAsync(DetallePlanillaCreateDto dto)
        {

            var DplanillaEntity = _mapper.Map<DetallePlanillaEntity>(dto);

            _context.DetallePlanilla.Add(DplanillaEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<DetallePlanillaActionResponseDto>
            {
                StatusCode = HttpStatusCode.CREATED,
                Status = true,
                Message = "Registro creado correctamente",
                Data = _mapper.Map<DetallePlanillaActionResponseDto>(DplanillaEntity)
            };
        }

        public async Task<ResponseDto<DetallePlanillaActionResponseDto>> EditAsync(DetallePlanillaEditDto dto, Guid id)
        {
            var DplanillaEntity = await _context.DetallePlanilla.FirstOrDefaultAsync(x => x.Id == id);

            if (DplanillaEntity is null)
            {
                return new ResponseDto<DetallePlanillaActionResponseDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado",
                };
            }

            _mapper.Map<DetallePlanillaEditDto, DetallePlanillaEntity>(dto, DplanillaEntity);

            _context.DetallePlanilla.Update(DplanillaEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<DetallePlanillaActionResponseDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = "Registro editado correctamente",
                Data = _mapper.Map<DetallePlanillaActionResponseDto>(DplanillaEntity)
            };
        }

        public async Task<ResponseDto<DetallePlanillaActionResponseDto>> DeleteAsync(Guid id)
        {
            var DplanillaEntity = await _context.DetallePlanilla.FirstOrDefaultAsync(x => x.Id == id);

            if (DplanillaEntity is null)
            {
                return new ResponseDto<DetallePlanillaActionResponseDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado",
                };
            }

            _context.DetallePlanilla.Remove(DplanillaEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<DetallePlanillaActionResponseDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = "Registro eliminado Correctamente",
                Data = _mapper.Map<DetallePlanillaActionResponseDto>(DplanillaEntity)
            };
        }
    }
}
