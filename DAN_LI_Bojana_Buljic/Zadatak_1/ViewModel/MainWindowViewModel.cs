﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class MainWindowViewModel:ViewModelBase
    {
        MainWindow main;

        public MainWindowViewModel(MainWindow registrationView)
        {
            main = registrationView;
        }

       
    }
}
