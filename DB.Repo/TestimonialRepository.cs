using DB.DataAccess.Infrastructure;
using DB.Entity;

namespace DB.Repo
{
    public class TestimonialRepository: RepositoryBase<Testimonial>, ITestimonialRepository
    {
        public TestimonialRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
