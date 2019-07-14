using System.Web.Mvc;
using Sitecore.Data;
using Myportfolio.Foundations.SitecoreExtensions.Extensions;
using Myportfolio.Foundation.Theming.Extensions.Controls;
using Sitecore.Mvc.Presentation;
using Sitecore;

namespace Myportfolio.Foundation.Theming.Extensions
{
  public static class RenderingExtensions
  {
   
    public static string GetContainerClass([NotNull] this Rendering rendering)
    {
      return rendering.IsContainerFluid() ? "container-fluid" : "container";
    }

    public static bool IsContainerFluid([NotNull] this Rendering rendering)
    {
      return MainUtil.GetBool(rendering.Parameters[Constants.HasContainerLayoutParameters.IsFluid], false);
    }

    
  }
}
