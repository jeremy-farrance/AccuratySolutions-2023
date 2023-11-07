// using System.Text; // StringBuilder
// using System.Web; // IHtmlString
// using DotNetNuke.Entities.Portals; // PortalSettings

using System.Linq;
using System;

namespace Accuraty.Libraries.AccuLadder
{
  /// <summary>
  /// Root for calling AccuLadder Helpers; Accu.Dev, .Dnn, etc. - Tools, utilities, and shortcuts for DNN and 2SC projects
  /// </summary>
  public partial class Accu
  {

    /// <summary>
    /// Accu.Text Helper - Tools, utilities, and shortcuts for Text and String things
    /// </summary>
    public class Text 
    {
      /// <summary>
      /// Strip and Format a Phone number; has demo/good defaults and allows optional format to be passed in
      /// </summary>
      /// <param name="PhoneNumber"></param>
      /// <param name="PhoneFormat">Optional, default is {0:(###) ###-####}</param>
      /// <returns>Nicely formatted US phone number</returns>
      /// <remarks>Common US alternate formats: {0:###-###-####}, {0:(###) ###-####}, {0:###.###.####}, {0:### ### ####}</remarks>
      /// <example>
      /// 1. "111-555-1212" becomes "(111) 555-1212"
      /// 2. "2225551212" becomes "(222) 555-1212"
      /// 3. "[[333]].+555-1+2_1booya2" becomes "(333) 555-1210"
      /// </example>
      public static string FormatPhone(
        string PhoneNumber = "444-555-1212",
        string PhoneFormat = "{0:(###) ###-####}"
      )
      {
        // remove non-digits and pad with zeros if less than 10 numbers
        string numericPhone = new String(PhoneNumber.Where(Char.IsDigit).ToArray()).PadRight(10, '0');
        return String.Format(PhoneFormat, long.Parse(numericPhone));
      }
    }

  } // class Accu
}
