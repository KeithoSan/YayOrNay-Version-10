using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YayOrNay.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(10)]
        public string Certificate { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<MovieReview> Reviews { get; set; }
        public virtual ICollection<File> Files { get; set; }


        //logic average rating
        public double AverageRating
        {
            get
            {
                double totalRating = 0;
                if(Reviews != null)
                {
                    int numReviewed = Reviews.Count;
                    if( numReviewed > 0)
                    {
                        foreach(MovieReview review in Reviews)
                        {
                            totalRating += review.Rating;
                        }

                        return Math.Round(totalRating / numReviewed, 2);
                    }
                }
                return totalRating;
            }
        }

    }
}