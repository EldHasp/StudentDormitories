using CommLibrary;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace StDorModel.XMLClases
{
    /// <summary>Класс для десериализации из XML одной Комнаты</summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RoomXML : BaseId
    {

        /// <summary>ID общежития</summary>
        [XmlAttribute()]
        public byte DormitoryID { get; set; }

        /// <summary>Номер комнаты</summary>
        [XmlAttribute()]
        public ushort Number { get; set; }
    }
}
