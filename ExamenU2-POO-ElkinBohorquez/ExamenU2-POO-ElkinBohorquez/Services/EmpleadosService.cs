using AutoMapper;
using ExamenU2_POO_ElkinBohorquez.Constants;
using ExamenU2_POO_ElkinBohorquez.Database;
using ExamenU2_POO_ElkinBohorquez.Database.Entities;
using ExamenU2_POO_ElkinBohorquez.Dtos.Common;
using ExamenU2_POO_ElkinBohorquez.Dtos.Empleados;
using ExamenU2_POO_ElkinBohorquez.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamenU2_POO_ElkinBohorquez.Services
{
    public class EmpleadosService : IEmpleadosService
    {
        private readonly ExamenDbContext _context;
        private readonly IMapper _mapper;

        public EmpleadosService(ExamenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<EmpleadoDto>>> GetListAsync()
        {
            var empleadosEntity = await _context.Empleados.ToListAsync();

            var empleadosDto = _mapper.Map<List<EmpleadoDto>>(empleadosEntity);

            return new ResponseDto<List<EmpleadoDto>>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = empleadosEntity.Count() > 0 ? "Registros encontrados" : "No se encontraron registros",
                Data = empleadosDto
            };
        }

        public async Task<ResponseDto<EmpleadoDto>> GetOneByIdAsync(Guid id)
        {
            var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(x => x.Id == id);

            if (empleadoEntity is null)
            {
                return new ResponseDto<EmpleadoDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado"
                };
            }

            return new ResponseDto<EmpleadoDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = "Registro encontrado",
                Data = _mapper.Map<EmpleadoDto>(empleadoEntity)
            };
        }

        public async Task<ResponseDto<EmpleadoActionResponseDto>> CreateAsync(EmpleadoCreateDto dto)
        {

            var empleadoEntity = _mapper.Map<EmpleadoEntity>(dto);

            _context.Empleados.Add(empleadoEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<EmpleadoActionResponseDto>
            {
                StatusCode = HttpStatusCode.CREATED,
                Status = true,
                Message = "Registro creado correctamente",
                Data = _mapper.Map<EmpleadoActionResponseDto>(empleadoEntity)
            };
        }

        public async Task<ResponseDto<EmpleadoActionResponseDto>> EditAsync(EmpleadoEditDto dto, Guid id)
        {
            var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(x => x.Id == id);

            if (empleadoEntity is null)
            {
                return new ResponseDto<EmpleadoActionResponseDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado",
                };
            }

            _mapper.Map<EmpleadoEditDto, EmpleadoEntity>(dto, empleadoEntity);

            _context.Empleados.Update(empleadoEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<EmpleadoActionResponseDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = "Registro editado correctamente",
                Data = _mapper.Map<EmpleadoActionResponseDto>(empleadoEntity)
            };
        }

        public async Task<ResponseDto<EmpleadoActionResponseDto>> DeleteAsync(Guid id)
        {
            var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(x => x.Id == id);

            if (empleadoEntity is null)
            {
                return new ResponseDto<EmpleadoActionResponseDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado",
                };
            }

            _context.Empleados.Remove(empleadoEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<EmpleadoActionResponseDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = "Registro eliminado Correctamente",
                Data = _mapper.Map<EmpleadoActionResponseDto>(empleadoEntity)
            };
        }

        //public async Task<ResponseDto<EmpleadoActionResponseDto>> GetOnlyActive(Guid id, EmpleadoActionResponseDto Activo) 
        //{
        //    var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(x => x.Activo = Activo);

        //    if (empleadoEntity == Activo)
        //    {
        //        return new ResponseDto<EmpleadoEntity>
        //        {
        //            StatusCode = HttpStatusCode.NOT_FOUND,
        //            Status = false,
        //            Message = "Registro no encontrado"
        //        };
        //    }

        //    return new ResponseDto<EmpleadoDto>
        //    {
        //        StatusCode = HttpStatusCode.Ok,
        //        Status = true,
        //        Message = "Registro encontrado",
        //        Data = _mapper.Map<EmpleadoDto>(empleadoEntity)
        //    };
        //}
    }
}
