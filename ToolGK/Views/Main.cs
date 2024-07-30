using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Windows.Forms;
using ToolGK.Control;
using ToolGK.Model;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ToolGK.Views
{
    public partial class Main : Form
    {
        #region Field list
        public Main()
        {
            InitializeComponent();
        }

        //Declare variable for search image in file
        public string PathListFileImage;
        public string PathFolderSearch;
        public string PathFileExcelSource;

        public List<string> ListImage = new List<string>();
        public List<string> ListFullPathImage = new List<string>();
        public List<string> ListPathSourceCode = new List<string>();
        private readonly List<ImageInfile> _listImageInFile = new List<ImageInfile>();

        public List<string> ListResult = new List<string>();
        public int NumberFileNotFound;
        public string PathListExit;
        public string ResultCheckFileExitNotFound = "Number File Not Found in Project: ";
        public string ResultCheckFileExitOk = "OK";
        public string PathFolderCheck;
        //Declare variable for backup and delete
        public string PathListFileDelete;
        public string PathFolderDelete;
        public string PathFolderBackUp;

        public List<string> ListHtmlDelete = new List<string>();
        public List<string> ListFileCheck = new List<string>();

        //Declare variable for check link html
        public string PathListHtmlCheck;
        public string PathExcelOutput;

        public List<string> ListLinkHtmlCheck = new List<string>();
        public List<string> ListUrl = new List<string>();

        //Declare variable for capture image by url
        public string PathListUrl;
        public string PathSaveImage;

        private readonly ControlFile _control = new ControlFile();
        private readonly ControlBackupAndDeleteFileHtml _controlBackupAndDelete = new ControlBackupAndDeleteFileHtml();
        private readonly ControlCheckLink _controlCheckLink = new ControlCheckLink();
        private readonly ControlCapture _controlCapture = new ControlCapture();

        private const string DebugVbsTemp = "//X #filename #args";
        #endregion

        #region process find logo image in source code
        //Open path to file list image
        private void BtnInputListImage_Click(object sender, EventArgs e)
        {
            var result1 = openFileDialogListImage.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                txtInputListImage.Text = openFileDialogListImage.FileName;
            }
        }

        //Open path to list path file search
        private void BtnInputSource_Click(object sender, EventArgs e)
        {
            var result2 = openFileDialogListPathFileSource.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                txtInputSource.Text = openFileDialogListPathFileSource.FileName;
            }
        }

        //Open path to file excel output
        private void BtnPathExcelOutputResult_Click(object sender, EventArgs e)
        {
            var result2 = openFileDialogPathExcelOutput.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                txtPathExcelOutputResult.Text = openFileDialogPathExcelOutput.FileName;
            }
        }

        //Event click button search logo in source code
        private void BtnSearchLogo_Click(object sender, EventArgs e)
        {

            PathListFileImage = txtInputListImage.Text;
            PathFolderSearch = txtInputSource.Text;
            PathFileExcelSource = txtPathExcelOutputResult.Text;

            _control.ReadFileAddFileNameToList(PathListFileImage, ListImage);
            _control.ReadFileAddPathToList(PathListFileImage, ListFullPathImage);
            _control.ReadFileAddPathToList(PathFolderSearch, ListPathSourceCode);

            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = listImage.Count-1;
            //progressBar1.Step = 1;

            for (var i = 0; i < ListImage.Count; i++)
            {
                for (var j = 0; j < ListPathSourceCode.Count; j++)
                {
                    _control.SearchImageInFile(ListPathSourceCode[j], ListImage[i], ListFullPathImage[i], _listImageInFile);

                    lblCountFile.Text = ((j + 1)) + @"/" + (ListPathSourceCode.Count);
                    lblCountFile.Refresh();
                }
                //progressBar1.PerformStep();
                lblcountImage.Text = ((i + 1)) + @"/" + (ListImage.Count);
                lblcountImage.Refresh();
            }
            _control.ExportExcelOutput(PathFileExcelSource, _listImageInFile);
            MessageBox.Show(@"Done");
            Close();
        }
        #endregion

        #region Processed delete html file
        //Open path to list file html delete
        private void BtnInputPathFileListHtmlDelete_Click(object sender, EventArgs e)
        {
            var result1 = openFileDialogInputListHtmlDelete.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                txtInputListHtmlDelete.Text = openFileDialogInputListHtmlDelete.FileName;
            }
        }

        //Open path to folder delete
        private void BtnFolderDelete_Click(object sender, EventArgs e)
        {
            var result2 = folderBrowserDialogFolderDelete.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                txtFolderDelete.Text = folderBrowserDialogFolderDelete.SelectedPath;
            }
        }

        //Open path to folder backup
        private void BtnFolderBackUp_Click(object sender, EventArgs e)
        {
            var result3 = folderBrowserDialogFolderBackUp.ShowDialog();
            if (result3 == DialogResult.OK)
            {
                txtFolderBackup.Text = folderBrowserDialogFolderBackUp.SelectedPath;
            }
        }

        //Event lick button back up and delete file
        private void BtnBackUpAndDelete_Click(object sender, EventArgs e)
        {
            PathListFileDelete = txtInputListHtmlDelete.Text;
            PathFolderDelete = txtFolderDelete.Text;
            PathFolderBackUp = txtFolderBackup.Text;

            _controlBackupAndDelete.ReadFileHtmlDeleteAddToList(PathListFileDelete, ListHtmlDelete);

            progressBar2.Minimum = 0;
            progressBar2.Maximum = ListHtmlDelete.Count - 1;
            progressBar2.Step = 1;
            foreach (var html in ListHtmlDelete)
            {
                // listHtmlDelete[i] = '/' + listHtmlDelete[i];
                _controlBackupAndDelete.CopyFileByPath(PathFolderDelete, PathFolderBackUp, '/' + html);
                if (_controlBackupAndDelete.CountError == 0)
                {
                    _controlBackupAndDelete.DeleteFileByPath(html, PathFolderDelete);
                }
                else
                {
                    _controlBackupAndDelete.CountError = 0;
                }
                progressBar2.PerformStep();
            }
            MessageBox.Show(@"Delete success !");
        }

        #endregion

        #region Process check link html
        //Open path to list link html
        private void BtnInputListHtmlCheck_Click(object sender, EventArgs e)
        {
            var result4 = openFileDialogInputListHtmlCheck.ShowDialog();
            if (result4 == DialogResult.OK)
            {
                txtInputListHtmlCheck.Text = openFileDialogInputListHtmlCheck.FileName;
            }
        }

        //Open path file to file excel export
        private void BtnPathExcelOutput_Click(object sender, EventArgs e)
        {
            var result5 = openFileDialogPathFileExcelOutput.ShowDialog();
            if (result5 == DialogResult.OK)
            {
                txtPathExcelOutput.Text = openFileDialogPathFileExcelOutput.FileName;
            }
        }


        //Event lick button check link
        private void BtnCheckLink_Click(object sender, EventArgs e)
        {
            PathListHtmlCheck = txtInputListHtmlCheck.Text;
            PathExcelOutput = txtPathExcelOutput.Text;

            _control.ReadFileAddPathToList(PathListHtmlCheck, ListLinkHtmlCheck);
            _controlCheckLink.GetLinkHtmlFromChrome(ListLinkHtmlCheck, ListUrl);
            _controlCheckLink.ExportExcelFile(ListLinkHtmlCheck, ListUrl, PathExcelOutput);

            MessageBox.Show(@"Done");

        }
        #endregion

        #region Capture Image by url
        //Capture Image by url
        private void BtnInputListLinkHtml_Click(object sender, EventArgs e)
        {
            var result4 = openFileDialogInputListLinkHtml.ShowDialog();
            if (result4 == DialogResult.OK)
            {
                txtInputListLinkHtml.Text = openFileDialogInputListLinkHtml.FileName;
            }
        }

        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            var result3 = folderBrowserDialogInputFolderSaveImage.ShowDialog();
            if (result3 == DialogResult.OK)
            {
                txtSaveImage.Text = folderBrowserDialogInputFolderSaveImage.SelectedPath;
            }
        }

        private void BtnCapture_Click(object sender, EventArgs e)
        {
            PathListUrl = txtInputListLinkHtml.Text;
            PathSaveImage = txtSaveImage.Text;
            _control.ReadFileAddPathToList(PathListUrl, ListUrl);
            for (var i = 0; i < ListUrl.Count; i++)
            {
                _controlCapture.CaptureImageByUrl(ListUrl[i], PathSaveImage, i);
            }
        }
        #endregion

        #region Setup Redirect
        private void BtnBrowserExcel_Click(object sender, EventArgs e)
        {
            var result1 = openFileDialogListImage.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                txtPathExcel.Text = openFileDialogListImage.FileName;
            }
        }

        private void BtnPathHttpd_Click(object sender, EventArgs e)
        {
            var result1 = openFileDialogListImage.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                txtPathHttpd.Text = openFileDialogListImage.FileName;
            }
        }

        private void BtnSetupRedirect_Click(object sender, EventArgs e)
        {
            //Check input file and range
            if (txtPathExcel.Text.Equals("") | txtRangeStart.Text.Equals("") | txtRangeEnd.Text.Equals("") | txtPathHttpd.Text.Equals(""))
            {
                MessageBox.Show(@"Please insert all input file and range");
                return;
            }
            var sb = _control.CreateRedirect(txtPathExcel.Text, Convert.ToInt32(txtRangeStart.Text), Convert.ToInt32(txtRangeEnd.Text));
            var lines = File.ReadAllLines(txtPathHttpd.Text);
            for (var i = 0; i < lines.Length; i++)
            {
                if (lines[i].Equals("# ??---------------------------------------------------------------------------------------------------------------------"))
                {
                    lines[i] = sb + lines[i];
                    break;
                }
            }
            File.WriteAllLines(txtPathHttpd.Text, lines);
            MessageBox.Show(@"Done !");
        }
        #endregion

        #region Test link Redirect

        ///
        /// Checks the file exists or not.
        ///
        /// The URL of the remote file.
        /// True : If the file exits, False if file not exists
        public string RemoteFileExists(string url)
        {
            string dest = null;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = AcceptAllCertifications;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                //Creating the HttpWebRequest
                //Setting the Request method HEAD, you can also use GET too.
                if (WebRequest.Create(url) is HttpWebRequest request)
                {
                    request.Method = "HEAD";
                    // request.AllowAutoRedirect = false;

                    //Getting the Web Response.
                    if (request.GetResponse() is HttpWebResponse response)
                    {
                        dest = response.ResponseUri.ToString();

                        //if ((int)response.StatusCode >= 300 && (int)response.StatusCode <= 399)
                        //{
                        //    dest = response.Headers["Location"];
                        //}
                        //else if ((int) response.StatusCode == 200)
                        //{
                        //    dest = response.ResponseUri.ToString();
                        //}

                        //Returns TRUE if the Status code == 200
                        response.Close();
                    }
                }
            }
            catch (WebException ex)
            {
                //Any exception will returns false.
                //var responseError = (HttpWebResponse)ex.Response;
                //return responseError.ResponseUri.ToString();
                dest = ex.Message;
            }
            return dest;
        }

        private void BtnTestLink_Click(object sender, EventArgs e)
        {
            object misValue = System.Reflection.Missing.Value;
            var xlApp = new Excel.Application
            {
                DisplayAlerts = false
            };
            var xlWorkBook = xlApp.Workbooks.Open(txtPathExcel.Text);
            xlWorkBook.Sheets.Add(After: xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
            var xlWorkSheet1 = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
            var xlWorkSheet3 = (Excel.Worksheet)xlWorkBook.Worksheets.Item[xlWorkBook.Sheets.Count];
            try
            {
                xlWorkSheet3.Cells[1, 1] = "LINE";
                xlWorkSheet3.Cells[1, 2] = "SORTLINK";
                xlWorkSheet3.Cells[1, 3] = "ACTUALLINK";
                xlWorkSheet3.Cells[1, 4] = "COMPARELINK";
                xlWorkSheet3.Cells[1, 5] = "RESULT";
                var start = Convert.ToInt32(txtRangeStart.Text);
                var end = Convert.ToInt32(txtRangeEnd.Text);
                for (var i = start; i <= end; i++)
                {
                    var sortLink = "https://www.trainocate.co.jp" + (string)(xlWorkSheet1.Cells[i, 2] as Excel.Range)?.Value;
                    var actualLink = RemoteFileExists(sortLink);
                    actualLink = actualLink.Replace("http://www.trainocate.co.jp", "").Replace("https://www.trainocate.co.jp", "");
                    var compareLink = (string)(xlWorkSheet1.Cells[i, 3] as Excel.Range)?.Value;
                    xlWorkSheet3.Cells[i - start + 2, 1] = i;
                    xlWorkSheet3.Cells[i - start + 2, 2] = sortLink;
                    xlWorkSheet3.Cells[i - start + 2, 3] = actualLink;
                    xlWorkSheet3.Cells[i - start + 2, 4] = compareLink;
                    if (actualLink == compareLink)
                    {
                        xlWorkSheet3.Cells[i - start + 2, 5] = "OK";
                    }
                    else
                    {
                        xlWorkSheet3.Cells[i - start + 2, 5] = "NG";
                    }
                }
                xlWorkBook.SaveAs(txtPathExcel.Text);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Marshal.ReleaseComObject(xlWorkSheet1);
                Marshal.ReleaseComObject(xlWorkSheet3);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
                MessageBox.Show(@"Done!");
            }

        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        #endregion

        #region Backup
        private void BtnBackup_Click(object sender, EventArgs e)
        {
            PathListFileDelete = txtInputListHtmlDelete.Text;
            PathFolderDelete = txtFolderDelete.Text;
            PathFolderBackUp = txtFolderBackup.Text;

            _controlBackupAndDelete.ReadFileHtmlDeleteAddToList(PathListFileDelete, ListHtmlDelete);
            foreach (var html in ListHtmlDelete)
            {
                _controlBackupAndDelete.CopyFileByPath(PathFolderDelete, PathFolderBackUp, html);
            }
            ListHtmlDelete = new List<string>();
            MessageBox.Show(@"Backup Success !");
        }

        // check file exit
        private void Button1_Click(object sender, EventArgs e)
        {
            PathListExit = textBox2.Text;
            PathFolderCheck = textBox1.Text;
            _controlBackupAndDelete.ReadFileCheckAddToList(PathListExit, ListFileCheck);
            foreach (var file in ListFileCheck.Where(file => !_controlBackupAndDelete.CheckFileExits(PathFolderCheck, file)))
            {
                NumberFileNotFound++;

                ListResult.Add(PathFolderCheck + file);
            }
            if (NumberFileNotFound != 0)
            {

                var result = ResultCheckFileExitNotFound + NumberFileNotFound + "\n";

                result = ListResult.Aggregate(result, (current, item) => current + "\n" + "  - " + item);
                listFileNotExits.Text = result;
            }
            else
            {
                listFileNotExits.Text = ResultCheckFileExitOk;
            }
            ListResult = new List<string>();
            NumberFileNotFound = 0;
            ListFileCheck = new List<string>();
            PathListExit = null;
            PathFolderCheck = null;
        }

        //open list file must be check exits
        private void Button2_Click(object sender, EventArgs e)
        {
            var result1 = openFileDialogInputListfileExit.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                textBox2.Text = openFileDialogInputListfileExit.FileName;
            }
        }

        private void ProgressBarDeleteFile_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TabBackUpAndDeleteFile_Click(object sender, EventArgs e)
        {

        }

        //open folder 
        private void Button2_Click_1(object sender, EventArgs e)
        {
            var result2 = folderBrowserDialogFolderCheckExit.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialogFolderCheckExit.SelectedPath;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //refresh
        private void Button3_Click(object sender, EventArgs e)
        {

            textBox2.Text = "";
            textBox1.Text = "";
            listFileNotExits.Text = "";
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }
        //End Setup Redirect Tool-----------------------------------------------------
        #endregion

        #region Debug Tool
        private void Button4_Click(object sender, EventArgs e)
        {
            var rs = openFileDialogSelectVBSFile.ShowDialog();
            if (rs == DialogResult.OK)
            {
                debugvbsfilename.Text = openFileDialogSelectVBSFile.FileName;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var command = DebugVbsTemp;
            command = command.Replace("#filename", debugvbsfilename.Text);
            command = command.Replace("#args", debugvbsargs.Text);
            // System.Diagnostics.Process.Start(command);

            var cmd = new Process
            {
                StartInfo =
                {
                    FileName = "cscript.exe",
                    Arguments = command,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };
            cmd.Start();

            // cmd.StandardInput.WriteLine(command);
            // cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            var output = cmd.StandardOutput.ReadToEnd();
            MessageBox.Show(output);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var command = DebugVbsTemp;
            command = command.Replace("#filename", debugvbsfilename.Text);
            command = command.Replace("#args", debugvbsargs.Text);
            // System.Diagnostics.Process.Start(command);

            var cmd = new Process
            {
                StartInfo =
                {
                    FileName = "cscript.exe",
                    Arguments = command.Substring(4),
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };
            cmd.Start();

            // cmd.StandardInput.WriteLine(command);
            // cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            var output = cmd.StandardOutput.ReadToEnd();
            MessageBox.Show(output);
        }
        #endregion

        #region Find layout
        private void Button7_Click(object sender, EventArgs e)
        {
            var rs = fbdProjectFolder.ShowDialog();
            if (rs == DialogResult.OK)
            {
                tbProjectFolder.Text = fbdProjectFolder.SelectedPath;
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            var rs = fbdOutputFolder.ShowDialog();
            if (rs == DialogResult.OK)
            {
                tbOutputFolder.Text = fbdOutputFolder.SelectedPath;
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            var row = 1;
            var app = new Excel.Application
            {
                DisplayAlerts = false
            };
            var wb = app.Workbooks.Add(Type.Missing);
            var ws = (Excel.Worksheet)wb.Worksheets.Item[1];

            SearchInFile("*.html", ws, ref row);
            SearchInFile("*.aspx", ws, ref row);
            ws.Columns.AutoFit();

            wb.SaveAs(tbOutputFolder.Text + "\\output.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
            wb.Close();
            app.Quit();
            Marshal.ReleaseComObject(ws);
            Marshal.ReleaseComObject(wb);
            Marshal.ReleaseComObject(app);

            MessageBox.Show(@"Done");
        }

        public void SearchInFile(string fileType, Excel.Worksheet ws, ref int row)
        {
            ws.Cells[row, 1] = fileType;
            //ws.Cells[row, 1].Interior.Color = Excel.XlRgbColor.rgbSkyBlue;
            row++;
            var allFiles = Directory.GetFiles(tbProjectFolder.Text, fileType, SearchOption.AllDirectories);

            foreach (var filepath in allFiles)
            {
                var lines = File.ReadAllLines(filepath, Encoding.UTF8);
                var rs = "0";
                for (var i = 0; i < lines.Length; i++)
                {
                    if (lines[i].IndexOf(tbTextSearch.Text, StringComparison.OrdinalIgnoreCase) < 0) continue;
                    if (rs.Equals("0"))
                    {
                        rs = i.ToString();
                    }
                    else
                    {
                        rs += ", " + i;
                    }
                }
                ws.Cells[row, 1] = filepath.Replace(tbProjectFolder.Text, "");
                ws.Cells[row, 2] = rs;
                row++;
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            var rs = "";
            rs += SearchInFile("*.html");
            rs += SearchInFile("*.aspx");
            rs += SearchInFile("*.ascx");
            File.WriteAllText(tbOutputFolder.Text + "\\output.csv", rs);
            MessageBox.Show(@"Done");
        }

        public string SearchInFile(string fileType)
        {
            var r = "";
            var allFiles = Directory.GetFiles(tbProjectFolder.Text, fileType, SearchOption.AllDirectories);

            foreach (var filepath in allFiles)
            {
                var lines = File.ReadAllLines(filepath, Encoding.UTF8);
                var rs = "0";
                for (var i = 0; i < lines.Length; i++)
                {
                    if (lines[i].IndexOf(tbTextSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        if (rs.Equals("0"))
                        {
                            rs = i.ToString();
                        }
                        else
                        {
                            rs += ", " + i;
                        }
                    }
                }
                r += filepath.Replace(tbProjectFolder.Text, "") + "," + rs + "\n";
            }
            return r;
        }
        #endregion
    }
}
