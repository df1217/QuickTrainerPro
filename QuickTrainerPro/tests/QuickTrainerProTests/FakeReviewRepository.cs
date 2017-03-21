using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;
using TermProject.Repositories;

namespace QuickTrainerProTests
{
    public class FakeReviewRepository : IReviewRepository
    {
        public Review DeleteReview(int reviewID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Review> GetAllReviews()
        {
            throw new NotImplementedException();
        }
    }
}
