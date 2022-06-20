using System;
using System.Diagnostics;
using System.Text;

namespace ScheduleFinder.util
{
    public static class Extensions
    {
        public static string ExceptionInfo(this Exception exception)
        {

            StackFrame stackFrame = (new StackTrace(exception, true)).GetFrame(0);
            return string.Format("At line {0} column {1} in {2}: {3} {4}{3}{5}  ",
               stackFrame.GetFileLineNumber(), stackFrame.GetFileColumnNumber(),
               stackFrame.GetMethod(), Environment.NewLine, stackFrame.GetFileName(),
               exception.Message);

        }

        public static string FlattenException(Exception exception)
        {
            var stringBuilder = new StringBuilder();

            while (exception != null)
            {
                stringBuilder.AppendLine(exception.Message);
                stringBuilder.AppendLine(exception.StackTrace);

                exception = exception.InnerException;
            }

            return stringBuilder.ToString();
        }



    }
}
