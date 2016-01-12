using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using e_bibliotheque.Models;
using System.Collections.Generic;
using Moq;
using System.Web;
using System.Web.Routing;

namespace e_bibliotheque.Tests.Models
{
    [TestClass]
    public class IDAL_Test
    {
        [TestMethod]
        public void CreerRestaurant_AvecUnNouveauRestaurant_ObtientTousLesRestaurantsRenvoitBienLeRestaurant()
        {
            using (IDal dal = new DAL())
            {
                dal.CreerAuteur("auteurTest");
                List<auteurs> auteurs = dal.ObtientTousLesAuteurs();

                Assert.IsNotNull(auteurs);
                Assert.AreEqual(5, auteurs.Count);
                Assert.AreEqual("auteurTest", auteurs[0].Nom);
                //Assert.AreEqual("01 02 03 04 05", restos[0].Telephone);
            }
        }

        private static RouteData DefinirUrl(string url)
        {
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            RouteData routeData = routes.GetRouteData(mockContext.Object);
            return routeData;
        }


        [TestMethod]
        public void Routes_PageLivre_RetourneControleurHomeEtMethodeIndex()
        {
            RouteData routeData = DefinirUrl("~/Afficher");
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Afficher", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);

        }

        [TestMethod]
        public void Routes_Pageauteur_RetourneControleurHomeEtMethodeIndex()
        {
            RouteData routeData = DefinirUrl("~/Afficher/Auteurs");
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Afficher", routeData.Values["controller"]);
            Assert.AreEqual("Auteurs", routeData.Values["action"]);

        }

        [TestMethod]
        public void Routes_livreauteur_RetourneControleurHomeEtMethodeIndex()
        {
            RouteData routeData = DefinirUrl("~/Afficher/Auteurs/1");
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Afficher", routeData.Values["controller"]);
            Assert.AreEqual("Auteurs", routeData.Values["action"]);
            Assert.AreEqual("1", routeData.Values["id"]);

        }
    }
}
