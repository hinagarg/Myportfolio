using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Myportfolio.Feature.ImageSlider.Models;
using Myportfolio.Foundations.SitecoreExtensions.Extensions;

namespace Myportfolio.Feature.ImageSlider.Controllers
{
    public class ImageSliderController : Controller
    {
        // GET: ImageSlider
        public ActionResult ImageSlider()
        {
          var imageSliderID = RenderingContext.Current.Rendering.DataSource;
          Item imageSlider = !String.IsNullOrEmpty(imageSliderID) ? Sitecore.Context.Database.GetItem(imageSliderID) : null;
          Sitecore. Data.Fields.MultilistField sliderImages = imageSlider != null ? imageSlider.Fields["Slider images"] : null;
          Slider slider = GetSliderImages(sliderImages, new Slider());
          return View(slider);
        }
        private Slider GetSliderImages(Sitecore.Data.Fields.MultilistField sliderImages, Slider slider)
        {
            Slider ImageSliderList = null;
            try
            {
              foreach(Item sImage in sliderImages.GetItems())
              {
                Image imgObj = new Image();
                imgObj.BackgroundImage = sImage.Fields["Background Image"] != null ? ItemExtensions.MediaFieldUrl(sImage, sImage.Fields["Background Image"].ID) : "";
                imgObj.Alt = sImage.Fields["Alt"] != null ? sImage.Fields["Alt"].Value : "";
                slider.ImageSliderList.Add(imgObj);
              } 
            
            }
            catch(Exception ex)
            {
              Sitecore.Diagnostics.Log.Error(ex.Message, ex, this); 
            }
      
          return slider;
        } 
    }
}