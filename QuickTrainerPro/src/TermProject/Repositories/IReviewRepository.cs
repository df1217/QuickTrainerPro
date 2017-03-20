using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAllReviews();
        

        Review DeleteReview(int reviewID);

        int DeleteReviewByProfile(int ProfileID);

    }
}
