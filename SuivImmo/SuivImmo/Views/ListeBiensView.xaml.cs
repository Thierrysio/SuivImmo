﻿using SuivImmo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SuivImmo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeBiensView : ContentPage
    {
        public ListeBiensView()
        {
            InitializeComponent();
            BindingContext = new ListeBiensViewModel();
        }
    }
}