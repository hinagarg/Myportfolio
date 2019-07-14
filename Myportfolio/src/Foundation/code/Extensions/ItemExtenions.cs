using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myportfolio.Foundations.SitecoreExtensions.Extensions
{
  public static class ItemExtenions
  {

    public static string LinkFieldUrl(this Item item, ID fieldID)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }
      if (ID.IsNullOrEmpty(fieldID))
      {
        throw new ArgumentNullException(nameof(fieldID));
      }
      var field = item.Fields[fieldID];
      if (field == null || !(FieldTypeManager.GetField(field) is LinkField))
      {
        return string.Empty;
      }
      LinkField linkField = field;
      switch (linkField.LinkType.ToLower())
      {
        case "internal":
          // Use LinkMananger for internal links, if link is not empty
          return linkField.TargetItem != null ? LinkManager.GetItemUrl(linkField.TargetItem) : string.Empty;
        case "media":
          // Use MediaManager for media links, if link is not empty
          return linkField.TargetItem != null ? MediaManager.GetMediaUrl(linkField.TargetItem) : string.Empty;
        case "external":
          // Just return external links
          return linkField.Url;
        case "anchor":
          // Prefix anchor link with # if link if not empty
          return !string.IsNullOrEmpty(linkField.Anchor) ? "#" + linkField.Anchor : string.Empty;
        case "mailto":
          // Just return mailto link
          return linkField.Url;
        case "javascript":
          // Just return javascript
          return linkField.Url;
        default:
          // Just please the compiler, this
          // condition will never be met
          return linkField.Url;
      }
    }


  }
}