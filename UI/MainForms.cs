using System;
using System.Drawing;
using System.Windows.Forms;
using SCAN.Services;

namespace SCAN.UI
{
    public class MainForm : Form
    {
        // BUTTONS

        private Button btnPlay = null!;
        private Button btnApply = null!;
        private Button btnSetPath = null!;

        // SEARCH

        private TextBox txtSearch = null!;

        // GRID

        private DataGridView modsGrid = null!;

        // SIDEBAR

        private Panel sidebar = null!;

        private Label lblAbout = null!;
        private Label lblDetails = null!;

        // GAME PATH

        private Label lblPath = null!;

        // PROGRESS

        private ProgressBar progressBar = null!;

        // LOG

        private TextBox txtLog = null!;

        // LOGO

        private PictureBox logoBox = null!;

        public MainForm()
        {
            // START SERVICES

            PathService.Initialize();

            // UI

            InitializeUI();

            // LOAD DATA

            LoadGamePath();
        }

        private void InitializeUI()
        {
            // FORM

            Text = "SCAN 0.1.0";

            Size =
                new Size(1280, 720);

            MinimumSize =
                new Size(1100, 650);

            StartPosition =
                FormStartPosition.CenterScreen;

            BackColor =
                Color.FromArgb(10, 10, 10);

            ForeColor =
                Color.White;

            Font =
                new Font(
                    "Segoe UI",
                    10);

            DoubleBuffered = true;

            FormBorderStyle =
                FormBorderStyle.Sizable;

            MaximizeBox = true;

            // ICON

            try
            {
                Icon =
                    new Icon("SCAN.ico");
            }
            catch
            {

            }

            // LOGO

            logoBox =
                new PictureBox();

            logoBox.Location =
                new Point(20, 12);

            logoBox.Size =
                new Size(50, 50);

            logoBox.SizeMode =
                PictureBoxSizeMode.Zoom;

            try
            {
                logoBox.Image =
                    Image.FromFile("SCAN.ico");
            }
            catch
            {

            }

            Controls.Add(logoBox);

            // BUTTONS

            btnPlay =
                CreateButton(
                    "PLAY SFS",
                    90,
                    18,
                    Color.FromArgb(0, 120, 255));

            btnApply =
                CreateButton(
                    "APPLY",
                    230,
                    18,
                    Color.FromArgb(0, 180, 90));

            btnSetPath =
                CreateButton(
                    "SET PATH",
                    370,
                    18,
                    Color.FromArgb(45, 45, 45));

            // EVENTS

            btnSetPath.Click +=
                SetPath_Click;

            btnPlay.Click +=
                Play_Click;

            // ADD BUTTONS

            Controls.Add(btnPlay);

            Controls.Add(btnApply);

            Controls.Add(btnSetPath);

            // SEARCH CARD

            Panel searchCard =
                CreateCard(
                    720,
                    18,
                    520,
                    42);

            searchCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            searchCard.Padding =
                new Padding(10, 10, 10, 0);

            txtSearch =
                new TextBox();

            txtSearch.Dock =
                DockStyle.Fill;

            txtSearch.BorderStyle =
                BorderStyle.None;

            txtSearch.BackColor =
                Color.FromArgb(22, 22, 22);

            txtSearch.ForeColor =
                Color.Gray;

            txtSearch.Font =
                new Font(
                    "Segoe UI",
                    11);

            // PLACEHOLDER

            txtSearch.Text =
                "Search mods...";

            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text ==
                    "Search mods...")
                {
                    txtSearch.Text = "";

                    txtSearch.ForeColor =
                        Color.White;
                }
            };

            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(
                    txtSearch.Text))
                {
                    txtSearch.Text =
                        "Search mods...";

                    txtSearch.ForeColor =
                        Color.Gray;
                }
            };

            searchCard.Controls.Add(
                txtSearch);

            // MODS CARD

            Panel modsCard =
                CreateCard(
                    20,
                    80,
                    730,
                    560);

            modsCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left;

            // GRID

            modsGrid =
                new DataGridView();

            modsGrid.Dock =
                DockStyle.Fill;

            modsGrid.BackgroundColor =
                Color.FromArgb(18, 18, 18);

            modsGrid.BorderStyle =
                BorderStyle.None;

            modsGrid.GridColor =
                Color.FromArgb(35, 35, 35);

            modsGrid.RowHeadersVisible =
                false;

            modsGrid.EnableHeadersVisualStyles =
                false;

            modsGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            modsGrid.SelectionMode =
                DataGridViewSelectionMode.CellSelect;

            modsGrid.MultiSelect =
                false;

            modsGrid.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(20, 20, 20);

            modsGrid.DefaultCellStyle.SelectionForeColor =
                Color.White;

            modsGrid.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            modsGrid.ColumnHeadersHeight =
                38;

            modsGrid.RowTemplate.Height =
                32;

            modsGrid.DefaultCellStyle.BackColor =
                Color.FromArgb(20, 20, 20);

            modsGrid.DefaultCellStyle.ForeColor =
                Color.White;

            modsGrid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(28, 28, 28);

            modsGrid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            // INSTALL COLUMN

            DataGridViewCheckBoxColumn installColumn =
                new DataGridViewCheckBoxColumn();

            installColumn.Name =
                "Install";

            installColumn.HeaderText =
                "Inst.";

            // ADD COLUMNS

            modsGrid.Columns.Add(
                installColumn);

            modsGrid.Columns.Add(
                "ModName",
                "Mod Name");

            modsGrid.Columns.Add(
                "Status",
                "Status");

            // STATUS COLORS

            modsGrid.CellFormatting +=
                ModsGrid_CellFormatting;

            // TEST ROWS

            modsGrid.Rows.Add(
                false,
                "Example Mod",
                "Update");

            modsGrid.Rows.Add(
                true,
                "Expansion Pack",
                "Installed");

            modsGrid.Rows.Add(
                false,
                "Textures HD",
                "Available");

            modsCard.Controls.Add(
                modsGrid);

            // SIDEBAR

            sidebar =
                CreateCard(
                    780,
                    80,
                    460,
                    560);

            sidebar.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Right;

            // ABOUT

            lblAbout =
                new Label();

            lblAbout.Text =
                "ABOUT";

            lblAbout.Font =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);

            lblAbout.ForeColor =
                Color.White;

            lblAbout.Location =
                new Point(20, 20);

            lblAbout.AutoSize =
                true;

            // DIVIDER

            Panel divider =
                new Panel();

            divider.BackColor =
                Color.FromArgb(40, 40, 40);

            divider.Location =
                new Point(20, 60);

            divider.Size =
                new Size(400, 1);

            // DETAILS

            lblDetails =
                new Label();

            lblDetails.Text =
                "Name:\n\n" +
                "Author:\n\n" +
                "Version:\n\n" +
                "Description:\n\n" +
                "Size:";

            lblDetails.Location =
                new Point(20, 90);

            lblDetails.Size =
                new Size(400, 300);

            lblDetails.Font =
                new Font(
                    "Segoe UI",
                    11);

            lblDetails.ForeColor =
                Color.Gainsboro;

            sidebar.Controls.Add(
                lblAbout);

            sidebar.Controls.Add(
                divider);

            sidebar.Controls.Add(
                lblDetails);

            // GAME PATH

            lblPath =
                new Label();

            lblPath.Text =
                "Game Path: Not Set";

            lblPath.Location =
                new Point(20, 650);

            lblPath.Size =
                new Size(320, 25);

            lblPath.ForeColor =
                Color.Silver;

            lblPath.Anchor =
                AnchorStyles.Left |
                AnchorStyles.Bottom;

            // PROGRESS BAR

            progressBar =
                new ProgressBar();

            progressBar.Location =
                new Point(350, 652);

            progressBar.Size =
                new Size(400, 12);

            progressBar.Style =
                ProgressBarStyle.Continuous;

            progressBar.Anchor =
                AnchorStyles.Left |
                AnchorStyles.Bottom;

            // LOG

            txtLog =
                new TextBox();

            txtLog.Location =
                new Point(780, 650);

            txtLog.Size =
                new Size(460, 44);

            txtLog.Multiline =
                true;

            txtLog.ReadOnly =
                true;

            txtLog.BackColor =
                Color.FromArgb(5, 5, 5);

            txtLog.ForeColor =
                Color.Lime;

            txtLog.BorderStyle =
                BorderStyle.None;

            txtLog.Font =
                new Font(
                    "Consolas",
                    10);

            txtLog.Anchor =
                AnchorStyles.Right |
                AnchorStyles.Bottom;

            // ADD CONTROLS

            Controls.Add(lblPath);

            Controls.Add(progressBar);

            Controls.Add(txtLog);
        }

        // LOAD PATH

        private void LoadGamePath()
        {
            string path =
                PathService.LoadGamePath();

            if (!string.IsNullOrWhiteSpace(path))
            {
                lblPath.Text =
                    "Game Path: " + path;
            }
        }

        // SET PATH

        private void SetPath_Click(
            object? sender,
            EventArgs e)
        {
            using FolderBrowserDialog dialog =
                new FolderBrowserDialog();

            dialog.Description =
                "Select Spaceflight Simulator Folder";

            if (dialog.ShowDialog()
                == DialogResult.OK)
            {
                PathService.SaveGamePath(
                    dialog.SelectedPath);

                lblPath.Text =
                    "Game Path: " +
                    dialog.SelectedPath;

                txtLog.Text =
                    "[SCAN] Game path selected.";
            }
        }

        // PLAY GAME

        private void Play_Click(
            object? sender,
            EventArgs e)
        {
            string gamePath =
                PathService.LoadGamePath();

            bool launched =
                GameService.LaunchGame(
                    gamePath);

            if (launched)
            {
                txtLog.Text =
                    "[SCAN] Launching Spaceflight Simulator...";
            }
            else
            {
                MessageBox.Show(
                    "Spaceflight Simulator.exe not found.",
                    "SCAN",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtLog.Text =
                    "[SCAN] Failed to launch game.";
            }
        }

        // STATUS COLORS

        private void ModsGrid_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (modsGrid.Columns[e.ColumnIndex]?.Name
                == "Status")
            {
                string value =
                    e.Value?.ToString() ?? "";

                if (value == "Installed")
                {
                    e.CellStyle.ForeColor =
                        Color.LimeGreen;
                }

                else if (value == "Available")
                {
                    e.CellStyle.ForeColor =
                        Color.DeepSkyBlue;
                }

                else if (value == "Update")
                {
                    e.CellStyle.ForeColor =
                        Color.Orange;
                }
            }
        }

        // BUTTON CREATOR

        private Button CreateButton(
            string text,
            int x,
            int y,
            Color color)
        {
            Button btn =
                new Button();

            btn.Text = text;

            btn.Location =
                new Point(x, y);

            btn.Size =
                new Size(120, 40);

            btn.BackColor =
                color;

            btn.ForeColor =
                Color.White;

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize =
                0;

            btn.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            btn.Cursor =
                Cursors.Hand;

            // HOVER

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor =
                    Color.FromArgb(
                        Math.Min(color.R + 20, 255),
                        Math.Min(color.G + 20, 255),
                        Math.Min(color.B + 20, 255));
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor =
                    color;
            };

            return btn;
        }

        // CARD CREATOR

        private Panel CreateCard(
            int x,
            int y,
            int w,
            int h)
        {
            // SHADOW

            Panel shadow =
                new Panel();

            shadow.Location =
                new Point(x + 4, y + 4);

            shadow.Size =
                new Size(w, h);

            shadow.BackColor =
                Color.FromArgb(5, 5, 5);

            Controls.Add(shadow);

            // CARD

            Panel card =
                new Panel();

            card.Location =
                new Point(x, y);

            card.Size =
                new Size(w, h);

            card.BackColor =
                Color.FromArgb(20, 20, 20);

            card.BorderStyle =
                BorderStyle.FixedSingle;

            Controls.Add(card);

            card.BringToFront();

            return card;
        }
    }
}