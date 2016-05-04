using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace YayOrNay.Models
{
    public class MovieListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Certificate { get; set; }


        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<MovieReview> Reviews { get; set; }


        // some logic for the average rating partial model
        public double AverageRating
        {
            get
            {
                double totalRating = 0;
                if (Reviews != null)
                {
                    int numReviewed = Reviews.Count;
                    if (numReviewed > 0)
                    {
                        foreach (MovieReview review in Reviews)
                        {
                            totalRating += review.Rating;
                        }

                        return Math.Round(totalRating / numReviewed, 2);
                    }
                }
                return totalRating;
            }
        }



        //dating format
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }


        public int CountOfReviews { get; set; }
    }
}