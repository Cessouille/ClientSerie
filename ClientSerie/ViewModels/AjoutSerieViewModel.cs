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
        public IRelayCommand BtnDelete { get; }
        public IRelayCommand BtnPut { get; }

        public AjoutSerieViewModel()
        {
            AjoutSerie = new Serie();
            /*BtnFind = new RelayCommand(ActionFind);*/
            BtnPost = new RelayCommand(ActionPost);
            /*BtnDelete = new RelayCommand(ActionDelete);
            BtnPut = new RelayCommand(ActionPut);*/
        }

        private Serie ajoutSerie;

        public Serie AjoutSerie
        {
            get { return ajoutSerie; }
            set { ajoutSerie = value; }
        }

        /*public void ActionFind()
        {
            if (IdFind == null)
                DisplayErreurDialog("Vous devez entrer un id !", "Erreur");
            else
            {
                GetDataSerie();
            }
        }*/

        public void ActionPost()
        {
            PostDataOnAction();
        }
        /*public void ActionDelete()
        {
            DeleteDataOnAction();
        }*/

        /*public void ActionPut()
        {
            PutDataOnAction();
        }*/

        /*public async void GetDataSerie()
        {
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            var result = await service.GetSerieAsync("api/series/", IdFind);
            if (result == null)
                DisplayErreurDialog("Série non trouvée !", "Erreur");
            else
                DisplayErreurDialog(result.Value.Resume, result.Value.Titre);
        }*/

        public async void PostDataOnAction()
        {
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            if (AjoutSerie.Titre == null || AjoutSerie.Resume == null || AjoutSerie.Nbsaisons == null || AjoutSerie.Nbepisodes == null || AjoutSerie.Anneecreation == null || AjoutSerie.Network == null)
                DisplayErreurDialog("Tous les champs sont obligatoires !", "Erreur");
            else
            {
                var serie = new Serie(AjoutSerie.Titre, AjoutSerie.Resume, AjoutSerie.Nbsaisons, AjoutSerie.Nbepisodes, AjoutSerie.Anneecreation, AjoutSerie.Network);
                var result = await service.PostSerieAsync("api/series", serie);
                if (!(result.Value))
                    DisplayErreurDialog("Série non créée !", "Erreur");
                else
                    DisplayErreurDialog("Série créée avec succès !", "Gut");
            }
        }
        /*public async void DeleteDataOnAction()
        {
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            var result = await service.DeleteSerieAsync("api/series", IdDelete);
            if (!(result))
                DisplayErreurDialog("Série non supprimée !", "Erreur");
            else
                DisplayErreurDialog("Série supprimée avec succès !", "Zer gut");
        }*/

        /*public async void PutDataOnAction()
        {
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net"); 
            var serie = new Serie(IdPut, "You", "Un charmant libraire répondant au nom de Joe utilise les nouvelles technologies pour attirer la jolie romancière Beck et la faire tomber amoureuse. Son obsession envers Beck devient dangereuse mais Joe est prêt à tout.", 3, 30, 2018, "Netflix");
            var result = await service.PutSerieAsync("api/series", IdPut, serie);
            if (!(result))
                DisplayErreurDialog("Série non modifiée !", "Nein nein nein");
            else
                DisplayErreurDialog("Série modifiée avec succès !", "Ich mag die Sonne");
        }*/
    }
}
