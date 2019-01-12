using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DBCrud.Dto
{
    public class TestimonialDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Descriptions { get; set; }

        //public string ImageName { get; set; }

        public bool IsActive { get; set; }

        //public IFormFile File { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

    }

}