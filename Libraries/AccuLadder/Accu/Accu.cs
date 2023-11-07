using System.Reflection;

namespace Accuraty.Libraries.AccuLadder
{
  public partial class Accu
  {
    /// <summary>
    /// Use Version to get the current version of AccuLadder
    /// </summary>
    /// <remarks>We are getting this value the hard way using .GetVersion(), since we are already in the weeds, isn't there an easier way?</remarks>
    public static string Version 
    {
      get => Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
  }

  /// <summary>Defines common constants for the user manager.</summary>
  public class Constants
  {
    /// <summary>The default Icon Set the IconHelper.Get() uses for this module; see https://www.w3schools.com/icons/default.asp</summary>
    public const string DefaultIconSet = "Google";

    /// <summary>The default Icon Color the IconHelper.Get() uses for this module; see https://www.w3schools.com/icons/default.asp</summary>
    public const string DefaultIconColor = "none"; // "none" is handled in the IconHelper.Get() method
  }
}
