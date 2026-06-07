// ═══════════════════════════════════════════════════════════════
//  UITheme.cs  —  CourierDB Centralized Style System
//  Drop this file into your CourierDB project (e.g. SoftwareClasses/)
//  Every form calls UITheme.Apply*() instead of hard-coding colors.
// ═══════════════════════════════════════════════════════════════
using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.SoftwareClasses
{
    public static class UITheme
    {
        // ── Palette (matches frmDashboard exactly) ─────────────────
        public static readonly Color BgDark       = Color.FromArgb(18, 18, 18);
        public static readonly Color BgSidebar    = Color.FromArgb(28, 28, 28);
        public static readonly Color BgCard       = Color.FromArgb(38, 38, 38);
        public static readonly Color BgHeader     = Color.FromArgb(24, 24, 24);
        public static readonly Color BgGrid       = Color.FromArgb(32, 32, 32);
        public static readonly Color BgGridAlt    = Color.FromArgb(36, 36, 36);
        public static readonly Color BgInput      = Color.FromArgb(30, 30, 30);
        public static readonly Color BgPanel      = Color.FromArgb(28, 28, 28);

        public static readonly Color Accent       = Color.FromArgb(230, 180, 80);   // gold
        public static readonly Color AccentBlue   = Color.FromArgb(100, 130, 220);
        public static readonly Color AccentGreen  = Color.FromArgb(90, 180, 130);
        public static readonly Color AccentRed    = Color.Tomato;

        public static readonly Color TextMain     = Color.FromArgb(240, 240, 240);
        public static readonly Color TextDim      = Color.FromArgb(160, 160, 160);
        public static readonly Color TextMuted    = Color.FromArgb(100, 100, 130);
        public static readonly Color BorderColor  = Color.FromArgb(60, 60, 60);

        // ── Typography ─────────────────────────────────────────────
        public static readonly Font FontBase      = new Font("Segoe UI", 9.5f);
        public static readonly Font FontBold      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font FontTitle     = new Font("Segoe UI", 16f, FontStyle.Bold);
        public static readonly Font FontSmall     = new Font("Segoe UI", 8.5f);
        public static readonly Font FontSmallBold = new Font("Segoe UI", 8.5f, FontStyle.Bold);

        // ══════════════════════════════════════════════════════════
        //  ApplyForm — call in every child form's constructor/Load
        // ══════════════════════════════════════════════════════════
        /// <summary>Applies base form chrome (dark bg, font, size).</summary>
        public static void ApplyForm(Form form, string title,
                                     int width = 1000, int height = 600)
        {
            form.BackColor       = BgDark;
            form.ForeColor       = TextMain;
            form.Font            = FontBase;
            form.Text            = title + " — CourierDB";
            form.ClientSize      = new Size(width, height);
            form.MinimumSize     = new Size(width, height);
            form.StartPosition   = FormStartPosition.CenterScreen;
        }

        // ══════════════════════════════════════════════════════════
        //  MakeHeaderPanel — top bar matching frmDashboard's pnlHeader
        // ══════════════════════════════════════════════════════════
        /// <summary>Creates a header Panel + title Label docked to top.</summary>
        public static Panel MakeHeaderPanel(string title, int formWidth,
                                             out Label titleLabel)
        {
            var pnl = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 55,
                BackColor = BgHeader
            };
            titleLabel = new Label
            {
                Text      = title,
                Font      = FontTitle,
                ForeColor = TextMain,
                Location  = new Point(20, 12),
                AutoSize  = true
            };
            pnl.Controls.Add(titleLabel);
            return pnl;
        }

        // ══════════════════════════════════════════════════════════
        //  MakeBottomBar — action bar matching frmDashboard card style
        // ══════════════════════════════════════════════════════════
        /// <summary>Creates a bottom action Panel (dark, 70px high).</summary>
        public static Panel MakeBottomBar()
        {
            return new Panel
            {
                Dock      = DockStyle.Bottom,
                Height    = 70,
                BackColor = BgPanel
            };
        }

        // ══════════════════════════════════════════════════════════
        //  MakeInputPanel — side/top input group matching dashboard card bg
        // ══════════════════════════════════════════════════════════
        /// <summary>Creates an input section Panel (card bg).</summary>
        public static Panel MakeInputPanel(int x, int y, int width, int height)
        {
            return new Panel
            {
                Location  = new Point(x, y),
                Size      = new Size(width, height),
                BackColor = BgCard
            };
        }

        // ══════════════════════════════════════════════════════════
        //  ApplyDataGridView — styles a DGV to match frmDashboard dgvRecent
        // ══════════════════════════════════════════════════════════
        public static void ApplyDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor      = BgGrid;
            dgv.ForeColor            = TextMain;
            dgv.GridColor            = BorderColor;
            dgv.BorderStyle          = BorderStyle.None;
            dgv.RowHeadersVisible    = false;
            dgv.AllowUserToAddRows   = false;
            dgv.ReadOnly             = true;
            dgv.SelectionMode        = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode  = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Font                 = FontBase;
            dgv.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowTemplate.Height   = 30;

            dgv.DefaultCellStyle.BackColor          = BgGrid;
            dgv.DefaultCellStyle.ForeColor          = TextMain;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Accent;
            dgv.ColumnHeadersDefaultCellStyle.Font      = FontBold;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = BgGridAlt;
        }

        // ══════════════════════════════════════════════════════════
        //  MakeLabel — standard label
        // ══════════════════════════════════════════════════════════
        public static Label MakeLabel(string text, int x, int y,
                                       int width = 100, bool bold = false)
        {
            return new Label
            {
                Text      = text,
                Location  = new Point(x, y),
                Size      = new Size(width, 24),
                ForeColor = TextMain,
                Font      = bold ? FontBold : FontBase,
                AutoSize  = false,
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        // ══════════════════════════════════════════════════════════
        //  MakeTextBox — styled dark input
        // ══════════════════════════════════════════════════════════
        public static TextBox MakeTextBox(int x, int y, int width = 200)
        {
            return new TextBox
            {
                Location  = new Point(x, y),
                Size      = new Size(width, 26),
                BackColor = BgInput,
                ForeColor = TextMain,
                Font      = FontBase,
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        // ══════════════════════════════════════════════════════════
        //  MakeComboBox — styled dark combo
        // ══════════════════════════════════════════════════════════
        public static ComboBox MakeComboBox(int x, int y, int width = 200)
        {
            return new ComboBox
            {
                Location      = new Point(x, y),
                Size          = new Size(width, 26),
                BackColor     = BgInput,
                ForeColor     = TextMain,
                Font          = FontBase,
                FlatStyle     = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
        }

        // ══════════════════════════════════════════════════════════
        //  MakeButton — primary / secondary / danger variants
        // ══════════════════════════════════════════════════════════
        public enum BtnStyle { Primary, Secondary, Danger, Success }

        public static Button MakeButton(string text, int x, int y,
                                 BtnStyle style = BtnStyle.Primary,
                                 int width = 130, int height = 36)
        {
            Color bg;
            if (style == BtnStyle.Primary) bg = AccentBlue;
            else if (style == BtnStyle.Secondary) bg = Color.FromArgb(50, 50, 50);
            else if (style == BtnStyle.Danger) bg = AccentRed;
            else if (style == BtnStyle.Success) bg = AccentGreen;
            else bg = AccentBlue;

            var btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = bg,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = FontBold,
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(bg, 0.15f);
            return btn;
        }
        //public static Button MakeButton(string text, int x, int y,
        //                                 BtnStyle style = BtnStyle.Primary,
        //                                 int width = 130, int height = 36)
        //{
        //    Color bg = style switch
        //    {
        //        BtnStyle.Primary   => AccentBlue,
        //        BtnStyle.Secondary => Color.FromArgb(50, 50, 50),
        //        BtnStyle.Danger    => AccentRed,
        //        BtnStyle.Success   => AccentGreen,
        //        _                  => AccentBlue
        //    };

        //    var btn = new Button
        //    {
        //        Text      = text,
        //        Location  = new Point(x, y),
        //        Size      = new Size(width, height),
        //        BackColor = bg,
        //        ForeColor = Color.White,
        //        FlatStyle = FlatStyle.Flat,
        //        Font      = FontBold,
        //        Cursor    = Cursors.Hand,
        //        UseVisualStyleBackColor = false
        //    };
        //    btn.FlatAppearance.BorderSize  = 0;
        //    btn.FlatAppearance.MouseOverBackColor =
        //        ControlPaint.Light(bg, 0.15f);
        //    return btn;
        //}

        // ══════════════════════════════════════════════════════════
        //  MakeDatePicker — styled DateTimePicker
        // ══════════════════════════════════════════════════════════
        public static DateTimePicker MakeDatePicker(int x, int y, int width = 200)
        {
            return new DateTimePicker
            {
                Location  = new Point(x, y),
                Size      = new Size(width, 26),
                CalendarForeColor  = TextMain,
                CalendarMonthBackground = BgCard,
                Font      = FontBase
            };
        }
    }
}
