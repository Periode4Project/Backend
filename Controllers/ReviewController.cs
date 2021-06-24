using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SailingBackend.ApplicationClasses;

namespace SailingBackend.Controllers
{
    /// <summary>
    /// Define API controller route and class
    /// </summary>
    [Route("/Reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        /// <summary>
        /// Get all reviews for a given activity
        /// </summary>
        /// <param name="activity"> int for activity id </param>
        /// <returns> 
        /// ActionResult/HTTP status code,
        /// List of type Review
        /// </returns>
        [HttpGet("GetReviewsForActivity")]
        public ActionResult<List<Review>> GetAllReviewsForActivity(int activity)
        {
            return DatabaseRepositories.ReviewRepository.GetReviewsForActivity(activity);
        }

        /// <summary>
        /// Get all reviews
        /// </summary>
        /// <returns> 
        /// ActionResult/HTTP status code,
        /// List of type Review 
        /// </returns>
        [HttpGet("GetAllReviews")]
        [ProducesResponseType(typeof(List<Review>), 200)]
        public ActionResult<List<Review>> GetAllReviews()
        {
            return DatabaseRepositories.ReviewRepository.GetAllReviews();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="submittedReview"> Object of type SubmittedReview </param>
        /// <returns> ActionResult/HTTP status code </returns>
        [HttpPost("AddReview")]
        public ActionResult AddReview([FromBody] SubmittedReview submittedReview)
        {
            bool status = DatabaseRepositories.ReviewRepository.IsAddReviewSuccessful(submittedReview);
            if (status)
                return Ok();
            return StatusCode(500);
        }
    }
}
