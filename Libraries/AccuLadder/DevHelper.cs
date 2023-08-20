using System.Text; // StringBuilder
using System.Web; // IHtmlString

namespace Accuraty.Libraries.AccuLadder
{
    /// <summary>
    /// DevHelper - Helpers, tools, utilities, and shortcuts for DNN and 2sxc projects
    /// </summary>
    public class DevHelper
    {
        private bool _isDebug = false;

        /// <summary>
        /// Get whether we are in debug mode; used to toggle logging, etc.
        /// </summary>
        /// <returns>true/false</returns>
        public bool GetDebug()
        {
            return _isDebug;
        }

        /// <summary>
        /// Set whether we are in debug mode; used to toggle logging, etc.
        /// </summary>
        /// <param name="value">none</param>
        public void SetDebug(bool value)
        {
            _isDebug = value;
        }

        private StringBuilder sb { get; set; } = new StringBuilder();

        // it would be nice to implement a timer in here (like the 2sxc one) using TimeSpans and such

        private readonly string _templateValue = "<span class=\"font-weight-bold\">{0}:</span> {1}";
        private readonly string _templatePre = DevHelperHelpers.HtmlDebugWrapper;

        public void Log(string msg)
        {
            if (GetDebug())
            {
                sb.AppendLine(msg);
            }
        }

        public void Log(string name, string value)
        {
            if (GetDebug())
            {
                string result = string.Format(_templateValue, name, value);
                sb.AppendLine(result);
            }
        }

        public void Log(string name, bool value)
        {
            if (GetDebug())
            {
                Log(name, value.ToString());
            }
        }

        public void Log(string name, int value)
        {
            if (GetDebug())
            {
                Log(name, value.ToString());
            }
        }

        // Reminder: use IHtmlString to return HTML
        /// <summary>
        /// Get the log (for output) and optionally clear it
        /// </summary>
        /// <param name="clearLog (defaults to false)"></param>
        /// <returns>An HTML preformatted string</returns>
        public IHtmlString GetLog(bool clearLog = false)
        {
            HtmlString result = new HtmlString(string.Format(_templatePre, sb.ToString()));
            if (clearLog)
            {
                sb.Clear();
            }

            if (GetDebug() && sb.Length > 0)
            {
                return result;
            }
            else
            {
                return new HtmlString("");
            }
        }

    } // class DevHelper
}