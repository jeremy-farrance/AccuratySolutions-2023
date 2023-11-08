using DotNetNuke.Entities.Modules;  // ModuleInfo
using DotNetNuke.Entities.Portals;  // PortalSettings // [SiteInfo]
using DotNetNuke.Entities.Tabs;     // TabInfo // [PageInfo]
using DotNetNuke.Entities.Users;    // UserInfo

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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class Dnn
    {
      /// <summary>
      /// This is where we were thinking of instantiating the Dnn Helper for Portal/Site, Page/Tab, Module, User.
      /// </summary>


    }

  } // class Accu
}
