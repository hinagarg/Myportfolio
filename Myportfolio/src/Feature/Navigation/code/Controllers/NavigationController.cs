using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Myportfolio.Feature.Navigation.Models;
using Myportfolio.Foundations.SitecoreExtensions.Extensions;

namespace Myportfolio.Feature.Navigation.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Navigation()
        {
          NavigationBar navigationObj = new NavigationBar();
          var navigationItemID = RenderingContext.Current.Rendering.DataSource;
          Sitecore.Data.Database currentDatabase = Sitecore.Context.Database;
          Sitecore.Data.Fields.MultilistField navigationLinks = !String.IsNullOrEmpty(navigationItemID) ? 
                                                               currentDatabase.GetItem(navigationItemID).Fields["Navigation Menu"] : null;
          return View("Navigation", GetNavigationLinks(navigationLinks, navigationObj));
        }

        /// <summary>
        /// Method to fetch the navigation links from sitecore.
        /// </summary>
        /// <param name="navigationLinks"></param>
        /// <param name="navigationObj"></param>
        /// <returns>The Nav Links</returns>
        private NavigationBar GetNavigationLinks(Sitecore.Data.Fields.MultilistField navigationLinks, NavigationBar navigationObj)
        {
          try
          {
              //NavigationLinks navigationLink = new NavigationLinks();
              if (navigationLinks != null)
              {
                foreach (var navLink in navigationLinks.GetItems())
                {
                  NavigationLinks navigationLink = new NavigationLinks();
                  navigationLink.Title = navLink.Fields["Title"] != null ? navLink.Fields["Title"].Value : "";
                  navigationLink.TargetLink = navLink.Fields["Target Link"] != null ? ItemExtensions.LinkFieldUrl(navLink, navLink.Fields["Target Link"].ID) : "";
                  navigationObj.navigationLinks.Add(navigationLink);
                }
              }
          }
          catch (Exception ex)
          {
            Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
          }
            return navigationObj;
        }
    }
}