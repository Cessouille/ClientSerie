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

        private int idFind;

        public int IdFind
        {
            get { return idFind; }
            set { idFind = value; OnPropertyChanged("IdPost"); }
        }

        private int idDelete;

        public int IdDelete
        {
            get { return idDelete; }
            set { idDelete = value; OnPropertyChanged("IdDelete"); }
        }

        private int idPut;

        public int IdPut
        {
            get { return idPut; }
            set { idPut = value; OnPropertyChanged("IdPut"); }
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

