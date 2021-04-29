using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class FormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? ""));


        private Dictionary<string, object> _backingDict = new Dictionary<string, object>();

        private T GetProp<T>([CallerMemberName] string propertyName = "")
        {
            if (_backingDict.TryGetValue(propertyName, out object val) && val is T)
            {
                return (T)val;
            }
            return default;
        }

        private void SetProp<T>(T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(GetProp<T>(), value))
            {
                return;
            }
            _backingDict.Add(propertyName, value);
            OnPropertyChanged(propertyName);

        }



        public string Url { get => GetProp<string>(); set => SetProp(value); }



    }
}
