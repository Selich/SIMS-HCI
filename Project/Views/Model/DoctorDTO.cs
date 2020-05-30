using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class DoctorDTO : EmplyeeDTO
    {
        public string MedicalRole { get; set; }
        public float AvrageReviewScore { get; set; }

        public DoctorDTO() { }

        /// <summary>
        /// Property for collection of Approval
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<ApprovalDTO> Approval
        {
            get;
            set;
        }


        /// <summary>
        /// Property for collection of MedicalAppointment
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<MedicalAppointmentDTO> Appointments
        {
            get;
            set;
        }

        /// <summary>
        /// Add a new MedicalAppointment in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>


        /// <summary>
        /// Remove an existing MedicalAppointment from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>


        /// <summary>
        /// Remove all instances of MedicalAppointment from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>


    }
}

