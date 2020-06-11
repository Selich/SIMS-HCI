// File:    Secretary.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:10:34 PM
// Purpose: Definition of Class Secretary

using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class Secretary : Employee
    {
        public List<Question> Questions { get; set; }

        public Secretary(List<Question> questions)
        {
            Questions = questions;
        }

        public Secretary()
        {
        }
    }
}