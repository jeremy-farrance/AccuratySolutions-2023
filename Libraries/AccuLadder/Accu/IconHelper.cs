using System;
using System.Web;

// Note that initially we are planning to write this in a way that it can replace all 
// previous versions of AccuKit (RazorKit, AccuKit11, etc.) with no errors. This may 
// result in a LOT of code that is not needed, but it will be a good starting point.

namespace Accuraty.Libraries.AccuLadder
{
  /// <summary>
  /// Root for calling AccuLadder Helpers; Accu.Dev, .Dnn, etc. - Tools, utilities, and shortcuts for DNN and 2SC projects
  /// </summary>
  public partial class Accu
  {
    /// <summary>
    /// Accu.Dnn Helper - Tools, utilities, and shortcuts for DNN-specific things
    /// </summary>
    public partial class Icon
    {
      /// <summary>Gets HtmlString Icon string from the user manager resource file. Everything has a default, named: params recommended.</summary>
      /// <param name="iconName">The key/name of the icon key to get.</param>
      /// <param name="iconSize">xs, sm, md (default), lg, xl.</param>
      /// <param name="iconSet">The public icon setlocalization key to get (with or w/o file ext).</param>
      /// <param name="iconTag">Default is &lt;I&gt;, but allows &lt;SPAN&gt; or others to be specified</param>
      /// <param name="wrapperTag">An HTML tag to wrap the output in</param>
      /// <param name="styleColor">Set the foreground color using inline style. Any valid CSS style color syntax including names; https://developer.mozilla.org/en-US/docs/Web/CSS/color</param>
      /// <param name="styleMargin">Set Margins using inline style</param>
      /// <param name="styles">Additional styles to add to the inline style attribute</param>
      /// <returns>A HtmlString containing the Icon to display.</returns>
      /// <remarks>for iconSize follow Tw/Bs conventions? xs, sm, md (default), lg, xl) 
      /// see https://developers.google.com/fonts/docs/material_icons#styling_icons_in_material_design 
      /// (see https://www.w3schools.com/icons/google_icons_intro.asp and others)</remarks>
      public static IHtmlString Get(string iconName = "search", string iconSize = "md", string iconSet = Constants.DefaultIconSet,
        string iconTag = "i", string wrapperTag = "none",
        string styleColor = Constants.DefaultIconColor,
        string styleMargin = "0 0.5rem 0 0",
        string styles = ""
      )
      {
        // TOOD implement iconStyle for Normal, Default, Solid, Outlined, Rounded, TwoTone, Sharp, or Round or whatever they think up next; string iconStyle = "normal"
        // TODO implement modern Bootstrap Icons (https://icons.getbootstrap.com/) (standalone since Aug 2020)
        // TODO implement Heroicons (https://heroicons.com/)
        // TODO implement FontAwesome (https://fontawesome.com/icons?d=gallery&p=2&m=free)
        // TODO implement inverse/contrast color; bool invertColor = false (find that cool color/contrast inversion code from ???)
        // TODO how would we implement it so that we only load the icon sets resources that are actually used/needed? See Views/Shared/_Layout.cshtml
        // TOOD support other icon sets/styles (e.g. Google Symbols or Bootstrap 5)? How would we resolve names between them? (e.g. "lock_outline" vs "lock")
        iconName = iconName.ToLower().Replace(' ', '_').Replace('-', '_');
        // if wrapperTag is "none" then ignore
        var wrapperTagOpen = wrapperTag == "none" ? "" : "<" + wrapperTag + ">";
        var wrapperTagClose = wrapperTag == "none" ? "" : "</" + wrapperTag + ">";
        // if styleColor is "none" then don't add it, otherwise pass it in as a statement in the style attribute
        styleColor = styleColor == "none" ? "" : "color:" + styleColor + ";";
        styleMargin = styleMargin == "none" ? "" : "margin:" + styleMargin + ";";
        switch (iconSet.ToLower())
        {
          case "glyph":
          case "glyphs":
          case "glyphicon":
          case "glyphicons":
            return new HtmlString(wrapperTagOpen +
              "<" + iconTag + " class=\"glyphicon glyphicon-" + iconName + "\" style=\"" + styleColor + styleMargin + styles + "\" aria-hidden=\"true\"></" + iconTag + ">"
              + wrapperTagClose
            );
          case "google": // is the default
          default:
            return new HtmlString(wrapperTagOpen +
              "<" + iconTag + " class=\"material-icons " + iconSize + "\" style=\"" + styleColor + styleMargin + styles + "\" aria-hidden=\"true\">" + iconName + "</" + iconTag + ">"
              + wrapperTagClose
            );
        }
      }
      /// <summary>Warpper for iconSet="google" syntax.</summary>
      public static IHtmlString Google(string iconName = "search", string iconSize = "md",
        string iconTag = "i", string wrapperTag = "none",
        string styleColor = Constants.DefaultIconColor,
        string styleMargin = "0 0.5rem 0 0",
        string styles = ""
      )
      {
        return Get(iconName: iconName, iconSet: "google", iconSize: iconSize, iconTag: iconTag, wrapperTag: wrapperTag, styleColor: styleColor, styleMargin: styleMargin, styles: styles);
      }
      /// <summary>Warpper for previous (Bootstrap 3) Glyph syntax.</summary>
      /// <remarks>Deprecated, remove after all Glyphs are gone</remarks>
      [Obsolete("Use Icon.Get() with modern iconSets like Google, Hero, and FontAwesome. We are working towards removing Bootstrap 3 (which the Glyphicons were part of)")]
      public static IHtmlString Glyph(string iconName = "search", string iconSize = "md",
        string iconTag = "span", string wrapperTag = "none",
        string styleColor = Constants.DefaultIconColor,
        string styleMargin = "0 0.5rem 0 0",
        string styles = ""
      )
      {
        return Get(iconName: iconName, iconSet: "glyph", iconSize: iconSize, iconTag: iconTag, wrapperTag: wrapperTag, styleColor: styleColor, styleMargin: styleMargin, styles: styles);
      }
    }


  } // class Accu
}
