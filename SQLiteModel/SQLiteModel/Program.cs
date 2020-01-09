using StDorModelLibrary.DTOClasses;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SQLiteModel
{
    class Program
    {
        static void Main(string[] args)
        {

            List<RoomDTO> Rooms;
            List<DormitoryDTO> Dormitories;
            List<DormitoryDTO> RoomsDormitories;
            List<List<RoomDTO>> DormitoriesRooms;
            int rCount;
            int dCount;
            using (StudentDormitoriesContext sdc = new StudentDormitoriesContext())
            {
                sdc.Dormitories.Load();
                Dormitories = new List<DormitoryDTO>();
                DormitoriesRooms = new List<List<RoomDTO>>();
                foreach (DormitoryBD dorm in sdc.Dormitories)
                {
                    Dormitories.Add(dorm.Copy());
                    DormitoriesRooms
                        .Add(new List<RoomDTO>(dorm.Rooms.Select(rm => rm.Copy()))); 
                }

                sdc.Rooms.Load();
                Rooms = new List<RoomDTO>();
                RoomsDormitories = new List<DormitoryDTO>();

                foreach (RoomBD room in sdc.Rooms)
                {
                    Rooms.Add(room.Copy());
                    RoomsDormitories.Add(room.Dormitory.Copy()); // Здесь room.Dormitory = null
                }

                rCount = Rooms.Count();
                dCount = Dormitories.Count();
            }


        }
    }
}
