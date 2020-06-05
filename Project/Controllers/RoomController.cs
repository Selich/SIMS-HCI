// File:    RoomController.cs
// Author:  Selic
// Created: Friday, May 1, 2020 2:25:17 AM
// Purpose: Definition of Class RoomController

using System;
using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Views.Model;

namespace Controller
{
    public class RoomController : IController<RoomDTO, long>
    {
        public IEnumerable<RoomDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public RoomDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public RoomDTO Remove(RoomDTO entity)
        {
            throw new NotImplementedException();
        }

        public RoomDTO Save(RoomDTO entity)
        {
            throw new NotImplementedException();
        }

        public RoomDTO Update(RoomDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}