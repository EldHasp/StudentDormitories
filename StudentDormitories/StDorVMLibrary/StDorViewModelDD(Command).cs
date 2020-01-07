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

        /// <summary>Метод добавления Общежития</summary>
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

        /// <summary>Метод редактирования Общежития</summary>
        /// <param name="dormitory">Редактируемое Общежитие</param>
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

        /// <summary>Метод удаления Общежития</summary>
        /// <param name="dormitory">Удаляемое Общежитие</param>
        protected virtual void DormitoryRemoveMetod(DormitoryVM dormitory)
        {
#if DEBUG
            ShowMetod($"{dormitory.ID} {dormitory.Title} {dormitory.Address}");
#endif
        }

        public RelayCommand DormitorySaveCommand => _dormitorySaveCommand ?? (_dormitorySaveCommand =
            new RelayCommandAction<DormitoryVM>(DormitorySaveMetod,
                _ => IsModeDormitoryEdit && IsDormitoryModify && DormitoryEdit != null));

        /// <summary>Метод сохранения Общежития</summary>
        protected void DormitorySaveMetod(DormitoryVM dormitory)
        {
#if DEBUG
            ShowMetod($" {DormitoryEdit.ID} {DormitoryEdit.Title} {DormitoryEdit.Address}");
#endif
            if (IsModeDormitoryAdd)
                DormitorySaveAddMetod(dormitory);
            else
                DormitorySaveChangeMetod(dormitory);

            /// После сохранения выход из режима редактирования
            DormitoryCancelMetod();
        }

        /// <summary>Метод сохранения добавляемого Общежития</summary>
        protected virtual void DormitorySaveAddMetod(DormitoryVM dormitory)
        {
#if DEBUG
            ShowMetod($"Добавляется {DormitoryEdit.ID} {DormitoryEdit.Title} {DormitoryEdit.Address}");
#endif
        }
        /// <summary>Метод сохранения изменяемого Общежития</summary>
        protected virtual void DormitorySaveChangeMetod(DormitoryVM dormitory)
        {
#if DEBUG
            ShowMetod($"Сохраняется {DormitoryEdit.ID} {DormitoryEdit.Title} {DormitoryEdit.Address}");
#endif
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

        /// <summary>Метод добавления Комнаты</summary>
        protected virtual void RoomAddMetod()
        {
#if DEBUG
            ShowMetod();
#endif

            /// Создание нового экземпляра для добавления
            RoomEdit = new RoomVM() { DormitoryID = DormitorySelected.ID };
            /// Установка режимов
            IsModeRoomEdit = IsModeRoomAdd = true;
        }

        public RelayCommand RoomEditCommand => _roomEditCommand ?? (_roomEditCommand =
            new RelayCommandAction<RoomVM>(RoomEditMetod, _ => AllFalseIsMode));

        /// <summary>Метод редактирования Комнаты</summary>
        /// <param name="room">Редактируемая Комната</param>
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

        /// <summary>Метод удаления Комнаты</summary>
        /// <param name="room">Удаляемая Комната</param>
        protected virtual void RoomRemoveMetod(RoomVM room)
        {
#if DEBUG
            ShowMetod($"{room.ID} {room.DormitoryID} {room.Number}");
#endif
        }


        public RelayCommand RoomSaveCommand => _roomSaveCommand ?? (_roomSaveCommand =
            new RelayCommandAction<RoomVM>(RoomSaveMetod,
                _ => IsModeRoomEdit && IsRoomModify && RoomEdit != null));

        /// <summary>Метод сохранения Общежития</summary>
        protected void RoomSaveMetod(RoomVM room)
        {
#if DEBUG
            ShowMetod($"{RoomEdit.ID} {RoomEdit.DormitoryID} {RoomEdit.Number}");
#endif
            if (IsModeRoomAdd)
                RoomSaveAddMetod(room);
            else
                RoomSaveChangeMetod(room);
            /// После сохранения выход из режима редактирования
            RoomCancelMetod();
        }


        /// <summary>Метод сохранения добавляемой Комнаты</summary>
        protected virtual void RoomSaveAddMetod(RoomVM room)
        {
#if DEBUG
            ShowMetod($"Добавляется {RoomEdit.ID} {RoomEdit.DormitoryID} {RoomEdit.Number}");
#endif
        }
        /// <summary>Метод сохранения изменяемой Комнаты</summary>
        protected virtual void RoomSaveChangeMetod(RoomVM room)
        {
#if DEBUG
            ShowMetod($"Сохраняется {RoomEdit.ID} {RoomEdit.DormitoryID} {RoomEdit.Number}");
#endif
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
            IsRoomModify = IsModeRoomEdit = IsModeRoomAdd = false;
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
