using GalaSoft.MvvmLight;
using System;
using System.Windows.Threading;

namespace CodingDojo3.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private string currentTime = DateTime.Now.ToLocalTime().ToShortTimeString();
        private string currentDate = DateTime.Now.ToLocalTime().ToShortDateString();

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
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += UpdateDateTime;
            timer.Start();
        }

        private void UpdateDateTime(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToLocalTime().ToShortTimeString();
            CurrentDate = DateTime.Now.ToLocalTime().ToShortDateString();
    }
    }
}