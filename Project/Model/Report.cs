// File:    Report.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:31:41 PM
// Purpose: Definition of Class Report

using System;

namespace Project.Model
{
    abstract class Report
    {
        protected string Path { get; set; }
        protected DateTime Date { get; set; }
        protected string Type {get;set;}

        public Report(string path, DateTime date, string type)
        {
            Path = path;
            Date = date;
            Type = type;
        }

        public abstract void Generate();

    }

}