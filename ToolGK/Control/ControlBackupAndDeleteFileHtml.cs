using System;
using System.Collections.Generic;
using System.IO;

namespace ToolGK.Control
{
    internal class ControlBackupAndDeleteFileHtml
    {
        public int CountError;
        //Read list file html delete and add link modify to list

        public void ReadFileHtmlDeleteAddToList(string file, List<string> listPathHtml)
        {
            var lines = File.ReadAllLines(file);
            listPathHtml.AddRange(lines);
        }

        public void ReadFileCheckAddToList(string file, List<string> listPathHtml)
        {
            var lines = File.ReadAllLines(file);
            listPathHtml.AddRange(lines);
        }

        //BackUp file by Path
        public void CopyFileByPath(string sourceFile, string folderBackUp, string htmlModify)
        {
            var fileName = Path.GetFileName(htmlModify);

            var fullPathSourceFile = sourceFile + htmlModify;
            var getPathSourceFile = Path.GetDirectoryName(fullPathSourceFile);

            var fullPathFolderBackUp = folderBackUp + htmlModify;
            var getPathFolderBackUp = Path.GetDirectoryName(fullPathFolderBackUp);

            if (string.IsNullOrEmpty(getPathSourceFile) || string.IsNullOrEmpty(getPathFolderBackUp) || string.IsNullOrEmpty(getPathFolderBackUp))
            {
                return;
            }

            if (!Directory.Exists(getPathFolderBackUp))
            {
                Directory.CreateDirectory(getPathFolderBackUp);
            }
            try
            {
                if (fileName != null)
                {
                    File.Copy(Path.Combine(getPathSourceFile, fileName), Path.Combine(getPathFolderBackUp, fileName), true);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                CountError++;
            }
        }

        public bool CheckFileExits(string folderCheckExit, string fileCheck)
        {
            var files = folderCheckExit + fileCheck;

            return File.Exists(files);
        }

        //Delete file by path
        public void DeleteFileByPath(string file, string folderDelete)
        {
            var fullOfFileDelete = folderDelete + file;
            try
            {
                File.Delete(fullOfFileDelete);
            }
            catch (Exception ex)
            {
                LogError(ex);
                CountError++;
            }
        }

        //create log file
        private static void LogError(Exception ex)
        {
            //string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            //message += Environment.NewLine;
            //message += "-----------------------------------------------------------";
            //message += Environment.NewLine;
            var message = $"Message: {ex.Message}";
            //message += Environment.NewLine;
            //message += "-----------------------------------------------------------";
            //message += Environment.NewLine;
            var path = DateTime.Now.ToString("ddMMyyyy") + "log.txt";
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}
