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
    public abstract class AjoutSerieViewModelAbstract : ObservableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AjoutSerieViewModelAbstract()
        {
            GetDataOnLoadAsync();
        }

        private Serie serieSelected;

        public Serie SerieSelected
        {
            get { return serieSelected; }
            set { serieSelected = value; OnPropertyChanged("SerieSelected"); }
        }

        private ObservableCollection<Serie> series;

        public ObservableCollection<Serie> Series
        {
            get { return series; }
            set { series = value; OnPropertyChanged("Series"); }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7153/api/");
            List<Serie> result = await service.GetSeriesAsync();
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

