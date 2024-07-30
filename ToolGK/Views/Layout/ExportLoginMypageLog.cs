using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ToolGK.Views.Layout
{
    public partial class ExportLoginMypageLog : UserControl
    {
        public ExportLoginMypageLog()
        {
            InitializeComponent();
        }

        private void BtnBrowseFolder_Click(object sender, EventArgs e)
        {
            var result2 = fbdFolderLogs.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                tbFolder.Text = fbdFolderLogs.SelectedPath;
            }
        }

        private void BtnBrowseSave_Click(object sender, EventArgs e)
        {
            var result1 = ofdPathSaveFile.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                tbPathSave.Text = ofdPathSaveFile.FileName;
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            //ExportLog();
            ConvertSql();
        }

        public void ExportLog()
        {
            var d = new DirectoryInfo(tbFolder.Text);
            var listFiles = d.GetFiles();
            var sb = new StringBuilder();
            var regex = new Regex(@"M[0-9]{6} - \/mypage.aspx");
            foreach (var file in listFiles)
            {
                var path = tbFolder.Text + "\\" + file.Name;
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var matches = regex.Match(line);
                    if (matches.Length <= 0) continue;
                    var datetime = line.Substring(0, 23);
                    var ip = line.Split(new[] { " - " }, StringSplitOptions.None)[1].Split(' ')[0];
                    var memberNo = matches.Value.Split(new[] { " - " }, StringSplitOptions.None)[0];
                    sb.AppendLine(datetime + " " + memberNo + " " + ip);
                }
            }
            File.WriteAllText(tbPathSave.Text, sb.ToString());
            MessageBox.Show(@"Done.");
        }

        public void ConvertSql()
        {
            var input = tbFolder.Text + "\\prefectures.sql";
            var output = tbFolder.Text + "\\prefectures_out.sql";
            var lines = File.ReadAllLines(input);
            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                if (line.StartsWith("INSERT"))
                {
                    sb.AppendLine(line.Replace("`id`, ", ""));
                }
                else
                {
                    var firstSpace = line.IndexOf(", '", StringComparison.Ordinal);
                    sb.AppendLine("(" + line.Substring(firstSpace + 2));
                }
            }
            File.WriteAllText(output, sb.ToString());
            MessageBox.Show(@"Done");
        }
    }
}
