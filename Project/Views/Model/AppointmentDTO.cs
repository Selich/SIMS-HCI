// File:    Appoitment.cs
// Author:  Selic
// Created: Thursday, March 19, 2020 7:31:07 PM
// Purpose: Definition of Class Appoitment

using System;

namespace Project.Views.Model
{
    public class AppointmentDTO
    {
        public long Id { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }

        public RoomDTO Room { get; set; }
        public AppointmentDTO() { }
        public AppointmentDTO(DateTime beginning, DateTime end, RoomDTO room)
        {
            Beginning = beginning;
            End = end;
            Room = room;
        }
        public AppointmentDTO(long id, DateTime beginning, DateTime end, RoomDTO room)
        {
            Id = id;
            Beginning = beginning;
            End = end;
            Room = room;
        }

    }
}