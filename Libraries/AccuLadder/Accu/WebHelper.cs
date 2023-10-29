using System.Web;
using System.Drawing; // TODO Remove this dependency? But what to replace it with? Microsoft's System.Drawing.Common? Open Source ImageSharp?

namespace Accuraty.Libraries.AccuLadder
{
  /// <summary>
  /// Root for calling AccuLadder Helpers; Accu.Dev, .Dnn, etc. - Tools, utilities, and shortcuts for DNN and 2SC projects
  /// </summary>
  public partial class Accu
  {

    /// <summary>
    /// Accu.Sxc Helper - Tools, utilities, and shortcuts for 2sxc-specific things
    /// </summary>
    public class Web 
    {
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
