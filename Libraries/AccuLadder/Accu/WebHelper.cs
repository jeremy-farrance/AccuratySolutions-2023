using System.Web;
using System.Drawing; // TODO Remove this dependency? But what to replace it with? Microsoft's System.Drawing.Common? Open Source ImageSharp?
using System.Text.RegularExpressions;
using System.Text;

namespace Accuraty.Libraries.AccuLadder
{
  /// <summary>
  /// Root for calling AccuLadder Helpers; Accu.Dev, .Dnn, etc. - Tools, utilities, and shortcuts for DNN and 2SC projects
  /// </summary>
  public partial class Accu
  {

    /// <summary>
    /// Accu.Web Helper - Tools, utilities, and shortcuts for web-specific things
    /// </summary>
    public class Web 
    {
      /// <summary>
      /// Turn any text or title in to a URL Slug
      /// </summary>
      /// <param name="phrase">Any string to be converted to a Slug</param>
      /// <remarks>Source: https://stackoverflow.com/questions/2920744/url-slugify-algorithm-in-c</remarks>
      /// <remarks>TODO find better version that does more (with hyphens; multiples and trailing)</remarks>
      public static string ToSlug(string phrase)
      {
        byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(phrase);
        string str = Encoding.ASCII.GetString(bytes);
        str = str.ToLower();
        // invalid chars
        str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
        // convert multiple spaces into one space
        str = Regex.Replace(str, @"\s+", " ").Trim();
        // cut and trim
        str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
        str = Regex.Replace(str, @"\s", "-"); // space to hyphen
        str = Regex.Replace(str, @"-{2,}", "-"); // multiple hyphens to one hyphen
        str = str.Trim('-'); // trim hyphens from ends
        return str;
      }

      /// <summary>
      /// Get the width from an image file
      /// </summary>
      /// <param name="pathFile"></param>
      /// <returns>Width in pixels (int)</returns>
      public static int GetWidthFromImageFile(string pathFile)
      {
        using (Image sourceImage = Image.FromFile(HttpContext.Current.Server.MapPath(pathFile)))
        {
          return sourceImage.Width;
        }
      }

      /// <summary>
      /// Get the height from an image file
      /// </summary>
      /// <param name="pathFile"></param>
      /// <returns>Height in pixels (int)</returns>
      public static int GetHeightFromImageFile(string pathFile)
      {
        using (Image sourceImage = Image.FromFile(HttpContext.Current.Server.MapPath(pathFile)))
        {
          return sourceImage.Height;
        }
      }

    } // class Web
  } // class Accu
}
