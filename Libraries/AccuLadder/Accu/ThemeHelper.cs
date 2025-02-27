﻿using System;
using System.IO;                            // Path.Combine or .Join
using System.Web;                           // HttpContext
using DotNetNuke.Entities.Portals;          // PortalSettings

namespace Accuraty.Libraries.AccuLadder
{
  /// <summary>
  /// Root for calling AccuLadder Helpers; Accu.Dev, .Dnn, etc. - Tools, utilities, and shortcuts for DNN and 2SC projects
  /// </summary>
  public partial class Accu
  {
    /// <summary>
    /// Items used mostly in Theme (skin and container) contexts
    /// </summary>
    /// <remarks>
    /// This is primarily used in AccuTheme (Bootstrap or Tailwind), so we are defaulting to that pattern. 
    /// Note that you can set these values before calling the ThemeHelper methods to override the defaults.
    /// </remarks>
    public partial class Theme
    {
      /// <summary>The standard name for the compiled output folder, usually "dist" (default) or "public".</summary>
      public static string PublicFolderName { get; set; } = "dist"; // or "public"
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
      public static string CssFolderName { get; set; } = ""; // or "css"
      public static string JsFolderName { get; set; } = ""; // or "js"
      public static string MediaFolderName { get; set; } = "media";
      public static string ImageFolderName { get; set; } = "images"; // or "img" or "image"
      public static string SvgFolderName { get; set; } = "svg";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

      /// <summary>Theme path</summary>
      /// <remarks>
      /// Reminder: DNN returns this with leading and trailing slashes
      /// Note: DNN lowercases the paths (e.g. /skins/accutheme/), but not /Portals, weird, huh?
      /// Example: /Portals/_default/skins/accutheme/
      /// TODO incorporate awareness of Containers (not yet implemented)
      /// </remarks>
      public static string Path { get; } = PortalSettings.Current.ActiveTab.SkinPath;

      /// <summary>Theme CSS path</summary>
      public static string CssPath { get; } = Dev.CombinePathSegments(segments: new[] { ThemePath, PublicFolderName, CssFolderName } );
      
      /// <summary>Theme JS path</summary>
      public static string JsPath { get; } = Dev.CombinePathSegments(segments: new[] { ThemePath, PublicFolderName, JsFolderName } );

      /// <summary>Theme path</summary>
      public static string MediaPath { get; } = Dev.CombinePathSegments(segments: new[] { ThemePath, PublicFolderName, MediaFolderName } );
      /// <summary>Theme path</summary>
      public static string ImagePath { get; } = Dev.CombinePathSegments(segments: new[] { ThemePath, PublicFolderName, MediaFolderName, ImageFolderName } );

      /// <summary>Theme path</summary>
      public static string SvgPath { get; } = Dev.CombinePathSegments(segments: new[] { ThemePath, PublicFolderName, MediaFolderName, SvgFolderName } );

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
      public static string ThemePath { get; } = Path;
      public static string ThemeCssPath { get; } = CssPath;
      public static string ThemeJsPath { get; } = JsPath;
      public static string ThemeMediaPath { get; } = MediaPath;
      public static string ThemeImagePath { get; } = ImagePath;
      public static string ThemeSvgPath { get; } = SvgPath;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

      /// <summary>
      /// 
      /// </summary>
      /// <param name="iconName"></param>
      /// <returns></returns>
      public static HtmlString AccuIcon(string iconName)
      {
        string name = Web.ToSlug(iconName);
        string svgSprite = ThemeSvgPath + "/AccuTheme-icons.svg";
        string output = "<svg class=\"svg svg--icon\" width=\"1em\" height=\"1em\" fill=\"currentColor\" focusable=\"false\" aria-hidden=\"true\"><use xlink:href=\"" + svgSprite + "#" + name + "\"></use></svg>";

        return new HtmlString(output);
      }

      /// <summary>
      /// Obsolete: Deprecated, old way of converting an icon name to a Bootstrap SVG icon
      /// </summary>
      /// <param name="iconName"></param>
      /// <returns></returns>
      public static HtmlString BootstrapIcon(string iconName)
      {
        string name = Web.ToSlug(iconName);
        string svgSprite = ThemeSvgPath + "/bootstrap-icons.svg";
        string output = "<svg class=\"svg svg--icon bi\" width=\"1em\" height=\"1em\" fill=\"currentColor\" focusable=\"false\" aria-hidden=\"true\"><use xlink:href=\"" + svgSprite + "#" + name + "\"></use></svg>";

        return new HtmlString(output);
      }

      /// <summary>
      /// Current page is Home?
      /// </summary>
      /// <returns>Bool</returns>
      /// <remarks>Prior to AccuLadder (AccuKit, AccuTheme) this was a Method</remarks>
      public static bool IsHome
      {
        get => PortalSettings.Current.ActiveTab.TabID == PortalSettings.Current.HomeTabId;
      }

      /// <summary>
      /// Does the Theme File exist in the current Theme?
      /// </summary>  
      /// <remarks>Works without a file extension, defaults to .ascx</remarks>
      public static bool ThemeFileExists(string fileName, string fileExtension = ".ascx")
      {
        string filePath = Dev.CombinePathSegments(segments: new[] { HttpContext.Current.Server.MapPath(ThemePath), fileName + fileExtension } );
        return File.Exists(filePath);
      }


    }
  }
}
