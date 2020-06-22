using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class InventoryManagmentDTO:AppointmentDTO,INotifyPropertyChanged
    {
        // private List<EquipmentDTO> equipment;
        // {
        //     get
        //     {
        //         return equipment;
        //     }
        //     set
        //     {
        //         if (value != equipment)
        //         {
        //             equipment = value;
        //             OnPropertyChanged("Equipment");
        //         }
        //     }
        // }
        // TODO: Prebaciti u App.xaml.cs
        public List<EquipmentDTO> Equipment {get;set;}

        public InventoryManagmentDTO() { }

        public InventoryManagmentDTO(long id, DateTime beginning, DateTime end, RoomDTO room)
        {
            Id = id;
            Beginning = beginning;
            End = end;
            Room = room;
            Equipment = new List<EquipmentDTO>();
        }

        public InventoryManagmentDTO(DateTime beginning, DateTime end, RoomDTO room)
        {
            Beginning = beginning;
            End = end;
            Room = room;
            Equipment = new List<EquipmentDTO>();
        }


    }
}
