using ClientSerie.Models;
using ClientSerie.Services;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientSerie.ViewModels
{
    public class AjoutSerieViewModel : AjoutSerieViewModelAbstract
    {
        public IRelayCommand BtnFind { get; }
        public IRelayCommand BtnPost { get; }

        public AjoutSerieViewModel()
        {
            BtnFind = new RelayCommand(ActionFind);
            BtnPost = new RelayCommand(ActionPost);
        }

        public void ActionFind()
        {
            if (Id == null)
                DisplayErreurDialog("Vous devez entrer un id !", "Erreur");
            else
            {
                GetDataSerie();
            }
        }

        public void ActionPost()
        {
            PostDataOnAction();
        }

        public async void GetDataSerie()
        {
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            var result = await service.GetSerieAsync("api/series/", Id);
            if (result == null)
                DisplayErreurDialog("Série non trouvée !", "Erreur");
            else
                DisplayErreurDialog(result.Value.Resume, result.Value.Titre);
        }

        public async void PostDataOnAction()
        {
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            var serie = new Serie("You", "Un charmant libraire répondant au nom de Joe utilise les nouvelles technologies pour attirer la jolie romancière Beck et la faire tomber amoureuse. Son obsession envers Beck devient dangereuse mais Joe est prêt à tout.", 3, 30, 2018, "Netflix");
            /*SerieSelected = serie;*/
            var reponse = await service.PostSerieAsync("api/series", serie);
        }
    }
}
