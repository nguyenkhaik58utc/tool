using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace ToolGK.Control
{
    internal class ControlCheckLink
    {
        public void GetLinkHtmlFromChrome(List<string> listLinkHtml, List<string> listUrl)
        {
            //var driver = new ChromeDriver();
            ////int count = 0;
            //for (int i = 0; i < listLinkHtml.Count; i++)
            //{

            //    //driver.FindElement(By.CssSelector("body")).SendKeys(System.Windows.Forms.Keys.Control + "t");
            //    //string newTabInstance = driver.WindowHandles[driver.WindowHandles.Count - 1].ToString();
            //    //driver.SwitchTo().Window(newTabInstance);
            //    //driver.Navigate().GoToUrl(listLinkHtml[i]);

            //    driver.Url = listLinkHtml[i];
            //    string url = driver.Url;
            //    listUrl.Add(url);


            //    driver.Navigate().GoToUrl("http://tk3ftptlwbvm16/onemscom/default.aspx");
            //    //count++;
            //    //if (count % 100 == 0)
            //    //{
            //    //    driver.Close();
            //    //    driver.Quit();
            //    //    driver = new ChromeDriver();
            //    //}

            //}
            //driver.Close();
            //driver.Quit();
        }

        public void ExportExcelFile(List<string> listLinkHtml, List<string> listUrl, string file)
        {
            var xlApp = new Excel.Application();

            object misValue = System.Reflection.Missing.Value;

            var xlWorkBook = xlApp.Workbooks.Add(misValue);
            var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];

            xlWorkSheet.Cells[1, 1] = "Link Origin";
            xlWorkSheet.Cells[1, 2] = "Link Chrome";
            xlWorkSheet.Cells[1, 3] = "Result Compare";

            for (var i = 0; i < listLinkHtml.Count; i++)
            {
                xlWorkSheet.Cells[i + 2, 1] = listLinkHtml[i];
                xlWorkSheet.Cells[i + 2, 2] = listUrl[i];
                if (listLinkHtml[i] == listUrl[i])
                {
                    xlWorkSheet.Cells[i + 2, 3] = "OK";
                }
                else
                {
                    xlWorkSheet.Cells[i + 2, 3] = "NG";
                }
            }
            xlWorkBook.SaveAs(file, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
