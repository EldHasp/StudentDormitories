using CommLibrary;
using StDorVMLibrary.VMClasses;
using System.Collections.ObjectModel;

namespace StDorVMLibrary
{
    public partial class StDorViewModelDD : OnPropertyChangedClass, IStDorViewModel
    {
        public ObservableCollection<DormitoryVM> Dormitories { get; } = new ObservableCollection<DormitoryVM>();
        public DormitoryVM DormitorySelected { get => _dormitorySelected; set => SetProperty(ref _dormitorySelected, value); }
        public DormitoryVM DormitoryEdit { get => _dormitoryEdit; set => SetProperty(ref _dormitoryEdit, value); }

        public ObservableCollection<RoomVM> Rooms { get; } = new ObservableCollection<RoomVM>();
        public RoomVM RoomSelected { get => _roomSelected; set => SetProperty(ref _roomSelected, value); }
        public RoomVM RoomEdit { get => _roomEdit; set => SetProperty(ref _roomEdit, value); }

        public bool IsDormitoryModify { get => _isModeDormitoryModify; private set => SetProperty(ref _isModeDormitoryModify, value); }
        public bool IsModeDormitoryEdit { get => _isModeDormitoryEdit; private set => SetProperty(ref _isModeDormitoryEdit, value); }
        public bool IsModeDormitoryAdd { get => _isModeDormitoryAdd; private set => SetProperty(ref _isModeDormitoryAdd, value); }

        public bool IsRoomModify { get => _isModeRoomModify; private set => SetProperty(ref _isModeRoomModify, value); }
        public bool IsModeRoomEdit { get => _isModeRoomEdit; private set => SetProperty(ref _isModeRoomEdit, value); }
        public bool IsModeRoomAdd { get => _isModeRoomAdd; private set => SetProperty(ref _isModeRoomAdd, value); }

        public bool AllFalseIsMode => !(IsModeDormitoryEdit || IsModeDormitoryAdd || IsModeRoomEdit || IsModeRoomAdd);

        #region Поля для хранения значений свойств
        private DormitoryVM _dormitorySelected;
        private DormitoryVM _dormitoryEdit;
        private RoomVM _roomSelected;
        private RoomVM _roomEdit;
        private bool _isModeDormitoryModify;
        private bool _isModeDormitoryEdit;
        private bool _isModeDormitoryAdd;
        private bool _isModeRoomModify;
        private bool _isModeRoomEdit;
        private bool _isModeRoomAdd;
        private bool _allFalseIsMode;
        #endregion
    }
}
