using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;

        public ReviewRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public Review DeleteReview(int reviewID)
        {
            Review dReview = context.Reviews
               .FirstOrDefault(m => m.ReviewID == reviewID);
            if (dReview != null)
            {
                context.Reviews.Remove(dReview);
                context.SaveChanges();
            }
            return dReview;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return context.Reviews.Include(r => r.From);
        }
    }
}
