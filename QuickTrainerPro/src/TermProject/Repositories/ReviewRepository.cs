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

        public int DeleteReviewByProfile(int ProfileID)
        {
            Profile p = context.Profiles.Where(prof => prof.ProfileID == ProfileID).SingleOrDefault();
            //List<Review> revs = new List<Review>();
            foreach (Review r in p.Reviews) {
                context.Reviews.Remove(r);
            }
            //foreach(Review r in revs)
            //{
            //    context.Reviews.Remove(r);
            //}
            return context.SaveChanges();
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return context.Reviews.Include(r => r.From);
        }
    }
}
