using System;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace ToolGK.Views.Layout
{
    public partial class ExportDatabase : UserControl
    {
        public ExportDatabase()
        {
            InitializeComponent();
        }

        private void BtnTXT_Click(object sender, EventArgs e)
        {
            var rs = ofdTXT.ShowDialog();
            if (rs == DialogResult.OK)
            {
                tbTXT.Text = ofdTXT.FileName;
            }
        }

        private void BtnXLS_Click(object sender, EventArgs e)
        {
            var rs = ofdXLS.ShowDialog();
            if (rs == DialogResult.OK)
            {
                tbXLS.Text = ofdXLS.FileName;
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines(tbTXT.Text);
            var app = new Excel.Application {DisplayAlerts = false};
            var wb = app.Workbooks.Open(tbXLS.Text);
            wb.Sheets.Add(After: wb.Sheets[wb.Sheets.Count]);
            var ws = (Excel.Worksheet)wb.Worksheets.Item[3];

            ws.Cells[1, 1] = "ORDINAL_POSITION";
            ws.Cells[1, 2] = "COLUMN_NAME";
            ws.Cells[1, 3] = "DATA_TYPE";
            ws.Cells[1, 4] = "CHARACTER_MAXIMUM_LENGTH";
            ws.Cells[1, 5] = "IS_NULLABLE";
            ws.Cells[1, 6] = "Details";

            for (var i = 0; i < lines.Length; i++)
            {
                var cells = lines[i].Split('\t');
                for (var j = 0; j < cells.Length; j++)
                {
                    ws.Cells[i + 2, j + 1] = cells[j];
                }
            }

            wb.SaveAs(tbXLS.Text);
            wb.Close(true, Type.Missing, Type.Missing);
            app.Quit();

            Marshal.ReleaseComObject(ws);
            Marshal.ReleaseComObject(wb);
            Marshal.ReleaseComObject(app);
            MessageBox.Show(@"Done");
        }
    }
}
