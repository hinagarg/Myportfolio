using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc;
using Sitecore.Mvc.Helpers;

namespace Myportfolio.Foundations.SitecoreExtensions.Extensions
{
  public static class HtmlHelperExtensions
  {


    public static HtmlString DynamicPlaceholder(this SitecoreHelper helper, string placeholderName, bool useStaticPlaceholderNames = false)
    {
      return useStaticPlaceholderNames ? helper.Placeholder(placeholderName) : helper.DynamicPlaceholder(placeholderName);
    }

   
  }
}