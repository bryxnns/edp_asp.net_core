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

        public Reviews? GetReviewById(string id)
        {
            Reviews? review = _context.Reviews.FirstOrDefault(x => x.review_id.Equals(id));
            return review;
        }
        public List<Reviews> GetReviewByProductId(string productid)
        {
            return _context.Reviews.Where(x => x.product_id.Equals(productid)).ToList();
        }
        public List<Reviews> GetReviewByUserId(string userid)
        {
            return _context.Reviews.Where(x => x.user_id.Equals(userid)).ToList();
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

        public void DeleteReview(Reviews review)
        {
            _context.Reviews.Remove(review);
            _context.SaveChanges();
        }
    }
}
