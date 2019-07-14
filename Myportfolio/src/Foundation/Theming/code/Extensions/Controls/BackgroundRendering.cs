﻿using System;
using System.IO;
using System.Web.UI;
using Myportfolio.Foundations.SitecoreExtensions.Controls;
using Sitecore.Web.UI.WebControls;

namespace Myportfolio.Foundation.Theming.Extensions.Controls
{
  public class BackgroundRendering : IDisposable
  {
    /// <summary>
    ///   The html writer
    /// </summary>
    private readonly HtmlTextWriter htmlWriter;

    public BackgroundRendering(TextWriter writer, string backgroundClass, string tag = "div", string componentType = "well")
    {
      if (!string.IsNullOrEmpty(backgroundClass))
      {
        this.htmlWriter = new HtmlTextWriter(writer);
        htmlWriter.AddAttribute("class", componentType + " " + backgroundClass);
        htmlWriter.RenderBeginTag(tag);
      }
    }


    public void Dispose()
    {
      if (htmlWriter != null)
      {
        htmlWriter.RenderEndTag();
        this.htmlWriter.Dispose();
      }
    }
  }
}