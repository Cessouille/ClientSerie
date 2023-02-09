using ClientSerie.Models;
using ClientSerie.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSerie.ViewModels
{
    public class ModifSerieViewModel : SerieViewModelAbstract
    {
        public IRelayCommand BtnFind { get; }
        public IRelayCommand BtnDelete { get; }
        public IRelayCommand BtnPut { get; }

        public ModifSerieViewModel()
        {
            SerieSelected = new Serie();
            BtnFind = new RelayCommand(GetDataSerie);
            BtnDelete = new RelayCommand(DeleteDataOnAction);
            BtnPut = new RelayCommand(PutDataOnAction);
        }

        private Serie serieSelected;

        public Serie SerieSelected
        {
            get { return serieSelected; }
            set { serieSelected = value; OnPropertyChanged(); }
        }

        public async void GetDataSerie()
        {
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            var result = await service.GetSerieAsync("api/series", SerieSelected.Serieid);
            if (result == null)
                DisplayErreurDialog("Série non trouvée !", "Erreur");
            else
                SerieSelected = result.Value;
        }

        public async void DeleteDataOnAction()
        {
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            var result = await service.DeleteSerieAsync("api/series", SerieSelected.Serieid);
            if (!(result))
                DisplayErreurDialog("Série non supprimée !", "Erreur");
            else
                DisplayErreurDialog("Série supprimée avec succès !", "Zer gut");
        }

        public async void PutDataOnAction()
        {
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net"); 
            var result = await service.PutSerieAsync("api/series", SerieSelected.Serieid, SerieSelected);
            if (!(result))
                DisplayErreurDialog("Série non modifiée !", "Nein nein nein");
            else
                DisplayErreurDialog("Série modifiée avec succès !", "Ich mag die Sonne");
        }
    }
}
