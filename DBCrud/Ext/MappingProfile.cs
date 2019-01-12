using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DB.Entity;
using DBCrud.Dto;

namespace DBCrud.Ext
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Testimonial, TestimonialDto>();
            CreateMap<TestimonialDto, Testimonial>();
        }
    }
}
