using EDP.Models;

namespace EDP.Services
{
    public class ReviewService
    {
        private readonly MyDbContext _context;
        public ReviewService(MyDbContext context)
        {
            _context = context;
        }

        public List<Reviews> GetAll()
        {
            return _context.Reviews.OrderBy(m => m.review_id).ToList();

        }
        public Reviews? GetReviewById(string id)
        {
            Reviews? review = _context.Reviews.FirstOrDefault(x => x.review_id.Equals(id));
            return review;
        }
        public void AddReview(Reviews review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void UpdateReview(Reviews review)
        {
            _context.Reviews.Update(review);
            _context.SaveChanges();
        }
    }
}
