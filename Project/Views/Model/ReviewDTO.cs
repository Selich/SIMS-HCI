// File:    Review.cs
// Author:  Uros
// Created: Friday, April 17, 2020 5:21:46 PM
// Purpose: Definition of Class Review

using System;

namespace Project.Views.Model
{
   public class ReviewDTO
   {
        public int Rating { get; set; }
        public string Description { get; set; }

        public ReviewDTO(int rating, string description)
        {
            Rating = rating;
            Description = description;
        }

        public ReviewDTO()
        {
        }
    }
}