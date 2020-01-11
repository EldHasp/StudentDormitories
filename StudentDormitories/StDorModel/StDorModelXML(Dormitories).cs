using CommLibrary;
using StDorModel.XMLClasses;
using StDorModelLibrary.DTOClasses;
using StDorModelLibrary.Interfaces;
using System.Collections.Immutable;
using System.Linq;

namespace StDorModel
{
    /// <summary>Модель для работы с XML файлом</summary>
    public partial class StDorModelXML : IDormitories
    {
        protected override ImmutableHashSet<DormitoryDTO> GetDormitories()
            => dormitoriesDTO.ToImmutable();

        protected override void AddDormitory(DormitoryDTO dormitory)
        {
            DormitoryXML dormXML = CreateDormitoryXML(dormitory);
            dormXML.ID = BaseId.NewId(studentDormitories.Dormitories);

            studentDormitories.Dormitories.Add(dormXML);
            Save();

            dormitoriesXML.Add(dormXML.ID, dormXML);

            DormitoryDTO dormDTO = CreateDormitoryDTO(dormXML);
            dormitoriesDTO.Add(dormDTO);

            OnAddDormitoriesEvent(ImmutableHashSet<DormitoryDTO>.Empty.Add(dormDTO));
        }

        protected override void ChangeDormitory(DormitoryDTO dormitory)
        {
            if (!dormitoriesXML.TryGetValue(dormitory.ID, out DormitoryXML dormXML))
                throw new StDorModelException($"Не найдено общежитие с ID={dormitory.ID}", StDorModelExceptionEnum.NoSuchID);

            CopyToDormitoryXML(dormitory, dormXML);
            Save();

            DormitoryDTO dormDTO = CreateDormitoryDTO(dormXML);

            dormitoriesDTO.Remove(dormitory);
            dormitoriesDTO.Add(dormDTO);

            OnChangedDormitoriesEvent(ImmutableHashSet<DormitoryDTO>.Empty.Add(dormDTO));
        }

        protected override void RemoveDormitory(DormitoryDTO dormitory)
        {
            if (!dormitoriesXML.TryGetValue(dormitory.ID, out DormitoryXML dormXML))
                throw new StDorModelException($"Не найдено общежитие с ID={dormitory.ID}", StDorModelExceptionEnum.NoSuchID);

            if (!EqualsDormitory(dormitory, dormXML))
                throw new StDorModelException($"Данные общежития с ID={dormitory.ID} не совпадают.", StDorModelExceptionEnum.DoNotMatch);

            if (roomsXML.Values.Any(rm => rm.DormitoryID == dormitory.ID))
                throw new StDorModelException($"В общежитии с ID={dormitory.ID} не удалены комнаты.", StDorModelExceptionEnum.SaveData);

            studentDormitories.Dormitories.Remove(dormXML);
            dormitoriesXML.Remove(dormXML.ID);
            Save();

            dormitoriesDTO.Remove(dormitory);

            OnRemoveDormitoriesEvent(ImmutableHashSet<DormitoryDTO>.Empty.Add(dormitory));
        }
    }
}
