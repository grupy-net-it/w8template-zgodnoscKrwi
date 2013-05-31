using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StyleMVVM.View;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LayoutAwarePage = ZgodnoscKrwi.Common.LayoutAwarePage;
using Windows.UI.ViewManagement;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZgodnoscKrwi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [StartPage]
    public sealed partial class MainPage : LayoutAwarePage
    {
       
        public MainPage()
        {
            this.InitializeComponent();
            
        }
      


    }
}
