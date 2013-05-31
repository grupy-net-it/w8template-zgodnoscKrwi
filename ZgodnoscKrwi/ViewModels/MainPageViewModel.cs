using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StyleMVVM.DependencyInjection;
using StyleMVVM.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;

namespace ZgodnoscKrwi.ViewModels
{
	public class MainPageViewModel : PageViewModel
	{
       


        private string result;
        public string Result
        {
            get { return result; }
            set 
            { 
                result = value;
                OnPropertyChanged("Result");
            }
        }
        
        public MainPageViewModel()
        {
            
            Mode = "biorca";
            FullGrid = Visibility.Visible;
            SnapGrid = Visibility.Collapsed;

            InitView();
            
            
        }

        void InitView()
        {
            Window.Current.SizeChanged += OnSizeChanged;
        }

        protected override void OnNavigatedTo(object sender, StyleMVVM.View.StyleNavigationEventArgs e)
        {
            InitView();
            base.OnNavigatedTo(sender, e);
        }


        private void OnSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            // Obtain view state by explicitly querying for it
            if (Windows.UI.ViewManagement.ApplicationView.Value == ApplicationViewState.Snapped)
            {
                SnapGrid = Visibility.Visible;
                FullGrid = Visibility.Collapsed;
            }
             else
                if (Windows.UI.ViewManagement.ApplicationView.Value == ApplicationViewState.Filled || Windows.UI.ViewManagement.ApplicationView.Value == ApplicationViewState.FullScreenLandscape)
            {
                SnapGrid = Visibility.Collapsed;
                FullGrid = Visibility.Visible;
            }
        }

        

        private string mode;

        public string Mode
        {
            get { return mode; }
            set { 
                mode = value;
                OnPropertyChanged("Mode");
            }
        }

        private Visibility fullGrid = Visibility.Visible;
        public Visibility FullGrid
        {
            get { return fullGrid; }
            set
            {
                fullGrid = value;
                OnPropertyChanged("FullGrid");
            }

        }

        private Visibility snapGrid = Visibility.Collapsed;
        public Visibility SnapGrid
        {
            get { return snapGrid; }
            set 
            { 
                snapGrid = value;
                OnPropertyChanged("SnapGrid");
            }
        }


        private void TryUnsnapView()
        {
            Windows.UI.ViewManagement.ApplicationView.TryUnsnap();
            SnapGrid = Visibility.Collapsed;
            FullGrid = Visibility.Visible;
        }


        

        private void SwitchToBiorca()
        {
            Mode = "biorca";
        }
        private void SwitchToDawca()
        {
            Mode = "dawca";
        }

        private void CheckOutOminus()
        {
            switch (Mode)
            {
                case "biorca":
                    {
                        Result = "0-";
                    break;
                    }
                case "dawca":
                    {
                        Result = "0- 0+ B- B+ A- A+ AB- AB+";
                        break;
                    }
            }
        }
        private void CheckOutOplus()
        {
            switch (Mode)
            {
                case "biorca":
                    {
                        Result = "0- 0+";
                        break;
                    }
                case "dawca":
                    {
                        Result = "AB+ A+ B+ 0+";
                        break;
                    }
            }
        }
        private void CheckOutBminus()
        {
            switch (Mode)
            {
                case "biorca":
                    {
                        Result = "0- B-";
                        break;
                    }
                case "dawca":
                    {
                        Result = "AB+ AB- B+ B-";
                        break;
                    }
            }
        }
        private void CheckOutBplus()
        {
            switch (Mode)
            {
                case "biorca":
                    {
                        Result = "0- 0+ B- B+";
                        break;
                    }
                case "dawca":
                    {
                        Result = "AB+ B+";
                        break;
                    }
            }
        }
        private void CheckOutAminus()
        {
            switch (Mode)
            {
                case "biorca":
                    {
                        Result = "0- A-";
                        break;
                    }
                case "dawca":
                    {
                        Result = "AB+ AB- A+ A-";
                        break;
                    }
            }
        }
        private void CheckOutAplus()
        {
            switch (Mode)
            {
                case "biorca":
                    {
                        Result = "0- 0+ A- A+";
                        break;
                    }
                case "dawca":
                    {
                        Result = "AB+ A+";
                        break;
                    }
            }
        }
        private void CheckOutABminus()
        {
            switch (Mode)
            {
                case "biorca":
                    {
                        Result = "0- B- A- AB-";
                        break;
                    }
                case "dawca":
                    {
                        Result = "AB+ AB-";
                        break;
                    }
            }
        }
        private void CheckOutABplus()
        {
            switch (Mode)
            {
                case "biorca":
                    {
                        Result = "0- 0+ B- B+ A- A+ AB- AB+";
                        break;
                    }
                case "dawca":
                    {
                        Result = "AB+";
                        break;
                    }
            }
        }
	}
}
