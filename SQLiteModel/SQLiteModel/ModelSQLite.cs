using StDorModelLibrary;
using StDorModelLibrary.DTOClasses;
using StDorModelLibrary.Interfaces;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace SQLiteModel
{
    public class ModelSQLite : StDorModelBase
    {
        public string ConnectionName { get; }
        public ModelSQLite(string connectionName)
        {
            ConnectionName = connectionName;
        }

        protected override ImmutableHashSet<DormitoryDTO> GetDormitories()
        {
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
                return modelContext.Dormitories
                    .AsNoTracking()
                    .ToList()
                    .Select(dr => dr.CopyDTO())
                    .ToImmutableHashSet();
        }

        protected override void AddDormitory(DormitoryDTO dormitory)
        {
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
            {
                DormitoryBD dormitoryBd = new DormitoryBD(dormitory);
                modelContext.Dormitories.Add(dormitoryBd);
                if (modelContext.SaveChanges() != 1)
                    throw new StDorModelException($"Данные не сохранены", StDorModelExceptionEnum.SaveData);
            }
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
            {
                OnAddDormitoriesEvent(ImmutableHashSet<DormitoryDTO>.Empty.Add(modelContext.Dormitories.Find(dormitory.ID).CopyDTO()));
            }
        }


        protected override void RemoveDormitory(DormitoryDTO dormitory)
        {
            DormitoryBD dormitoryBd;
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
            {
                dormitoryBd = modelContext.Dormitories.Find(dormitory.ID);
                if (dormitoryBd == null)
                    throw new StDorModelException($"Не найдено общежитие с ID={dormitory.ID}", StDorModelExceptionEnum.NoSuchID);
                if (!dormitoryBd.EqualValues(dormitory))
                    throw new StDorModelException($"Данные общежития с ID={dormitory.ID} не совпадают.", StDorModelExceptionEnum.DoNotMatch);

                modelContext.Dormitories.Remove(dormitoryBd);
                try
                {
                    if (modelContext.SaveChanges() != 1)
                        throw new StDorModelException($"Ошибка сохранения", StDorModelExceptionEnum.SaveData);
                }
                catch (Exception ex)
                {
                    throw new StDorModelException($"Данные не сохранены", StDorModelExceptionEnum.SaveData, ex);
                }
            }

            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
            {
                if (modelContext.Dormitories.Find(dormitory.ID) != null)
                    throw new StDorModelException($"Общежития с ID={dormitory.ID} не удалено.", StDorModelExceptionEnum.SaveData);
                OnRemoveDormitoriesEvent(ImmutableHashSet<DormitoryDTO>.Empty.Add(dormitoryBd.CopyDTO()));
            }
        }


        protected override void ChangeDormitory(DormitoryDTO dormitory)
        {
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
            {
                DormitoryBD dormitoryBd = modelContext.Dormitories.Find(dormitory.ID);
                if (dormitoryBd == null)
                    throw new StDorModelException($"Не найдено общежитие с ID={dormitory.ID}", StDorModelExceptionEnum.NoSuchID);
                modelContext.Dormitories.Attach(dormitoryBd);
                if (modelContext.SaveChanges() != 1)
                    throw new StDorModelException($"Данные не сохранены", StDorModelExceptionEnum.SaveData);
            }
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
                OnChangedDormitoriesEvent(ImmutableHashSet<DormitoryDTO>.Empty.Add(modelContext.Dormitories.Find(dormitory.ID).CopyDTO()));
        }

        protected override void AddRoom(RoomDTO room)
        {
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
            {
                DormitoryBD dormitoryBd = modelContext.Dormitories.Find(room.DormitoryID);
                if (dormitoryBd == null)
                    throw new StDorModelException($"Не найдено общежитие с ID={room.DormitoryID}", StDorModelExceptionEnum.NoSuchID);

                RoomBD roomBd = new RoomBD();
                roomBd.CopyFromDTO(room);
                modelContext.Rooms.Add(roomBd);
                if (modelContext.SaveChanges() != 1)
                    throw new StDorModelException($"Данные не сохранены", StDorModelExceptionEnum.SaveData);

            }
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
                OnAddRoomsEvent(ImmutableHashSet<RoomDTO>.Empty.Add(modelContext.Rooms.Find(room.ID).CopyDTO()));
        }

        protected override void ChangeRoom(RoomDTO room)
        {
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
            {
                RoomBD roomBd = modelContext.Rooms.Find(room.ID);
                if (roomBd == null)
                    throw new StDorModelException($"Не найдена комната с ID={room.ID}", StDorModelExceptionEnum.NoSuchID);
                modelContext.Rooms.Attach(roomBd);
                if (modelContext.SaveChanges() != 1)
                    throw new StDorModelException($"Данные не сохранены", StDorModelExceptionEnum.SaveData);
            }

            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
                OnChangedRoomsEvent(ImmutableHashSet<RoomDTO>.Empty.Add(modelContext.Rooms.Find(room.ID).CopyDTO()));
        }

        protected override ImmutableHashSet<RoomDTO> GetRooms()
        {
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
                return modelContext.Rooms.AsNoTracking().ToList().Select(rm => rm.CopyDTO()).ToImmutableHashSet();

        }

        protected override ImmutableHashSet<RoomDTO> GetRooms(DormitoryDTO dormitory)
        {
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
            {
                DormitoryBD dormitoryBd = modelContext.Dormitories.Find(dormitory.ID);

                if (dormitoryBd == null)
                    throw new StDorModelException($"Не найдено общежитие с ID={dormitory.ID}", StDorModelExceptionEnum.NoSuchID);
                if (!dormitoryBd.EqualValues(dormitory))
                    throw new StDorModelException($"Данные общежития с ID={dormitory.ID} не совпадают.", StDorModelExceptionEnum.DoNotMatch);

                return modelContext.Rooms
                    .AsNoTracking()
                    .Where(rm => rm.DormitoryID == dormitoryBd.ID)
                    .ToList()
                    .Select(rm => rm.CopyDTO())
                    .ToImmutableHashSet();
            }
        }

        protected override void RemoveRoom(RoomDTO room)
        {
            RoomBD roomBd;
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
            {
                roomBd = modelContext.Rooms.Find(room.ID);
                if (roomBd == null)
                    throw new StDorModelException($"Не найдена комната с ID={room.ID}", StDorModelExceptionEnum.NoSuchID);
                if (!roomBd.EqualValues(room))
                    throw new StDorModelException($"Данные комнаты с ID={room.ID} не совпадают.", StDorModelExceptionEnum.DoNotMatch);

                modelContext.Rooms.Remove(roomBd);
                if (modelContext.SaveChanges() != 1)
                    throw new StDorModelException($"Данные не сохранены", StDorModelExceptionEnum.SaveData);
            }
            using (StudentDormitoriesContext modelContext = new StudentDormitoriesContext(ConnectionName))
            {
                if (modelContext.Rooms.Find(roomBd.ID) != null)
                    throw new StDorModelException($"Комната с ID={room.ID} не удалена.", StDorModelExceptionEnum.SaveData);

                OnRemoveRoomsEvent(ImmutableHashSet<RoomDTO>.Empty.Add(roomBd.CopyDTO()));
            }
        }
    }
}
