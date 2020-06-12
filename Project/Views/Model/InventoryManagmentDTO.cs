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
        private List<EquipmentDTO> equipment;
        public List<EquipmentDTO> Equipment
        {
            get
            {
                return equipment;
            }
            set
            {
                if (value != equipment)
                {
                    equipment = value;
                    OnPropertyChanged("Equipment");
                }
            }
        }

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



        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
