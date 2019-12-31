using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace StDorModel.XMLClasses
{
    /// <summary>Root Класс для десериализации XML с данными</summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(IsNullable = false, ElementName ="StudentDormitories")]
    public class StudentDormitoriesXML
    {

        /// <summary>Множество Общежитий</summary>
        [XmlArrayItem("Dormitory", IsNullable = false)]
        public HashSet<DormitoryXML> Dormitories { get; set; }

        /// <summary>Множество Комнат</summary>
        [XmlArrayItem("Room", IsNullable = false)]
        public HashSet<RoomXML> Rooms { get; set; }
    }
}
