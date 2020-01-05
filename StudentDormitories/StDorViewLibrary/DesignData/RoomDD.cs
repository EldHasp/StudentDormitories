using CommLibrary;
using StDorVMLibrary.Interfaces;
using System.Collections.ObjectModel;

namespace StDorViewLibrary.DesignData
{
    public class RoomDD : OnPropertyChangedClass, IRoom
    {
        private int _dormitoryID;
        private int _number;
        private int _id;
        public int DormitoryID { get => _dormitoryID; set => SetProperty(ref _dormitoryID, value); }
        public int Number { get => _number; set => SetProperty(ref _number, value); }
        public int ID { get => _id; set => SetProperty(ref _id, value); }
    }

    public class RoomEditDD : OnPropertyChangedClass, IRoomEdit
    {
        private IRoom _roomEdit;
        private bool _isRoomModify;
        private bool _isModeRoomEdit;
        private bool _isModeRoomAdd;

        public ObservableCollection<IDormitory> Dormitories { get; } = new ObservableCollection<IDormitory>();
        public IRoom RoomEdit { get => _roomEdit; set => SetProperty(ref _roomEdit, value); }
        public bool IsRoomModify { get => _isRoomModify; set => SetProperty(ref _isRoomModify, value); }
        public bool IsModeRoomEdit { get => _isModeRoomEdit; set => SetProperty(ref _isModeRoomEdit, value); }
        public bool IsModeRoomAdd { get => _isModeRoomAdd; set => SetProperty(ref _isModeRoomAdd, value); }
    }

    public class RoomsDD : RoomEditDD, IRoomsVM
    {
        private IDormitory _dormitorySelected;
        private IRoom _roomSelected;
        private bool _allFalseIsMode;

        public IDormitory DormitorySelected { get => _dormitorySelected; set => SetProperty(ref _dormitorySelected, value); }
        public ObservableCollection<IRoom> Rooms { get; } = new ObservableCollection<IRoom>();
        public IRoom RoomSelected  { get => _roomSelected; set => SetProperty(ref _roomSelected, value); }
        public bool AllFalseIsMode  { get => _allFalseIsMode; set => SetProperty(ref _allFalseIsMode, value); }

        public RelayCommand RoomAddCommand { get; }
        public RelayCommand RoomEditCommand { get; }
        public RelayCommand RoomRemoveCommand { get; }
        public RelayCommand RoomSaveCommand { get; }
        public RelayCommand RoomCancelCommand { get; }
    }
}
