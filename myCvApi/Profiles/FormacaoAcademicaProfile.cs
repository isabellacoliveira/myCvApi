using AutoMapper;
using myCvApi.Data.DTOs.Formacao;
using myCvApi.Models;

namespace myCvApi.Profiles
{
    public class FormacaoAcademicaProfile : Profile
    {
        public FormacaoAcademicaProfile()
        {
            CreateMap<CreateFormacaoDto, Formacao>(); 
            CreateMap<Formacao, UpdateFormacaoDto>(); 
            CreateMap<Formacao, ReadFormacaoDto>();
            CreateMap<UpdateFormacaoDto, Formacao>(); 
        }
    }
}