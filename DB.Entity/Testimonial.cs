using System.ComponentModel.DataAnnotations;

namespace DB.Entity
{
    public class Testimonial : BaseEntity<int>
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Descriptions { get; set; }


        [MaxLength(200)]
        public string Address { get; set; }
        public string Email { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
