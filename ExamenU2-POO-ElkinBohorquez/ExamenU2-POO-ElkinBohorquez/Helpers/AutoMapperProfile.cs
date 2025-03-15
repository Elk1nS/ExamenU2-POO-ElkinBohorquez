using AutoMapper;
using ExamenU2_POO_ElkinBohorquez.Database.Entities;
using ExamenU2_POO_ElkinBohorquez.Dtos.DetallePlanilla;
using ExamenU2_POO_ElkinBohorquez.Dtos.Empleados;
using ExamenU2_POO_ElkinBohorquez.Dtos.Planilla;

namespace ExamenU2_POO_ElkinBohorquez.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<EmpleadoEntity, EmpleadoDto>();
            CreateMap<EmpleadoEntity, EmpleadoActionResponseDto>();
            CreateMap<EmpleadoCreateDto, EmpleadoEntity>();
            CreateMap<EmpleadoEditDto, EmpleadoEntity>();

            CreateMap<PlanillaEntity, PlanillaDto>();
            CreateMap<PlanillaEntity, PlanillaActionResponseDto>();
            CreateMap<PlanillaCreateDto, PlanillaEntity>();
            CreateMap<PlanillaEditDto, PlanillaEntity>();

            CreateMap<DetallePlanillaEntity, DetallePlanillaDto>();
            CreateMap<DetallePlanillaEntity, DetallePlanillaActionResponseDto>();
            CreateMap<DetallePlanillaCreateDto, DetallePlanillaEntity>();
            CreateMap<DetallePlanillaEditDto, DetallePlanillaEntity>();
        }
    }
}
