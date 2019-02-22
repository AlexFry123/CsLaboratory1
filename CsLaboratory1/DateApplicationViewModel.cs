using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CsLaboratory1
{
    internal enum WesternZodiac { Ram, Bull, Twins, Crab, Lion, Virgin, Scales, Scorpion, Archer, Goat, WaterBearer, Fish };
    internal enum ChineseZodiac { Monkey, Rooster, Dog, Pig, Rat, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Goat };

    class DateApplicationViewModel : INotifyPropertyChanged
    {
        private DateOfBirth _user;
        private DateTime _chosenDate;
        private string _age;
        private string _zodiacWestern;
        private string _zodiacChinese;
        public Visibility LoaderVisibility { get; set; }
        public bool IsEnabled { get; set; }

        public DateTime ChosenDate
        {
            get { return _chosenDate; }
            set
            {
                _chosenDate = value;
                SettingDate();
            }
        }

        public string Age
        {
            get { return "" + _user._age; }
        }

        public WesternZodiac ZodiacWestern
        {
            get { return _user._zodiacWestern; }
        }

        public ChineseZodiac ZodiacChinese
        {
            get { return _user._zodiacChinese; }
        }

        public DateApplicationViewModel()
        {
            LoaderVisibility = Visibility.Hidden;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoaderVisibility"));
            _chosenDate = new DateTime(2000, 2, 12);
            _user = new DateOfBirth(ref _chosenDate);
            _age = "" + _user._age;
            _zodiacWestern = "" + _user._zodiacWestern;
            _zodiacChinese = "" + _user._zodiacChinese;
            IsEnabled = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEnabled"));
        }

        private async void SettingDate()
        {
            LoaderVisibility = Visibility.Visible;
            IsEnabled = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEnabled"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoaderVisibility"));
            _user = new DateOfBirth(ref _chosenDate);
            await Task.Run(() => Thread.Sleep(1500));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ZodiacWestern"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ZodiacChinese"));
            IsEnabled = true;
            LoaderVisibility = Visibility.Hidden;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEnabled"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoaderVisibility"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
