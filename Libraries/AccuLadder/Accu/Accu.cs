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
}
