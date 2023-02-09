using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientSerie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSerie.Models;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;

namespace ClientSerie.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void GetSeriesAsyncTest_Ok()
        {
            //Arrange
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            var temp = service.GetSeriesAsync("api/series");
            List<Serie> lesSeries = new List<Serie>();
            //Act
            var result = temp.Result.Where(s => s.Serieid <= 3).ToList(); 
            lesSeries.Add(new Serie(1, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)"));
            lesSeries.Add(new Serie(2, "James May's 20th Century", "The world in 1999 would have been unrecognisable to anyone from 1900. James May takes a look at some of the greatest developments of the 20th century, and reveals how they shaped the times we live in now.", 1, 6, 2007, "BBC Two"));
            lesSeries.Add(new Serie(3, "True Blood", "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...", 7, 81, 2008, "HBO"));
            //Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Serie>), "Pas un IEnumerable");
            CollectionAssert.AreEqual(lesSeries, result, "Pas la même liste de séries");
        }

        [TestMethod()]
        public void GetSerieAsyncTest_Ok()
        {
            //Arrange
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            var result = service.GetSerieAsync("api/series", 1);
            //Act
            Serie serie = new Serie(1, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");
            //Assert
            Assert.IsInstanceOfType(result.Result, typeof(ActionResult<Serie>), "Pas un ActionResult");
            Assert.AreEqual(serie, result.Result.Value, "Pas la même série");
        }

        [TestMethod()]
        public void GetSerieAsyncTest_NonOk()
        {
            //Arrange
            WSService service = new WSService("https://apiseriescchau.azurewebsites.net");
            var result = service.GetSerieAsync("api/series", 0);
            //Act
            Serie serie = new Serie(1, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");
            //Assert
            Assert.IsNull(result.Result, "Pas null");
        }
    }
}