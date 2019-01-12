using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DB.Services
{
    public class ExceptionMessage
    {
        public string Subject { get; set; }
        public string Message { get; set; }
    }
    public static class ExceptionMessageExt
    {
        public static IEnumerable<TSource> FromHierarchy<TSource>(
    this TSource source,
    Func<TSource, TSource> nextItem,
    Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }
        public static ExceptionMessage ToExceptionMessage(this Exception exmail)
        {
            const string newline = "<br/>";
            var errorlineNo = exmail.StackTrace.Substring(exmail.StackTrace.Length - 7, 7);
            var messages = exmail.FromHierarchy(ex => ex.InnerException).Select(ex => ex.Message);
            var errormsg = String.Join(Environment.NewLine, messages);
            // var errormsg = exmail.GetType().Name;
            var extype = exmail.GetType().ToString();
            var errorLocation = exmail.Message;
            var emailHead = "<b>Dear Team,</b>" + "<br/>" + "An exception occurred in a Application Url" + " "  +
                            " " + "With following Details" + "<br/>" + "<br/>";
            const string emailSing = newline + "Thanks and Regards" + newline + "    " + "     " + "<b>Application Admin </b>" +
                                     "</br>";
            var sub = "Exception occurred" + " " + "in Application";
            string errortomail = emailHead + "<b>Log Written Date: </b>" + " " + DateTime.Now.ToString(CultureInfo.InvariantCulture) + newline +
                                 "<b>Error Line No :</b>" + " " + errorlineNo + "\t\n" + " " + newline +
                                 "<b>Error Message:</b>" + " " + errormsg + newline + "<b>Exception Type:</b>" + " " +
                                 extype + newline + "<b> Error Details :</b>" + " " + errorLocation + newline +
                                 "<b>Error Page Url:</b>" + " " + newline + newline + newline + newline +
                                 emailSing;

            return new ExceptionMessage
            {
                Subject = sub,
                Message = errortomail
            };
        }
    }
    

}
