using ClientSerie.Models;
using ClientSerie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ClientSerie.ViewModels
{
    public abstract class SerieViewModelAbstract : ObservableObject
    {
        public SerieViewModelAbstract()
        {

        }

        private ObservableCollection<Serie> series;

        public ObservableCollection<Serie> Series
        {
            get { return series; }
            set { series = value; OnPropertyChanged(); }
        }

        

        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            List<Serie> result = await service.GetSeriesAsync("api/series");
            if (result == null)
                DisplayErreurDialog("API non disponible !", "Erreur");
            else
                Series = new ObservableCollection<Serie>(result);
        }

        public async void DisplayErreurDialog(string content, string title)
        {
            ContentDialog erreur = new ContentDialog()
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };

            erreur.XamlRoot = App.MainRoot.XamlRoot;
            await erreur.ShowAsync();
        }
    }
}

