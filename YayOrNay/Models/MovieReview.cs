using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YayOrNay.Models
{
    //this logic will determine the length of words for the user name
    public class MaxWordAttribute : ValidationAttribute
    {
        public MaxWordAttribute(int maxWords) : base("{0} has too many words")
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > _maxWords)
                {
                    var errormessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errormessage);
                }
            }
            return ValidationResult.Success;
        }
        private readonly int _maxWords;
    }



    public class MovieReview : IValidatableObject
    {
        public int Id { get; set; }


        [Range(1, 10)]
        [Required]
        public float Rating { get; set; }

        [Required]
        [StringLength(1024)]
        public string Comment { get; set; }


        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText = "anonymous")]

        //user name length, limit
        [MaxWord(5)]
        public string ReviewerName { get; set; }
        public int MovieId { get; set; }


        //validation, this will stopp keith from reviewing movies below 2 points
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && ReviewerName.ToLower().StartsWith("keith"))
            {
                yield return new ValidationResult("Sorry, Keith you can't do this");
            }
            //throw new NotImplementedException();
        }
    }

}