using ClientSerie.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSerie.ViewModels
{
    public class AjoutSerieViewModel : AjoutSerieViewModelAbstract
    {
        public IRelayCommand BtnSetConversion { get; }

        public AjoutSerieViewModel()
        {
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        public void ActionSetConversion()
        {
            if (Id == null)
                DisplayErreurDialog("Vous devez entrer un id !", "Erreur");
            else
            {
                WSService service = new WSService("https://apiseriescchau.azurewebsites.net/api/");
                SerieSelected = service.GetSerieAsync(Id, "series").Result.Value;
            }
        }
    }
}
