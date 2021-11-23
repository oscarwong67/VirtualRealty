using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System;


namespace VirtualRealty
{
    /// <summary>
    /// Interaction logic for Top_Bar.xaml
    /// </summary>
    public partial class Top_Bar : UserControl
    {
        public Top_Bar()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();

            List<HomeType> homeTypeList = new List<HomeType>();
            homeTypeList.Add(new HomeType(false, "Apartment"));
            homeTypeList.Add(new HomeType(false, "Condo"));
            homeTypeList.Add(new HomeType(false, "House"));
            homeTypeList.Add(new HomeType(false, "Townhouse"));


            HomeType.ItemsSource = homeTypeList;
        }
        void GoToHomePage(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ListingsPage());
        }

        void GoToFavorites(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Favorites());
        }

        void GoToSavedSearches(object sender, RoutedEventArgs e)
        {
            if (MainWindow.savedSearchesPage == null)
            {
                MainWindow.CreateInitialSavedSearches();
                MainWindow.savedSearchesPage = new SavedSearches();
            }
            Switcher.Switch(MainWindow.savedSearchesPage);        
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        void Search(object sender, RoutedEventArgs e)
        {

        }
        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
        }
    }

    public class HomeType
    {
        public HomeType(bool isChecked, string homeTypeName)
        {
            IsChecked = isChecked;
            HomeTypeName = homeTypeName;
        }

        public bool IsChecked
        { get; set; }

        public string HomeTypeName
        { get; set; }

    }

    public class ViewModel : INotifyPropertyChanged
    {
        private bool _isClicked = false;
        private RelayCommand _clickCommand;

        public ViewModel()
        {
            isClicked = false;
        }

        public bool isClicked
        {
            get { return _isClicked; }
            set
            {
                _isClicked = value;
                OnPropertyChanged("isClicked");
            }
        }

        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? new RelayCommand((x) =>
                {
                    var buttonType = x.ToString();


                    if (null != buttonType)
                    {
                        if (buttonType.Contains("1on"))
                        {
                            isClicked = false;
                        }
                        else if (buttonType.Contains("1"))
                        {
                            isClicked = true;
                        }
                    }
                });
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {

            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
