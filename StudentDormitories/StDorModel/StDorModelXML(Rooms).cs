using CommLibrary;
using StDorModel.XMLClasses;
using StDorModelLibrary.DTOClasses;
using StDorModelLibrary.Interfaces;
using System.Collections.Immutable;
using System.Linq;

namespace StDorModel
{
    /// <summary>Модель для работы с XML файлом</summary>
    public partial class StDorModelXML : IRooms
    {
        protected override ImmutableHashSet<RoomDTO> GetRooms()
           => roomsDTO.ToImmutable();

        protected override ImmutableHashSet<RoomDTO> GetRooms(DormitoryDTO dormitory)
            => roomsDTO.Where(room => room.DormitoryID == dormitory.ID).ToImmutableHashSet();

        protected override void AddRoom(RoomDTO room)
        {
            if (!dormitoriesXML.ContainsKey(room.DormitoryID))
                throw new StDorModelException($"Не найдено общежитие с ID={room.DormitoryID}", StDorModelExceptionEnum.NoSuchID);

            RoomXML roomXML = CreateRoomXML(room);
            roomXML.ID = BaseId.NewId(studentDormitories.Rooms);

            studentDormitories.Rooms.Add(roomXML);
            Save();

            roomsXML.Add(roomXML.ID, roomXML);

            RoomDTO roomDTO = CreateRoomDTO(roomXML);
            roomsDTO.Add(roomDTO);

            OnAddRoomsEvent(ImmutableHashSet<RoomDTO>.Empty.Add(roomDTO));
        }

        protected override void ChangeRoom(RoomDTO room)
        {
            if (!roomsXML.TryGetValue(room.ID, out RoomXML roomXML))
                throw new StDorModelException($"Не найдена комната с ID={room.ID}", StDorModelExceptionEnum.NoSuchID);

            CopyToRoomXML(room, roomXML);
            Save();

            RoomDTO roomDTO = CreateRoomDTO(roomXML);

            roomsDTO.Remove(room);
            roomsDTO.Add(roomDTO);

            OnChangedRoomsEvent(ImmutableHashSet<RoomDTO>.Empty.Add(roomDTO));
        }

        protected override void RemoveRoom(RoomDTO room)
        {
            if (!roomsXML.TryGetValue(room.ID, out RoomXML roomXML))
                throw new StDorModelException($"Не найдена комната с ID={room.ID}", StDorModelExceptionEnum.NoSuchID);

            if (!EqualsRoom(room, roomXML))
                throw new StDorModelException($"Данные комнаты с ID={room.ID} не совпадают.", StDorModelExceptionEnum.DoNotMatch);

            studentDormitories.Rooms.Remove(roomXML);
            roomsXML.Remove(roomXML.ID);
            Save();

           var res = roomsDTO.Remove(room);

            OnRemoveRoomsEvent(ImmutableHashSet<RoomDTO>.Empty.Add(room));
        }
    }
}
