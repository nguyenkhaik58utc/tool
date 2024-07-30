using System;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;

namespace ToolGK.Views.Layout
{
    public partial class ImportCourse : UserControl
    {
        public ImportCourse()
        {
            InitializeComponent();
        }

        private void BtnOpenExcel_Click(object sender, EventArgs e)
        {
            var result = ofdExcel.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbPathExcel.Text = ofdExcel.FileName;
            }
        }

        private void BtnOpenSql_Click(object sender, EventArgs e)
        {
            var result = ofdSql.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbPathSql.Text = ofdSql.FileName;
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            var excel = tbPathExcel.Text;
            var sql = tbPathSql.Text;
            var maxLine = int.Parse(tbMaxLine.Text);

            var app = new Excel.Application();
            var xlWorkBook = app.Workbooks.Open(excel);
            var xlWorkSheet1 = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
            var misValue = System.Reflection.Missing.Value;
            var query = new StringBuilder("");
            //query.Append("CREATE TABLE course_import_temp (\n");
            //query.Append("course_no int NOT NULL PRIMARY KEY,\n");
            //query.Append("one_point nvarchar(4000) NULL,\n");
            //query.Append("campaign_event_info nvarchar(1000) NULL,\n");
            //query.Append("contact_confirmation nvarchar(1500) NULL\n");
            //query.Append(");\n");

            query.Append("DELETE FROM course_import_temp\n");

            query.Append("\n");
            query.Append("INSERT INTO course_import_temp (course_no, one_point, campaign_event_info, contact_confirmation) VALUES\n");
            const string template = "(N'#course_no', N'#one_point', N'#campaign_event_info', N'#contact_confirmation')";
            var error = new StringBuilder();

            for (var i = 2; i <= maxLine; i++)
            {
                var rangeOnePoint = xlWorkSheet1.Cells[i, 2] as Excel.Range;
                var rangeCampaignEventInfo = xlWorkSheet1.Cells[i, 3] as Excel.Range;
                var rangeContactConfirmation = xlWorkSheet1.Cells[i, 4] as Excel.Range;

                if (xlWorkSheet1.Cells[i, 1] is Excel.Range rangeCourseNo)
                {
                    var valCourseNo = rangeCourseNo.Value;
                    if (rangeOnePoint != null)
                    {
                        var valOnePoint = rangeOnePoint.Value;
                        if (rangeCampaignEventInfo != null)
                        {
                            var valCampaignEventInfo = rangeCampaignEventInfo.Value;
                            if (rangeContactConfirmation != null)
                            {
                                var valContactConfirmation = rangeContactConfirmation.Value;

                                string courseNo = PrepareData(Convert.ToString(valCourseNo));
                                string onePoint = PrepareData(Convert.ToString(valOnePoint));
                                string campaignEventInfo = PrepareData(Convert.ToString(valCampaignEventInfo));
                                string contactConfirmation = PrepareData(Convert.ToString(valContactConfirmation));
                                if (onePoint.Length > 4000)
                                {
                                    error.Append("Row " + i + " course_no = " + courseNo + " one_point.Length = " + onePoint.Length + "\n");
                                }
                                if (campaignEventInfo.Length > 1000)
                                {
                                    error.Append("Row " + i + " course_no = " + courseNo + " campaign_event_info.Length = " + campaignEventInfo.Length + "\n");
                                }
                                if (contactConfirmation.Length > 1500)
                                {
                                    error.Append("Row " + i + " course_no = " + courseNo + " contact_confirmation.Length = " + contactConfirmation.Length + "\n");
                                }

                                // string raw = course_no.Length + ";" + one_point.Length + ";" + campaign_event_info.Length + ";" + contact_confirmation.Length + ";" + template;
                                var raw = template;
                                raw = raw.Replace("#course_no", courseNo);
                                raw = raw.Replace("#one_point", onePoint);
                                raw = raw.Replace("#campaign_event_info", campaignEventInfo);
                                raw = raw.Replace("#contact_confirmation", contactConfirmation);
                                query.Append(raw);
                            }
                        }
                    }
                }

                if (i % 500 == 0)
                {
                    query.Append(";\n");
                    if (i != maxLine)
                    {
                        query.Append("INSERT INTO course_import_temp (course_no, one_point, campaign_event_info, contact_confirmation) VALUES\n");
                    }
                }
                else if (i != maxLine)
                {
                    query.Append(",\n");
                }
                else
                {
                    query.Append(";");
                }
            }
            File.WriteAllText(sql, error + @"\n" + query);

            xlWorkBook.Close(true, misValue, misValue);
            app.Quit();

            Marshal.ReleaseComObject(xlWorkSheet1);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(app);
            MessageBox.Show(@"Done");
        }

        public string PrepareData(string from)
        {
            var to = from ?? "";
            to = to.Replace("'", "%%danghao%%");
            to = to.Replace("%%danghao%%", "''");
            to = to.Replace("\r", "' + CHAR(13) + N'");
            to = to.Replace("\n", "' + CHAR(10) + N'");
            return to;
        }
    }
}
