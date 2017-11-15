using GalaSoft.MvvmLight;
using Shared.Interfaces;
using Simulation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace CodingDojo3.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private List<ItemVm> modelItems = new List<ItemVm>();
        private string currentTime = DateTime.Now.ToLocalTime().ToShortTimeString();
        private string currentDate = DateTime.Now.ToLocalTime().ToShortDateString();
        public ObservableCollection<ItemVm> SensorList { get; set; }
        public ObservableCollection<ItemVm> ActorList { get; set; }

        public string CurrentTime
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value; RaisePropertyChanged();
            }
        }

        public string CurrentDate
        {
            get
            {
                return currentDate;
            }

            set
            {
                currentDate = value; RaisePropertyChanged();
            }
        }
        public MainViewModel()
        {
            SensorList = new ObservableCollection<ItemVm>();
            ActorList = new ObservableCollection<ItemVm>();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += UpdateDateTime;
            if (!IsInDesignMode)
            {
                //load Data
                LoadData();

                //start timer for date/time update
                timer.Start();
            }
        }

        private void LoadData()
        {
            Simulator sim = new Simulator(modelItems);
            foreach (var item in sim.Items)
            {
                if (item.ItemType.Equals(typeof(ISensor)))
                    SensorList.Add(item);
                else if (item.ItemType.Equals(typeof(IActuator)))
                    ActorList.Add(item);
            }

        }

        private void UpdateDateTime(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToLocalTime().ToShortTimeString();
            CurrentDate = DateTime.Now.ToLocalTime().ToShortDateString();
    }
    }
}