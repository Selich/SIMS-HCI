using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Views.Model;
using Project.Model;
using Project.Views.Converters;
using Project.Services;

namespace Project.Controllers
{
    public class AnamnesisController : IController<AnamnesisDTO, long>
    {
        private IService<Anamnesis, long> _service;
        private IConverter<Anamnesis, AnamnesisDTO> _anamnesisConverter;
        public AnamnesisController(
            IService<Anamnesis, long> service,
            IConverter<Anamnesis, AnamnesisDTO> anamnesisConverter
            )
        {
            _service = service;
            _anamnesisConverter = anamnesisConverter;
        }
        public IEnumerable<AnamnesisDTO> GetAll()
            => _anamnesisConverter.ConvertListEntityToListDTO((List<Anamnesis>)_service.GetAll());
        
        public AnamnesisDTO GetById(long id)
            => _anamnesisConverter.ConvertEntityToDTO(_service.GetById(id));

        public AnamnesisDTO Remove(AnamnesisDTO entity)
            => _anamnesisConverter.ConvertEntityToDTO(_service.Remove(_anamnesisConverter.ConvertDTOToEntity(entity)));

        public AnamnesisDTO Save(AnamnesisDTO entity)
            => _anamnesisConverter.ConvertEntityToDTO(_service.Save(_anamnesisConverter.ConvertDTOToEntity(entity)));

        public AnamnesisDTO Update(AnamnesisDTO entity)
            => _anamnesisConverter.ConvertEntityToDTO(_service.Update(_anamnesisConverter.ConvertDTOToEntity(entity)));
    }
}
