using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SSB64_String_Editor
{
    public partial class MainForm : Form
    {
        private string _configDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs");

        public MainForm() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e) { }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = openFileDialog1.ShowDialog();

            if (dr != DialogResult.OK)
                return;

            var binaryFilePath = openFileDialog1.FileName;

            Clear();

            foreach (var configFilePath in Directory.GetFiles(_configDirectory, "*.json"))
                LoadConfigFile(configFilePath, binaryFilePath);
        }

        private void Clear()
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                var dataGridView = (DataGridView)tabPage.Controls.Find("DataGridView", false).FirstOrDefault();
                dataGridView.CellValueChanged -= dataGrid_CellValueChanged;
                dataGridView.CellValidating -= dataGrid_CellValidating;
                tabPage.Controls.Clear();
            }

            tabControl1.TabPages.Clear();
        }

        private void LoadConfigFile(string configFilePath, string binaryFilePath)
        {
            var configFileManager = new ConfigFileManager(configFilePath, binaryFilePath);
            configFileManager.LoadConfig();

            var strings = configFileManager.ReadStringsFromBinary();

            var datagrid = new DataGridView()
            {
                Dock = DockStyle.Fill,
                DataSource = strings,
                Tag = configFileManager,
                Name = "DataGridView"
            };

            datagrid.CellValueChanged += dataGrid_CellValueChanged;
            datagrid.CellValidating += dataGrid_CellValidating;

            var tabPage = new TabPage() { Text = Path.GetFileNameWithoutExtension(configFilePath) };
            tabPage.Controls.Add(datagrid);
            tabControl1.TabPages.Add(tabPage);

            SetupColumns(datagrid, strings);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                var dataGridView = (DataGridView)tabPage.Controls.Find("DataGridView", false).First();
                var configFileManager = (ConfigFileManager)dataGridView.Tag;
                var outputPath = configFileManager.CreateBackupBinaryFile();
                configFileManager.WriteStringsToBinary(outputPath);
            }

            MessageBox.Show("Done");
        }

        private void SetupColumns(DataGridView dataGridView, List<SSB64String> strings)
        {
            dataGridView.Refresh();
            dataGridView.Columns["Offset"].ReadOnly = true;
            dataGridView.Columns["SmallText"].Width = 200;
            dataGridView.Columns["LargeText"].Width = 200;
            
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var offsetIndex = dataGridView.Columns["Offset"].Index;
                var offset = dataGridView[offsetIndex, row.Index].Value.ToString();
                row.Tag = strings.Single(x => x.Offset == offset);
            }

            dataGridView.Refresh();
        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e) =>
            UpdateDataGridTextToMatch((DataGridView)sender, e);

        private void dataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) =>
            ValidateTextIsAllowed((DataGridView)sender, e);

        private void ValidateTextIsAllowed(DataGridView dataGridView, DataGridViewCellValidatingEventArgs e)
        {
            var smallColumnIndex = dataGridView.Columns["SmallText"].Index;
            var largeColumnIndex = dataGridView.Columns["LargeText"].Index;

            var validationError = string.Empty;

            if (e.ColumnIndex == smallColumnIndex)
            {
                foreach (var c in e.FormattedValue.ToString())
                {
                    var matchedValue = CharSet.SSB64CharSet.SingleOrDefault(x => c.ToString() == x.CharacterSmall);

                    if (matchedValue == null)
                    {
                        validationError = $"\"{e.FormattedValue.ToString()}\" contains an invalid character \"{c}\" for the text size";
                        break;
                    }
                }
            }
            else if (e.ColumnIndex == largeColumnIndex)
            {
                foreach (var c in e.FormattedValue.ToString())
                {
                    var matchedValue = CharSet.SSB64CharSet.SingleOrDefault(x => c.ToString() == x.CharacterLarge);

                    if (matchedValue == null)
                    {
                        validationError = $"\"{e.FormattedValue.ToString()}\" contains an invalid character \"{c}\" for the text size";
                        break;
                    }
                }
            }

            var textLength = e.FormattedValue.ToString().Length;
            var maxLength = ((SSB64String)dataGridView.Rows[e.RowIndex]?.Tag)?.Length;

            if (textLength > maxLength)
                validationError = $"\"{e.FormattedValue.ToString()}\" ({textLength}) is larger than the original text size of {maxLength}";

            if (!string.IsNullOrEmpty(validationError))
            {
                MessageBox.Show(validationError);
                e.Cancel = true;
                dataGridView.EndEdit();
            }
        }

        private void UpdateDataGridTextToMatch(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            var smallColumnIndex = dataGridView.Columns["SmallText"].Index;
            var largeColumnIndex = dataGridView.Columns["LargeText"].Index;

            if (e.ColumnIndex == smallColumnIndex)
            {
                var newSmallText = dataGridView[smallColumnIndex, e.RowIndex].Value.ToString();
                var newLargeText = newSmallText.ToSSB64String(TextSize.Large);

                if (dataGridView[largeColumnIndex, e.RowIndex].Value.ToString() != newLargeText)
                    dataGridView[largeColumnIndex, e.RowIndex].Value = newLargeText;
            }
            else if (e.ColumnIndex == dataGridView.Columns["LargeText"].Index)
            {
                var newLargeText = dataGridView[largeColumnIndex, e.RowIndex].Value.ToString();
                var newSmallText = newLargeText.ToSSB64String(TextSize.Small);

                if (dataGridView[smallColumnIndex, e.RowIndex].Value.ToString() != newSmallText)
                    dataGridView[smallColumnIndex, e.RowIndex].Value = newSmallText;
            }
        }
    }
}
