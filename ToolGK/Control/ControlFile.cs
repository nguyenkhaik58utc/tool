using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ToolGK.Model;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ToolGK.Control
{
    internal class ControlFile
    {
        #region Read file by path and add file name to list
        //Read file by path and add file name to list
        public void ReadFileAddFileNameToList(string file, List<string> listFile)
        {
            var lines = File.ReadAllLines(file);
            listFile.AddRange(lines.Select(Path.GetFileName));
        }
        #endregion

        #region Read file by path and add path to list
        //Read file by path and add path to list
        public void ReadFileAddPathToList(string file, List<string> listFile)
        {
            var lines = File.ReadAllLines(file);
            listFile.AddRange(lines);
        }
        #endregion

        #region Search file image in file and add to object
        //Search file image in file and add to object
        public void SearchImageInFile(string file, string imageName, string listFullPathImage, List<ImageInfile> listImage)
        {
            var i = 0;
            var lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                var checkStringInLine = line.Contains(imageName);
                if (checkStringInLine)
                {
                    listImage.Add(new ImageInfile(imageName, listFullPathImage, file, i, line));
                }
                i++;
            }
        }
        #endregion

        #region create excel file and push data to file
        //create excel file and push data to file
        public void ExportExcelOutput(string file, List<ImageInfile> listImage)
        {
            var xlApp = new Excel.Application();

            object misValue = System.Reflection.Missing.Value;

            var xlWorkBook = xlApp.Workbooks.Add(misValue);
            var xlWorkSheet1 = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
            var xlWorkSheet2 = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
            var xlWorkSheet3 = (Excel.Worksheet)xlWorkBook.Worksheets.Add();

            xlWorkSheet3.Name = "html";
            xlWorkSheet2.Name = "aspx,ascx,vb";
            xlWorkSheet1.Name = "other";

            xlWorkSheet1.Cells[1, 1] = "Image";
            xlWorkSheet1.Cells[1, 2] = "Full Path Image";
            xlWorkSheet1.Cells[1, 3] = "Link Source File";
            xlWorkSheet1.Cells[1, 4] = "Line";
            xlWorkSheet1.Cells[1, 5] = "Source Code";
            xlWorkSheet2.Cells[1, 1] = "Image";
            xlWorkSheet2.Cells[1, 2] = "Full Path Image";
            xlWorkSheet2.Cells[1, 3] = "Link Source File";
            xlWorkSheet2.Cells[1, 4] = "Line";
            xlWorkSheet2.Cells[1, 5] = "Source Code";
            xlWorkSheet3.Cells[1, 1] = "Image";
            xlWorkSheet3.Cells[1, 2] = "Full Path Image";
            xlWorkSheet3.Cells[1, 3] = "Link Source File";
            xlWorkSheet3.Cells[1, 4] = "Line";
            xlWorkSheet3.Cells[1, 5] = "Source Code";

            for (var i = 0; i < listImage.Count; i++)
            {
                var fileNameOfPath = Path.GetFileName(listImage[i].PathFileName);
                if (fileNameOfPath == null)
                {
                    continue;
                }
                var splitFileName = fileNameOfPath.Split('.');
                var fileNameStyle = splitFileName[splitFileName.Length - 1];
                switch (fileNameStyle)
                {
                    case "html":
                        xlWorkSheet3.Cells[i + 2, 1] = listImage[i].ImageName;
                        xlWorkSheet3.Cells[i + 2, 2] = listImage[i].FullPathImage;
                        xlWorkSheet3.Cells[i + 2, 3] = listImage[i].PathFileName;
                        xlWorkSheet3.Cells[i + 2, 4] = listImage[i].Line;
                        xlWorkSheet3.Cells[i + 2, 5] = listImage[i].SourceCodeByLine;
                        break;
                    case "aspx":
                    case "vb":
                    case "ascx":
                        xlWorkSheet2.Cells[i + 2, 1] = listImage[i].ImageName;
                        xlWorkSheet2.Cells[i + 2, 2] = listImage[i].FullPathImage;
                        xlWorkSheet2.Cells[i + 2, 3] = listImage[i].PathFileName;
                        xlWorkSheet2.Cells[i + 2, 4] = listImage[i].Line;
                        xlWorkSheet2.Cells[i + 2, 5] = listImage[i].SourceCodeByLine;
                        break;
                    default:
                        xlWorkSheet1.Cells[i + 2, 1] = listImage[i].ImageName;
                        xlWorkSheet1.Cells[i + 2, 2] = listImage[i].FullPathImage;
                        xlWorkSheet1.Cells[i + 2, 3] = listImage[i].PathFileName;
                        xlWorkSheet1.Cells[i + 2, 4] = listImage[i].Line;
                        xlWorkSheet1.Cells[i + 2, 5] = listImage[i].SourceCodeByLine;
                        break;
                }
            }

            xlWorkBook.SaveAs(file, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet1);
            Marshal.ReleaseComObject(xlWorkSheet2);
            Marshal.ReleaseComObject(xlWorkSheet3);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }
        #endregion

        #region Setup Redirect Tool
        //Begin Setup Redirect Tool-----------------------------------------------------
        public StringBuilder CreateRedirect(string excelFile, int start, int end)
        {
            var sb = new StringBuilder();
            if (!File.Exists(excelFile))
            {
                MessageBox.Show(@"File excel don't exist!");
            }
            else
            {
                sb = sb.AppendLine("# " + DateTime.Now.ToString("yyyyMMdd"));
                object misValue = System.Reflection.Missing.Value;
                var xlApp = new Excel.Application();
                var xlWorkBook = xlApp.Workbooks.Open(excelFile);
                var xlWorkSheet1 = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
                for (var i = start; i <= end; i++)
                {
                    var sortLink = (string)(xlWorkSheet1.Cells[i, 2] as Excel.Range)?.Value;
                    var actualLink = (string)(xlWorkSheet1.Cells[i, 3] as Excel.Range)?.Value;
                    var typeRedirect = " [R=301,L]";
                    if (actualLink != null && actualLink.Contains("http://www.globalknowledge.co.jp"))
                    {
                        actualLink = actualLink.Replace("http://www.globalknowledge.co.jp", "");
                    }
                    if (actualLink != null && (actualLink.Contains("?") && actualLink.Contains("#")))
                    {
                        var parameter = actualLink.IndexOf("?", StringComparison.Ordinal);
                        var specialChar = actualLink.IndexOf("#", StringComparison.Ordinal);
                        typeRedirect = parameter > specialChar ? " [R=301,NE,L]" : " [R=301,NE]";
                    }
                    sb = sb.AppendLine("RewriteRule ^" + sortLink + "$ " + actualLink + typeRedirect);
                }
                sb = sb.AppendLine("");
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet1);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
            return sb;
        }
        //End Setup Redirect Tool-----------------------------------------------------
        #endregion
    }
}
