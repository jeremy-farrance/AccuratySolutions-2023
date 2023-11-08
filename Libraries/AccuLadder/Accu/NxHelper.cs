// WARNING: These are experimental, they will likely change and definitely move to another existing or new Accu Helper

namespace Accuraty.Libraries.AccuLadder
{
  /// <summary>
  /// Root for calling AccuLadder Helpers; Accu.Dev, .Dnn, etc. - Tools, utilities, and shortcuts for DNN and 2SC projects
  /// </summary>
  public partial class Accu
  {

    /// <summary>
    /// Accu.Nx Helper - Experimental Tools, utilities, and shortcuts for DNN or 2sxc things
    /// </summary>
    public class Nx
    {
      /// <summary>
      /// Use this to switch code/path logic based on IP, Role, URL params, etc.
      /// sbe = Switch Between Editions; based on Role, IP, etc.
      /// </summary>
      /// <param name="returnTrue">Default is "dev"</param>
      /// <param name="returnFalse">Default is ""</param>
      /// <returns>a string value</returns>
      public static string Sbe(
        string returnTrue = "dev",
        string returnFalse = ""
      )
      {
        bool rule = Accu.Dnn.IsSuper() && Accu.Dev.IsAccuratyIp();
        return rule ? returnTrue : returnFalse;
      }
    } // class Nx

  } // class Accu
} // namespace Accuraty.Libraries.AccuLadder
