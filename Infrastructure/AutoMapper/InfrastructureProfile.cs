using AutoMapper;
using Domain.Dtos.AuthorDTO;
using Domain.Entities;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        // Author
        CreateMap<Authors, GetAuthorDto>();
        CreateMap<CreateAuthorDto, Authors>();
        CreateMap<UpdateAuthorDto, Authors>();

        //Book
        
    }
}
