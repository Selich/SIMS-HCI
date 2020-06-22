// File:    Review.cs
// Author:  Uros
// Created: Friday, April 17, 2020 5:21:46 PM
// Purpose: Definition of Class Review

using System;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class Review : IIdentifiable<long>
    {
        public long Id { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public Review() { }
        public Review(int rating, string description)
        {
            Rating = rating;
            Description = description;
        }
        public Review(long id, int rating, string description)
        {
            Id = id;
            Rating = rating;
            Description = description;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

    }
}