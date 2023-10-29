using System;
using System.Web;

// THIS IS A RETHINK
// Can we use the actual namespace(s); RazorKit, AccuKit, AccuKit11, etc.?
// Then just delete the corresponding App_Code file and have everything still work?

namespace Accuraty.Libraries.AccuLadder
{
  [Obsolete("AccuKit is Deprecated, use only for quick compatibility hacks. ")]
  public class AccuKit
  {
    /// <summary>Obsolete: Deprecated, use: Accu.Theme.Path instead</summary>
    public static string SkinPath = Accu.Theme.Path;
    public static string SkinCssPath = Accu.Theme.CssPath;
    public static string SkinJsPath = Accu.Theme.JsPath;
    public static string SkinMediaPath = Accu.Theme.MediaPath;
    public static string SkinImagesPath = Accu.Theme.ImagePath;
    public static string SkinSvgPath = Accu.Theme.SvgPath;

    public static string Version() { return "1.0.? (2020822, ASL-ACCU4 20231021)"; }
    [Obsolete("Deprecated, instead use: Accu.Dnn.IsHome()")]
    public static bool isHomePage() { return Accu.Dnn.IsHome(); }
    [Obsolete("Deprecated, instead use: Accu.Theme.AccuIcon(iconName)")]
    public static HtmlString AccuIcon(string iconName) { return Accu.Theme.AccuIcon(iconName); }
    [Obsolete("Deprecated, instead use: Accu.Theme.BootstrapIcon(iconName)")]
    public static HtmlString BootstrapIcon(string iconName) { return Accu.Theme.BootstrapIcon(iconName); }
    [Obsolete("Deprecated, instead use: Accu.Dnn.IsSuper()")]
    public static bool isSuperUser() { return Accu.Dnn.IsSuper(); }
    [Obsolete("Deprecated, instead use: Accu.Dev.ToSlug(phrase)")]
    public static string ToSlug(string phrase) { return Accu.Dev.ToSlug(phrase); }
    /// <summary>Obsolete: Deprecated, use: Accu.Dev.GetIpAddress() instead</summary>
    [Obsolete("Deprecated, instead use: Accu.Dev.IsAccuratyIp()")]
    public static bool isAccuratyIP() { return Accu.Dev.IsAccuratyIp(); }
    [Obsolete("Deprecated, instead use: Accu.Dev.GetIpAddress()")]
    public static string GetIpAddress() { return Accu.Dev.GetIpAddress(); }
    [Obsolete("Deprecated, instead use: Accu.Dev.GetIpAddressFromHost(Hostname)")]
    public static string GetIpFromHostname(string Hostname) { return Accu.Dev.GetIpAddressFromHost(Hostname); }
    [Obsolete("Deprecated, instead use: Accu.Text.FormatPhone(PhoneNumber)")]
    public static string FormatPhone(string PhoneNumber = "444-555-1212", string PhoneFormat = "{0:(###) ###-####}") { return Accu.Text.FormatPhone(PhoneNumber, PhoneFormat); }
    [Obsolete("Deprecated, instead use: Accu.Web.GetWidthFromImageFile(pathFile: pathFile)")]
    public static int imageGetWidthfromFile(string pathFile) { return Accu.Web.GetWidthFromImageFile(pathFile: pathFile); }
    [Obsolete("Deprecated, instead use: Accu.Web.GetHeightFromImageFile(pathFile: pathFile)")]
    public static int imageGetHeightfromFile(string pathFile) { return Accu.Web.GetHeightFromImageFile(pathFile: pathFile); }

    // items below need work or rethink or something
    [Obsolete("Deprecated, instead use: [TBD]")] // TODO replace [TBD] with the correct call
    public static string sbe(string returnTrue = "dev", string returnFalse = "") { return Accu.Nx.Sbe(returnTrue, returnFalse); }

  } // end class AccuKit
} // end namespace Accuraty.Libraries.AccuLadder

