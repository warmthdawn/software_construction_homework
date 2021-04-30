using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class DownloadingUrl : INotifyPropertyChanged
    {
        private string url;
        private DateTime startTime;

        public DateTime StartTime
        {
            get => startTime;
            set
            {
                startTime = value;
                OnPropertyChanged();
            }
        }
        public string Url
        {
            get => url; set
            {
                url = value;
                OnPropertyChanged();
            }
        }
        public double SecondsElasped
        {
            get
            {
                return (int)((DateTime.Now - StartTime).TotalSeconds * 100) / 100.0;
            }
        }

        public void RefreshSecond()
        {
            OnPropertyChanged(nameof(SecondsElasped));
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? ""));


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
