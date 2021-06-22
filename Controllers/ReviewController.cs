using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.Controllers
{
    [Route("/Reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        [HttpGet("GetReviewsForActivity")]
        public ActionResult<List<ApplicationClasses.Review>> GetAllReviewsForActivity(int activity)
        {
            return DatabaseRepositories.ReviewRepository.GetReviewsForActivity(activity);
        }

        [HttpGet("GetAllReviews")]
        public ActionResult<List<ApplicationClasses.Review>> GetAllReviews()
        {
            return DatabaseRepositories.ReviewRepository.GetAllReviews();
        }

        [HttpPost("AddReview")]
        public ActionResult AddReview([FromBody] ApplicationClasses.SubmittedReview submittedReview)
        {
            bool status = DatabaseRepositories.ReviewRepository.IsAddReviewSuccessful(submittedReview);
            if (status)
                return Ok();
            return StatusCode(500);
        }
    }
}
