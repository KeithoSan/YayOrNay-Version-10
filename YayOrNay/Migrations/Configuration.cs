namespace YayOrNay.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YayOrNay.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<YayOrNay.Models.YayOrNayDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(YayOrNay.Models.YayOrNayDb context)
        {


            //context.Movies.AddOrUpdate(r => r.Title,
            //     new Movie { Title = "Notebook", Genre = "Romance", Certificate = "PG", ReleaseDate = DateTime.Parse("02 / 06 / 2004") },
            //     new Movie { Title = "Godzilla", Genre = "Action", Certificate = "PG-13", ReleaseDate = DateTime.Parse("16 / 05 / 2014") },
            //     new Movie
            //     {
            //         Title = "The Matrix",
            //         Genre = "Action",
            //         Certificate = "R",
            //         ReleaseDate = DateTime.Parse("01 / 02 / 1999"),

            //         Reviews =
            //         new List<MovieReview>
            //        {
            //            new MovieReview {Rating = 10, Comment = "Awesome Movie!", ReviewerName = "Keith" }
            //        }
            //     });


            // loop to add about 1000 movies
            //for (int i = 0; i <1000; i++)
            //{
            //    context.Movies.AddOrUpdate(r => r.Title,
            //        new Movie { Title = i.ToString(), Genre = "Any Genre", Certificate = "Any Certificate", ReleaseDate = DateTime.Parse("21/01/1986") });
            //}


        }
    }
}
