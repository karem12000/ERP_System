using AutoMapper;
using ERP_System.DTO.Guide;
using ERP_System.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            
            CreateMap<UserTypeDTO, UserType>().ReverseMap();

        }
    }
}
