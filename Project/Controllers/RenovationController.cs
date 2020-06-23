using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class RenovationController:IController<RenovationDTO,long>
    {
        private IService<Renovation, long> _service;
        private IConverter<Renovation, RenovationDTO> _renovationConverter;

        public RenovationController(
            IService<Renovation,long> service,
            IConverter<Renovation,RenovationDTO> renovationConverter)
        {
            _service = service;
            _renovationConverter = renovationConverter;
        }
        // TODO: Maybe in RoomController?
        // TODO: Add method
        public RenovationDTO MergeRooms(long id)
           => _renovationConverter.ConvertEntityToDTO(_service.GetById(id));
        // TODO: Maybe in RoomController?
        // TODO: Add method
        public RenovationDTO SplitRooms(long id)
           => _renovationConverter.ConvertEntityToDTO(_service.GetById(id));
        public RenovationDTO GetById(long id)
           => _renovationConverter.ConvertEntityToDTO(_service.GetById(id));

        public IEnumerable<RenovationDTO> GetAll()
            => _renovationConverter.ConvertListEntityToListDTO((List<Renovation>)_service.GetAll());

        public RenovationDTO Remove(RenovationDTO entity)
            => _renovationConverter.ConvertEntityToDTO(_service.Remove(_renovationConverter.ConvertDTOToEntity(entity)));

        public RenovationDTO Save(RenovationDTO entity)
            => _renovationConverter.ConvertEntityToDTO(_service.Save(_renovationConverter.ConvertDTOToEntity(entity)));

        public RenovationDTO Update(RenovationDTO entity)
            => _renovationConverter.ConvertEntityToDTO(_service.Update(_renovationConverter.ConvertDTOToEntity(entity)));



    }
}
