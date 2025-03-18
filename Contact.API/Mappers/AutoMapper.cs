using AutoMapper;
using Contact.API.Dtos;
using Contact.API.Model;

namespace Contact.API.Mappers
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<ContactModel,ContactDto>().ReverseMap();
        }
    }
}
