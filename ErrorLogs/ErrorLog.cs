namespace ADQCC_New.ErrorLogs
{
    public class ErrorLog
    {
        public static void ErrorLogs(Exception ex, string Repo)
        {
            string message = "Repository Name  : " + Repo.ToString();
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += "----------------------------------------------------------------------------------------------------------------------";
            message += Environment.NewLine;

            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "ErrorFile/ErrorLog.txt"));
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}
