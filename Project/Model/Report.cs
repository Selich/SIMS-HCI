// File:    Report.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:31:41 PM
// Purpose: Definition of Class Report

using System;

namespace Project.Model
{
    public class Report
    {
        protected long Id { get; set; }
        protected string Path { get; set; }
        protected DateTime Date { get; set; }
        protected string Type {get;set;}

        //public abstract void InitializeReport();
        //public abstract void PopulateReport();
        //public abstract void FinalizeReport();

        //public void GenerateReport()
        //{
        //    InitializeReport();
        //    PopulateReport();
        //    FinalizeReport();
        //}

    }
}