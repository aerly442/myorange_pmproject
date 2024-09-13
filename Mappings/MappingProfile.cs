using AutoMapper;
using myorange_pmproject.Models;
using myorange_pmproject.DTO;
namespace myorange_pmproject.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Manager,ManagerDTO>().ReverseMap();
            CreateMap<Menu, MenuDTO>().ReverseMap();          
            CreateMap<Menu_ruler, Menu_rulerDTO>().ReverseMap();         
            CreateMap<User_need, User_needDTO>().ReverseMap();       
            CreateMap<User_authorize_code, User_authorize_codeDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            
        }
    }
}
