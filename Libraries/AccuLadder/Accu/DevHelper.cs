using System;
using System.Collections.Generic;
using System.IO;                          // Path.Combine or .Join
using System.Net;
using System.Text;                        // StringBuilder, Encoding, 
using System.Text.RegularExpressions;
using System.Web;                         // IHtmlString, HttpContext
using static System.Net.WebRequestMethods;

namespace Accuraty.Libraries.AccuLadder
{
  /// <summary>
  /// Root for calling AccuLadder Helpers; Accu.Dev, .Dnn, etc. - Tools, utilities, and shortcuts for DNN and 2SC projects
  /// </summary>
  public partial class Accu
  {
    /// <summary>
    /// Accu.Dev Helper - Tools, utilities, and shortcuts for DNN and 2SC projects
    /// </summary>
    public class Dev
    {
#if DEBUG
      private static bool _isDebug = true;
#else
      private static bool _isDebug = false;
#endif
      /// <summary>
      /// Allows the developer to enable debug logging even in release mode
      /// </summary>
      public static bool Debug { get => _isDebug; set => _isDebug = value; }

      private static StringBuilder sb = new StringBuilder();
      private static StringBuilder Sb { get => sb; set => sb = value; }

      private static readonly string _templateNameValue = "<span class=\"font-weight-bold\">{0}:</span> {1}";
      private static readonly string _templateLogOutputWrapper = "<pre title=\"AccuLadder: Accu.Dev Helper\">debug output:\r\n{0}</pre>";

      // it would be nice to implement a timer in here (like the 2sxc one) using TimeSpans and such

      /// <summary>
      /// Log a simple message for debug output
      /// </summary>
      /// <param name="msg">A string you want logged</param>
      /// <example>
      /// <code>Accu.Dev.Log($"Reached milestone 2 as {DatTime.Now.ToString("g")}")</code>
      /// </example>
      /// <remarks>These are the REMARKS</remarks>
      /// <exception cref="System.Exception">This is the EXCEPTION</exception>
      /// <see href="https://github.com/jeremy-farrance/AccuratySolutions-2023"/>
      public static void Log(string msg)
      {
        if (_isDebug)
        {
          Sb.AppendLine(msg);
        }
      }

      /// <summary>
      /// Log a name/value pair to the debug log
      /// </summary>
      /// <param name="name"></param>
      /// <param name="value"></param>
      public static void Log(string name, string value)
      {
        if (_isDebug)
        {
          string result = string.Format(_templateNameValue, name, value);
          Sb.AppendLine(result);
        }
      }

      /// same as above, but for other types
      public static void Log(string name, bool value)
      {
        if (_isDebug)
        {
          Log(name, value.ToString());
        }
      }

      // same as above, but for other types
      public static void Log(string name, int value)
      {
        if (_isDebug)
        {
          Log(name, value.ToString());
        }
      }

      /// same as above, but for other types
      public static void Log(string name, DateTime? value = null, string dateTimeFormat = "g")
      {
        if (_isDebug)
        {
          DateTime dateTime = value ?? DateTime.Now;
          Log(name, dateTime.ToString(dateTimeFormat));
        }
      }

      // Reminder: use IHtmlString to return HTML

      /// <summary>
      /// Get the log (for output) and optionally clear it
      /// </summary>
      /// <param name="clearLog (defaults to true)"></param>
      /// <returns>A pre-formatted HtmlString</returns>
      public static IHtmlString GetLog(bool clearLog = true)
      {
        HtmlString result = new HtmlString(string.Format(_templateLogOutputWrapper, Sb.ToString()));
        if (clearLog)
        {
          Sb.Clear();
        }

        if (_isDebug)
        {
          return result;
        }
        else
        {
          return new HtmlString("");
        }
      }

      public static string CombinePathSegments(string pathSeparator = "/", params string[] segments)
      {
        if (segments == null || segments.Length == 0)
          return string.Empty;

        char[] trimChars = { '/', '\\' };

        string combinedPath = segments[0].TrimEnd(trimChars);

        for (int i = 1; i < segments.Length; i++)
        {
          combinedPath = $"{combinedPath.TrimEnd(trimChars)}{pathSeparator}{segments[i].TrimStart(trimChars)}";
        }

        return combinedPath;
      }

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
      /// Get the version of an installed DLL in /bin
      /// </summary>
      /// <remarks>Example: expecting "ToSic.Razor" and we assume its in /bin and ends in .dll</remarks>
      public static string GetVersion(string targetDll, string fileExt = ".dll")
      {
        string target = Path.Combine(HttpContext.Current.Server.MapPath("bin/"), targetDll + fileExt);
        if (System.IO.File.Exists(target))
        {
          string result;
          try
          {
            result = System.Reflection.Assembly.LoadFrom(target).GetName().Version.ToString();
          }
          catch
          {
            return $"Error: DLL exists, but could not load version for {targetDll}";
          }
          return result;
        }
        else
        {
          return $"Error: DLL not found, could not load version for {targetDll}";
        }
      }

      /// <summary>
      /// Get IP address of the visitor
      /// </summary>
      /// <returns>WAN IP address (string)</returns>
      public static string GetIpAddress()
      {
        string stringIpAddress;
        stringIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (stringIpAddress == null)
        {
          stringIpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        return stringIpAddress;
      }

      public static bool IsAccuratyIp()
      {
        var list = new List<string>
        {
          "127.0.0.1",        // localhost
          "140.141.191.145",   // 1800SO
        };
        return list.Contains(GetIpAddress());
      }

      /// <summary>
      /// Get IP from domain
      /// </summary>
      /// <param name="host">A valid FQDN</param>
      /// <returns>IP address string</returns>
      /// <remarks>does a potentially slow DNS lookup</remarks>
      public static string GetIpAddressFromHost(string host)
      {
        string ip;
        try
        {
          IPHostEntry ipHostEntry = Dns.GetHostEntry(host);
          if (ipHostEntry.AddressList.Length > 0)
          {
            ip = ipHostEntry.AddressList[0].ToString();
          }
          else
          {
            ip = "No information found.";
          }
        }
        catch (Exception)
        {
          ip = "An unspecified error occured.";
          return ip;
        }
        return ip;
      }
    }


  } // class Accu
} // end of namespace Accuraty.Libraries.AccuLadder
