using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class RoomRepository :
        CSVRepository<Room, long>,
        IRoomRepository,
        IEagerCSVRepository<Room, long>
    {
        private const string ENTITY_NAME = "Room";

        public RoomRepository(
            ICSVStream<Room> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }
        public new IEnumerable<Room> Find(Func<Room, bool> predicate) => GetAllEager().Where(predicate);
        public new Room Save(Room room)
        {
            if (IsRoomUnique(room.Id))
                return base.Save(room);
            else
                throw new Exception();
        }
        private bool IsRoomUnique(long id)
         => GetByIdNumber(id) == null;
        private Room GetByIdNumber(long id)
        => _stream.ReadAll().SingleOrDefault(patient => patient.Id.Equals(id));

        public IEnumerable<Room> GetAllEager() => GetAll();
        public Room GetEager(long id) => GetById(id);

    }
}
