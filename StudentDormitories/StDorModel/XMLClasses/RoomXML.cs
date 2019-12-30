using CommLibrary;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace StDorModel.XMLClasses
{
    /// <summary>Класс для десериализации из XML одной Комнаты</summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RoomXML : BaseId
    {

        /// <summary>ID общежития</summary>
        [XmlAttribute()]
        public int DormitoryID { get; set; }

        /// <summary>Номер комнаты</summary>
        [XmlAttribute()]
        public int Number { get; set; }
    }
}
