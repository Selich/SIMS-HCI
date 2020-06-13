// File:    Report.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:31:41 PM
// Purpose: Definition of Class Report

using System;

namespace Project.Model
{
    public class Report
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public DateTime Date { get; set; }
        public string Type {get;set;}

        public Report(string path, DateTime date, string type)
        {
            Path = path;
            Date = date;
            Type = type;
        }
        public Report(long id, string path, DateTime date, string type)
        {
            Id = id;
            Path = path;
            Date = date;
            Type = type;
        }


    }

}