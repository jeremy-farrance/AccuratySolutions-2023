using DotNetNuke.Entities.Portals; // PortalSettings
using DotNetNuke.Entities.Tabs; // TabInfo
using DotNetNuke.Entities.Users;

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
    public class Dnn
    {
      /// <summary>
      /// Current page is Home?
      /// </summary>
      /// <returns>Bool</returns>
      public static bool IsHome()
      {
        return PortalSettings.Current.ActiveTab.TabID == PortalSettings.Current.HomeTabId;
      }

      /// <summary>
      /// Get a DNN TabInfo for a pageId
      /// </summary>
      /// <param name="pageId">Required (TabId)</param>
      /// <param name="siteId">Not required, will use Current</param>
      /// <returns>TabInfo</returns>
      public static TabInfo GetPageById(int pageId, int siteId = -1)
      {
        // this mostly exists because 2sxc's CmsContext.Site only returns the siteId, not the full TabInfo
        // use case https://stackoverflow.com/questions/76917236
        if (siteId == -1)
        {
          siteId = PortalSettings.Current.PortalId;
        }
        return TabController.Instance.GetTab(pageId, siteId);
      }

      /// <summary>
      /// Get a DNN TabInfo for a TabId
      /// </summary>
      /// <param name="pageId">Required (TabId)</param>
      /// <returns>TabInfo</returns>
      public static TabInfo GetPage(int pageId)
      {
        return GetPageById(pageId);
      }
      /// <summary>
      /// Get a DNN TabInfo for a TabId
      /// </summary>
      /// <param name="pageId"></param>
      /// <param name="siteId"></param>
      /// <returns>TabInfo</returns>
      public static TabInfo GetPage(int pageId, int siteId)
      {
        return GetPageById(pageId, siteId);
      }
      // // Accu.Dnn
      /// <summary>
      /// Shortcut to check if the current user is a DNN SuperUser (Host)
      /// </summary>
      /// <returns></returns>
      public static bool IsSuper()
      {
        return UserController.Instance.GetCurrentUserInfo().IsSuperUser;
      }
      // old function name, for compatibility?
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
      public static bool isSuper() { return IsSuper(); }

      /// <summary>
      /// is this user an Admin or Host?
      /// </summary>
      /// <param name="userInfo">UserInfo</param>
      /// <returns>bool</returns>
      public static bool IsAdminOrSuper(UserInfo userInfo)
      {
        return userInfo.IsSuperUser
          || userInfo.IsInRole(PortalSettings.Current.AdministratorRoleName);
      }
      /// <summary>
      /// is this user an Admin or Host?
      /// </summary>
      /// <param name="userId">int</param>
      /// <returns>bool</returns>
      public static bool IsAdminOrSuper(int userId)
      {
        // TODO - we are not handling non-existent users; NullReferenceException: Object reference not set...
        return IsAdminOrSuper(GetUser(userId));
      }
      /// <summary>
      /// is the current user an Admin or Host?
      /// </summary>
      /// <returns>bool</returns>
      public static bool IsAdminOrSuper()
      {
        return IsAdminOrSuper(UserController.Instance.GetCurrentUserInfo());
      }
      // old functions/names, for compatibility:
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
      public static bool IsAdminOrHost() { return IsAdminOrSuper(); }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
      public static bool IsAdminOrHost(UserInfo userInfo) { return IsAdminOrSuper(userInfo); }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
      public static bool IsAdminOrHost(int userId) { return IsAdminOrSuper(userId); }


      public static UserInfo GetUser(int userId)
      {
        return new UserController().GetUser(PortalSettings.Current.PortalId, userId);
      }


    }

  } // class Accu
}
