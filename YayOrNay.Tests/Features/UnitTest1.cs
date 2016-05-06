using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YayOrNay.Models;
using System.Collections.Generic;
using System.Linq;

namespace YayOrNay.Tests.Features
{
   

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Computes_Result_For_One_Review()
        {
            var data = BuildMovieAndReviews(ratings: 4);

            var rater = new MovieRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(4, result.Rating);

        }

   

        [TestMethod]
        public void Computes_Result_For_Two_Reviews()
        {
            var data = BuildMovieAndReviews(ratings: new[] { 4, 8 });

            var rater = new MovieRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(6, result.Rating);

        }


        //[TestMethod]
        //public void Weighted_Averaging_For_Two_Reviews()
        //{
        //    var data = BuildMovieAndReviews( 3,9 );

        //    var rater = new MovieRater(data);
        //    var result = rater.ComputeWeightedRate(10);

        //    Assert.AreEqual(5, result.Rating);

        //}





        private Movie BuildMovieAndReviews(params int[] ratings)
        {
            var movie = new Movie();
            //need a using statemen for the System.Linq at the top of hte file
            movie.Reviews =
                ratings.Select(r => new MovieReview { Rating = r })
                .ToList();


            return movie;
        }



        //[TestClass]
        //public class UnitTest1
        //{
        //    [TestMethod]
        //    public void Computes_Result_For_One_Reviews()
        //    {
        //        var data = new Movie();
        //        data.Reviews = new List<MovieReview>();
        //        data.Reviews.Add(new MovieReview() {Rating = 4 });

        //        var rater = new MovieRater(data);
        //        var result = rater.ComputeRating(10);

        //        Assert.AreEqual(4,result.Rating);

        //    }

        //    [TestMethod]
        //    public void Computes_Result_For_Two_Reviews()
        //    {
        //        var data = new Movie();
        //        data.Reviews = new List<MovieReview>();
        //        data.Reviews.Add(new MovieReview() { Rating = 4 });
        //        data.Reviews.Add(new MovieReview() { Rating = 8 });


        //        var rater = new MovieRater(data);
        //        var result = rater.ComputeRating(10);

        //        Assert.AreEqual(6, result.Rating);

        //    }


   
    }
}
