using AutoMapper;
using ERP_System.DTO.Guide;
using ERP_System.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ERP_System.DTO
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            
            CreateMap<UserTypeDTO, UserType>().ReverseMap();
            CreateMap<UnitDTO, Unit>().ReverseMap();
            CreateMap<ItemGroupDTO, ItemGrpoup>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<StockDto, Stock>().ReverseMap();
            CreateMap<SettingDTO, Setting>().ReverseMap();
            CreateMap<InvoiceDTO, Invoice>().ReverseMap();


        }
    }
}
