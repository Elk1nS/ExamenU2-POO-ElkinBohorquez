using AutoMapper;
using ExamenU2_POO_ElkinBohorquez.Constants;
using ExamenU2_POO_ElkinBohorquez.Database;
using ExamenU2_POO_ElkinBohorquez.Database.Entities;
using ExamenU2_POO_ElkinBohorquez.Dtos.Common;
using ExamenU2_POO_ElkinBohorquez.Dtos.Planilla;
using ExamenU2_POO_ElkinBohorquez.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamenU2_POO_ElkinBohorquez.Services
{
    public class PlanillasService : IPlanillasService
    {
        private readonly ExamenDbContext _context;
        private readonly IMapper _mapper;

        public PlanillasService(ExamenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<PlanillaDto>>> GetListAsync()
        {
            var planillasEntity = await _context.Planilla.ToListAsync();

            var planillasDto = _mapper.Map<List<PlanillaDto>>(planillasEntity);

            return new ResponseDto<List<PlanillaDto>>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = planillasEntity.Count() > 0 ? "Registros encontrados" : "No se encontraron registros",
                Data = planillasDto
            };
        }

        public async Task<ResponseDto<PlanillaDto>> GetOneByIdAsync(Guid id)
        {
            var planillaEntity = await _context.Planilla.FirstOrDefaultAsync(x => x.Id == id);

            if (planillaEntity is null)
            {
                return new ResponseDto<PlanillaDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado"
                };
            }

            return new ResponseDto<PlanillaDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = "Registro encontrado",
                Data = _mapper.Map<PlanillaDto>(planillaEntity)
            };
        }

        public async Task<ResponseDto<PlanillaActionResponseDto>> CreateAsync(PlanillaCreateDto dto)
        {

            var planillaEntity = _mapper.Map<PlanillaEntity>(dto);

            _context.Planilla.Add(planillaEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<PlanillaActionResponseDto>
            {
                StatusCode = HttpStatusCode.CREATED,
                Status = true,
                Message = "Registro creado correctamente",
                Data = _mapper.Map<PlanillaActionResponseDto>(planillaEntity)
            };
        }

        public async Task<ResponseDto<PlanillaActionResponseDto>> EditAsync(PlanillaEditDto dto, Guid id)
        {
            var planillaEntity = await _context.Planilla.FirstOrDefaultAsync(x => x.Id == id);

            if (planillaEntity is null)
            {
                return new ResponseDto<PlanillaActionResponseDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado",
                };
            }

            _mapper.Map<PlanillaEditDto, PlanillaEntity>(dto, planillaEntity);

            _context.Planilla.Update(planillaEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<PlanillaActionResponseDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = "Registro editado correctamente",
                Data = _mapper.Map<PlanillaActionResponseDto>(planillaEntity)
            };
        }

        public async Task<ResponseDto<PlanillaActionResponseDto>> DeleteAsync(Guid id)
        {
            var planillaEntity = await _context.Planilla.FirstOrDefaultAsync(x => x.Id == id);

            if (planillaEntity is null)
            {
                return new ResponseDto<PlanillaActionResponseDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado",
                };
            }

            _context.Planilla.Remove(planillaEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<PlanillaActionResponseDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = "Registro eliminado Correctamente",
                Data = _mapper.Map<PlanillaActionResponseDto>(planillaEntity)
            };
        }

    }
}
