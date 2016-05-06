using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using YayOrNay.Models;

namespace YayOrNay.Tests.Features
{
    internal class MovieRater
    {
        private object data;
        private Movie _movie;

        public MovieRater(object data)
        {
            this.data = data;
        }

        public MovieRater(Movie movie)
        {
            this._movie = movie;
        }

        public RatingResult ComputeRating(int numberOfReviews)
        {
            //return new RatingResult ();

            //testing the values passing through the rating as a number
            var result = new RatingResult();
            result.Rating = (int) _movie.Reviews.Average(r => r.Rating); 
            return result;
        }


        //not working what trying ot cast to int but unable to, two integer values to trunks
        //public RatingResult ComputeWeightedRate (int numberOfReviews)
        //{
        //    var reviews = _movie.Reviews.ToArray();
        //    var result = new RatingResult();
        //    var counter = 0;
        //    var total = 0;

        //    for (int i = 0; i < reviews.Count(); i++)
        //    {
        //        if (i < reviews.Count() / 2)
        //        {
        //            counter += 2;
        //            total += reviews[i].Rating * 2;
        //        }

        //        else
        //        {
        //            counter += 1;
        //            total += reviews[i].Rating;
        //        }

        //        result.Rating = total / counter;
        //        return result;
                
        //    }
        //}

     
    }


}