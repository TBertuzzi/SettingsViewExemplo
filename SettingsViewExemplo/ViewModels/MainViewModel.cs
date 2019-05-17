using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SettingsViewExemplo.Models;
using Xamarin.Forms;

namespace SettingsViewExemplo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Property

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        string _inputText = string.Empty;
        public string InputText
        {
            get { return _inputText; }
            set
            {
                SetProperty(ref _inputText, value);

            }
        }

        string _inputError = string.Empty;
        public string InputError
        {
            get { return _inputError; }
            set
            {
                SetProperty(ref _inputError, value);

            }
        }

        bool _inputSectionVisible = true;
        public bool InputSectionVisible
        {
            get { return _inputSectionVisible; }
            set
            {
                SetProperty(ref _inputSectionVisible, value);

            }
        }

        public ObservableCollection<Person> ItemsSource { get; }
        public ObservableCollection<Person> SelectedItems { get; } 

        public ObservableCollection<string> TextItems { get; } 
        public string SelectedText { get; set; }

        string[] languages = { "Java", "C#", "JavaScript", "PHP", "Perl", "C++", "Swift", "Kotlin", "Python", "Ruby", "Scala", "F#" };

        public MainViewModel()
        {
            ItemsSource = new ObservableCollection<Person>();
            SelectedItems = new ObservableCollection<Person>();
            TextItems = new ObservableCollection<string>(new List<string> { "Red", "Blue", "Green" });

            SelectedText = "Green";

            foreach (var item in languages)
            {
                ItemsSource.Add(new Person()
                {
                    Name = item,
                    Age = 1
                });
            }




            SelectedItems.Add(ItemsSource[1]);
            SelectedItems.Add(ItemsSource[2]);
            SelectedItems.Add(ItemsSource[3]);

        }

      

    }
}

