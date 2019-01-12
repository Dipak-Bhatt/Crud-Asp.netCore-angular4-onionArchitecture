using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Entity;
using DBCrud.Dto;

namespace DBCrud.Ext
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }
        public static TestimonialDto ToDto(this Testimonial entity)
        {
            return entity.MapTo<Testimonial, TestimonialDto>();
        }

        public static Testimonial ToEntity(this TestimonialDto model)
        {
            return model.MapTo<TestimonialDto, Testimonial>();
        }
    }
}
