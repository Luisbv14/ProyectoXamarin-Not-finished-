﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuModelos : ContentPage
    {
        public MenuModelos()
        {
            InitializeComponent();
            BtnOpcion1.Clicked += BtnOpcion1_Clicked;
        }

        private void BtnOpcion1_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new BancoPrima());
        }
    }
}