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
    public class AjoutSerieViewModel : SerieViewModelAbstract
    {
        public IRelayCommand BtnPost { get; }

        public AjoutSerieViewModel()
        {
            AjoutSerie = new Serie();
            BtnPost = new RelayCommand(ActionPost);
        }

        private Serie ajoutSerie;

        public Serie AjoutSerie
        {
            get { return ajoutSerie; }
            set { ajoutSerie = value; OnPropertyChanged();  }
        }

        public void ActionPost()
        {
            PostDataOnAction();
        }

        public async void PostDataOnAction()
        {
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            if (AjoutSerie.Titre == null || AjoutSerie.Resume == null || AjoutSerie.Nbsaisons == 0 || AjoutSerie.Nbepisodes == 0 || AjoutSerie.Anneecreation == 0 || AjoutSerie.Anneecreation > DateTime.Today.Year || AjoutSerie.Network == null)
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
    }
}
