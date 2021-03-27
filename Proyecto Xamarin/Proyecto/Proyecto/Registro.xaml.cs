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
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
            btnVerificarRegistro.Clicked += BtnVerificarRegistro_Clicked;
            btnRegresar.Clicked += BtnRegresar_Clicked;
        }

        private void BtnRegresar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Login());
        }

        private void BtnVerificarRegistro_Clicked(object sender, EventArgs e)
        {
            //verifica si los entrys estan vacios
            if(string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtPaswordConfirm.Text) || string.IsNullOrEmpty(txtCorreo.Text))
            {
                DisplayAlert("Advertencia", "Debe llenar todos los campos", "Ok");
            } else
            {
                //verifica si los datos colocados coinciden con los guardados en la lista
                if (!(txtPassword.Text == txtPaswordConfirm.Text)){
                    DisplayAlert("Advertencia", "Las contraseñas deben de coincidir", "Ok");
                } else if (!(App.listaUsuarios.Find(i => i.username == txtUsuario.Text) == null && App.listaUsuarios.Find(i => i.correo == txtCorreo.Text) == null)) {
                    DisplayAlert("Advertencia", "Los datos del usuario y el correo ya coinciden con la base de datos, por favor, inicie sesión", "Ok");
                } else
                {
                    App.listaUsuarios.Add(new Usuario(txtUsuario.Text, txtPassword.Text, txtCorreo.Text));
                    DisplayAlert("Advertencia", "Usuario " + txtUsuario.Text + " agregado a la base de datos", "Ok");
                }
            }
        }

        /* Copiar y pegar en btnVerificarRegistro_Clicked después que se verifique correctamente la información ingresada, y luego
        ingresar una contraseña incriptada y su llave a BD

            var password = txtPassword;
            var salt = Argon2.CreateSalt();
            var hash = Argon2.HashPassword(password, salt);

            String hashS = Convert.ToBase64String(hash);
            String saltS = Convert.ToBase64String(salt);

            (Aquí va código para copiar hashS t saltS y pegarlos en los espacios de contraseña y llave en la BD)
        }*/
    }
}