using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace Project.Views.Converters
{
    public class OrderConverter : IConverter<Order, OrderDTO>
    {
        private MedicalConsumableConverter _medicalConsumableConverter;
        private MedicineConverter _medicineConverter;
        private EquipmentConverter _equipmentConverter;

        public OrderConverter(MedicalConsumableConverter medicalConsumableConverter,
            MedicineConverter medicineConverter,
            EquipmentConverter equipmentConverter
        )
        {
            _medicalConsumableConverter = medicalConsumableConverter;
            _medicineConverter = medicineConverter;
            _equipmentConverter = equipmentConverter;
        }

        public Order ConvertDTOToEntity(OrderDTO dto)
        {
            List<MedicineDTO> medicineDTO = dto.Medicine;
            List<MedicalConsumableDTO> consumablesDTO = dto.Consumables;
            List<EquipmentDTO> equipmentDTO = dto.Equipment;

            List<Medicine> medicine = new List<Medicine>();
            List<MedicalConsumables> consumables = new List<MedicalConsumables>();
            List<Equipment> equipment = new List<Equipment>();

            foreach (MedicineDTO med in medicineDTO)
                medicine.Add(_medicineConverter.ConvertDTOToEntity(med));

            foreach (MedicalConsumableDTO medCons in consumablesDTO)
                consumables.Add(_medicalConsumableConverter.ConvertDTOToEntity(medCons));

            foreach (EquipmentDTO eq in equipmentDTO)
                equipment.Add(_equipmentConverter.ConvertDTOToEntity(eq));

            return new Order(dto.Id,dto.Date,dto.Supplier,equipment,consumables,medicine);       
        }

        public OrderDTO ConvertEntityToDTO(Order entity)
        {
            List<Medicine> medicine = entity.Medicine;
            List<MedicalConsumables> consumables = entity.Consumebles;
            List<Equipment> equipment = entity.Equipments;

            List<MedicineDTO> medicineDTO = new List<MedicineDTO>();
            List<MedicalConsumableDTO> consumablesDTO = new List<MedicalConsumableDTO>();
            List<EquipmentDTO> equipmentDTO = new List<EquipmentDTO>();

            foreach (Medicine med in medicine)
                medicineDTO.Add(_medicineConverter.ConvertEntityToDTO(med));

            foreach (MedicalConsumables medCons in consumables)
                consumablesDTO.Add(_medicalConsumableConverter.ConvertEntityToDTO(medCons));

            foreach (Equipment eq in equipment)
                equipmentDTO.Add(_equipmentConverter.ConvertEntityToDTO(eq));

            return new OrderDTO(entity.Id, entity.Date, entity.Supplier, equipmentDTO, consumablesDTO, medicineDTO);
        }

        public List<Order> ConvertListDTOToListEntity(IEnumerable<OrderDTO> dtos)
         => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<OrderDTO> ConvertListEntityToListDTO(List<Order> entities)
         => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
