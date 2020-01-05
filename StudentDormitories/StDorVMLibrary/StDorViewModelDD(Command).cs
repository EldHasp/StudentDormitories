using CommLibrary;
using StDorVMLibrary.Interfaces;
using StDorVMLibrary.VMClasses;
using System.Runtime.CompilerServices;
using System.Windows;

namespace StDorVMLibrary
{
    public partial class StDorViewModelDD : OnPropertyChangedClass, IStDorViewModel
    {
#if DEBUG
        /// <summary>Показывать исполняемые методы</summary>
        protected bool ShowExecutableMethod = true;
        /// <summary>Показ вызванного метода</summary>
        /// <param name="metodName">Название метода</param>
        protected void ShowMetod(string message = null, [CallerMemberName] string metodName = null)
        {
            if (ShowExecutableMethod)
                MessageBox.Show($"Вызван метод {metodName}"
                    + (message != null ? $": {message}" : ""));
        }
#endif

        public RelayCommand DormitoryAddCommand => _dormitoryAddCommand ?? (_dormitoryAddCommand =
            new RelayCommandAction(DormitoryAddMetod, () => AllFalseIsMode));

        /// <summary>Метод добавления общежития</summary>
        protected virtual void DormitoryAddMetod()
        {
#if DEBUG
            ShowMetod();
#endif

            /// Создание нового экземпляра для добавления
            DormitoryEdit = new DormitoryVM();
            /// Установка режимов
            IsModeDormitoryEdit = IsModeDormitoryAdd = true;
        }

        public RelayCommand DormitoryEditCommand => _dormitoryEditCommand ?? (_dormitoryEditCommand =
            new RelayCommandAction<DormitoryVM>(DormitoryEditMetod, _ => AllFalseIsMode));

        /// <summary>Метод редактирования общежития</summary>
        /// <param name="dormitory">Редактируемое общежитие</param>
        protected virtual void DormitoryEditMetod(DormitoryVM dormitory)
        {
#if DEBUG
            ShowMetod($"{dormitory.ID} {dormitory.Title} {dormitory.Address}");
#endif

            /// Запись экземпляра для редактирования
            DormitoryEdit = dormitory.Copy();
            IsModeDormitoryEdit = true;
            IsModeDormitoryAdd = false;
        }

        public RelayCommand DormitoryRemoveCommand => _dormitoryRemoveCommand ?? (_dormitoryRemoveCommand =
            new RelayCommandAction<DormitoryVM>(DormitoryRemoveMetod, _ => AllFalseIsMode));

        /// <summary>Метод удаления общежития</summary>
        /// <param name="dormitory">Удаляемое общежитие</param>
        protected virtual void DormitoryRemoveMetod(DormitoryVM dormitory)
        {
#if DEBUG
            ShowMetod($"{dormitory.ID} {dormitory.Title} {dormitory.Address}");
#endif
        }

        public RelayCommand DormitorySaveCommand => _dormitorySaveCommand ?? (_dormitorySaveCommand =
            new RelayCommandAction(DormitorySaveMetod,
                () => IsModeDormitoryEdit && IsDormitoryModify && DormitoryEdit != null));

        /// <summary>Метод сохранения общежития из свойства DormitoryEdit</summary>
        protected virtual void DormitorySaveMetod()
        {
#if DEBUG
            ShowMetod($"{DormitoryEdit.ID} {DormitoryEdit.Title} {DormitoryEdit.Address}");
#endif
            /// После сохранения выход из режима редактирования
            DormitoryCancelMetod();
        }

        public RelayCommand DormitoryCancelCommand => _dormitoryCancelCommand ?? (_dormitoryCancelCommand =
            new RelayCommandAction(DormitoryCancelMetod, () => IsModeDormitoryEdit));

        /// <summary>Метод отмены изменений</summary>
        protected virtual void DormitoryCancelMetod()
        {
#if DEBUG
            ShowMetod();
#endif
            DormitoryEdit = null;
            IsDormitoryModify = IsModeDormitoryEdit = IsModeDormitoryAdd = false;
        }

        public RelayCommand RoomAddCommand => _roomAddCommand ?? (_roomAddCommand =
            new RelayCommandAction(RoomAddMetod, () => AllFalseIsMode));

        /// <summary>Метод добавления комнаты</summary>
        protected virtual void RoomAddMetod()
        {
#if DEBUG
            ShowMetod();
#endif

            /// Создание нового экземпляра для добавления
            RoomEdit = new RoomVM();
            /// Установка режимов
            IsModeRoomEdit = IsModeRoomAdd = true;
        }

        public RelayCommand RoomEditCommand => _roomEditCommand ?? (_roomEditCommand =
            new RelayCommandAction<RoomVM>(RoomEditMetod, _ => AllFalseIsMode));

        /// <summary>Метод редактирования комнаты</summary>
        /// <param name="room">Редактируемая комната</param>
        protected virtual void RoomEditMetod(RoomVM room)
        {
#if DEBUG
            ShowMetod($"{room.ID} {room.DormitoryID} {room.Number}");
#endif

            /// Запись экземпляра для редактирования
            RoomEdit = (room as RoomVM).Copy();
            IsModeRoomEdit = true;
            IsModeRoomAdd = false;
        }

        public RelayCommand RoomRemoveCommand => _roomRemoveCommand ?? (_roomRemoveCommand =
            new RelayCommandAction<RoomVM>(RoomRemoveMetod, _ => AllFalseIsMode));

        /// <summary>Метод удаления комнаты</summary>
        /// <param name="room">Удаляемая комната</param>
        protected virtual void RoomRemoveMetod(RoomVM room)
        {
#if DEBUG
            ShowMetod($"{room.ID} {room.DormitoryID} {room.Number}");
#endif
        }


        public RelayCommand RoomSaveCommand => _roomSaveCommand ?? (_roomSaveCommand =
            new RelayCommandAction(RoomSaveMetod,
                () => IsModeRoomEdit && IsRoomModify && RoomEdit != null));

        /// <summary>Метод сохранения общежития из свойства DormitoryEdit</summary>
        protected virtual void RoomSaveMetod()
        {
#if DEBUG
            ShowMetod($"{RoomEdit.ID} {RoomEdit.DormitoryID} {RoomEdit.Number}");
#endif
            /// После сохранения выход из режима редактирования
            RoomCancelMetod();
        }


        public RelayCommand RoomCancelCommand => _roomCancelCommand ?? (_roomCancelCommand =
            new RelayCommandAction(RoomCancelMetod, () => IsModeRoomEdit));

        /// <summary>Метод отмены изменений</summary>
        protected virtual void RoomCancelMetod()
        {
#if DEBUG
            ShowMetod();
#endif
            RoomEdit = null;
            IsModeRoomEdit = IsModeRoomAdd = false;
        }

        #region Поля для хранения значений свойств-команд
        private RelayCommand _dormitoryAddCommand;
        private RelayCommand _dormitoryEditCommand;
        private RelayCommand _dormitoryRemoveCommand;
        private RelayCommand _dormitorySaveCommand;
        private RelayCommand _dormitoryCancelCommand;
        private RelayCommand _roomAddCommand;
        private RelayCommand _roomEditCommand;
        private RelayCommand _roomRemoveCommand;
        private RelayCommand _roomSaveCommand;
        private RelayCommand _roomCancelCommand;
        #endregion
    }
}
