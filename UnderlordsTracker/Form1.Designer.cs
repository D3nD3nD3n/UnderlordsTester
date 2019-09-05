namespace UnderlordsTester
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BotAlliancesRTB = new System.Windows.Forms.RichTextBox();
            this.buttonLoadAddresses = new System.Windows.Forms.Button();
            this.tlpPlayerUnits = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBotUnits = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPlayerItems = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBotItems = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.KillsNumeric = new System.Windows.Forms.NumericUpDown();
            this.KillsLabel = new System.Windows.Forms.Label();
            this.ItemComboBox = new System.Windows.Forms.ComboBox();
            this.ItemLabel = new System.Windows.Forms.Label();
            this.LevelComboBox = new System.Windows.Forms.ComboBox();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.HeroComboBox = new System.Windows.Forms.ComboBox();
            this.HeroLabel = new System.Windows.Forms.Label();
            this.PlayerAlliancesRTB = new System.Windows.Forms.RichTextBox();
            this.numericBotLife = new System.Windows.Forms.NumericUpDown();
            this.numericBotGold = new System.Windows.Forms.NumericUpDown();
            this.labelBotLife = new System.Windows.Forms.Label();
            this.labelBotGold = new System.Windows.Forms.Label();
            this.numericBotLevel = new System.Windows.Forms.NumericUpDown();
            this.labelBotLevel = new System.Windows.Forms.Label();
            this.labelPlayerLevel = new System.Windows.Forms.Label();
            this.numericPlayerLevel = new System.Windows.Forms.NumericUpDown();
            this.labelPlayerGold = new System.Windows.Forms.Label();
            this.labelPlayerLife = new System.Windows.Forms.Label();
            this.numericPlayerGold = new System.Windows.Forms.NumericUpDown();
            this.numericPlayerLife = new System.Windows.Forms.NumericUpDown();
            this.numericRound = new System.Windows.Forms.NumericUpDown();
            this.labelRound = new System.Windows.Forms.Label();
            this.buttonCreatePlayerHero = new System.Windows.Forms.Button();
            this.buttonCreateBotHero = new System.Windows.Forms.Button();
            this.buttonLock = new System.Windows.Forms.Button();
            this.labelLock = new System.Windows.Forms.Label();
            this.buttonKillBots = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KillsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRound)).BeginInit();
            this.SuspendLayout();
            // 
            // BotAlliancesRTB
            // 
            this.BotAlliancesRTB.Location = new System.Drawing.Point(520, 34);
            this.BotAlliancesRTB.Name = "BotAlliancesRTB";
            this.BotAlliancesRTB.ReadOnly = true;
            this.BotAlliancesRTB.Size = new System.Drawing.Size(150, 228);
            this.BotAlliancesRTB.TabIndex = 0;
            this.BotAlliancesRTB.Text = "";
            // 
            // buttonLoadAddresses
            // 
            this.buttonLoadAddresses.Location = new System.Drawing.Point(12, 9);
            this.buttonLoadAddresses.Name = "buttonLoadAddresses";
            this.buttonLoadAddresses.Size = new System.Drawing.Size(101, 23);
            this.buttonLoadAddresses.TabIndex = 1;
            this.buttonLoadAddresses.Text = "Load Server";
            this.buttonLoadAddresses.UseVisualStyleBackColor = true;
            this.buttonLoadAddresses.Click += new System.EventHandler(this.ButtonLoadAddress_Click);
            // 
            // tlpPlayerUnits
            // 
            this.tlpPlayerUnits.AllowDrop = true;
            this.tlpPlayerUnits.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlpPlayerUnits.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpPlayerUnits.ColumnCount = 8;
            this.tlpPlayerUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpPlayerUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpPlayerUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpPlayerUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpPlayerUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpPlayerUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpPlayerUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpPlayerUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpPlayerUnits.Location = new System.Drawing.Point(130, 269);
            this.tlpPlayerUnits.Name = "tlpPlayerUnits";
            this.tlpPlayerUnits.RowCount = 5;
            this.tlpPlayerUnits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPlayerUnits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPlayerUnits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPlayerUnits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPlayerUnits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPlayerUnits.Size = new System.Drawing.Size(299, 191);
            this.tlpPlayerUnits.TabIndex = 3;
            this.tlpPlayerUnits.Tag = "0";
            this.tlpPlayerUnits.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.TlpPlayer_CellPaint);
            this.tlpPlayerUnits.DragDrop += new System.Windows.Forms.DragEventHandler(this.TableLayoutPanel_DragDrop);
            this.tlpPlayerUnits.DragEnter += new System.Windows.Forms.DragEventHandler(this.TableLayoutPanel_DragEnter);
            this.tlpPlayerUnits.MouseEnter += new System.EventHandler(this.Tlp_MouseEnter);
            // 
            // tlpBotUnits
            // 
            this.tlpBotUnits.AllowDrop = true;
            this.tlpBotUnits.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlpBotUnits.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpBotUnits.ColumnCount = 8;
            this.tlpBotUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBotUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBotUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBotUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBotUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBotUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBotUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBotUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBotUnits.Location = new System.Drawing.Point(130, 72);
            this.tlpBotUnits.Name = "tlpBotUnits";
            this.tlpBotUnits.RowCount = 5;
            this.tlpBotUnits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBotUnits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBotUnits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBotUnits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBotUnits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBotUnits.Size = new System.Drawing.Size(299, 191);
            this.tlpBotUnits.TabIndex = 6;
            this.tlpBotUnits.Tag = "1";
            this.tlpBotUnits.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.TlpBotUnits_CellPaint);
            this.tlpBotUnits.DragDrop += new System.Windows.Forms.DragEventHandler(this.TableLayoutPanel_DragDrop);
            this.tlpBotUnits.DragEnter += new System.Windows.Forms.DragEventHandler(this.TableLayoutPanel_DragEnter);
            this.tlpBotUnits.MouseEnter += new System.EventHandler(this.Tlp_MouseEnter);
            // 
            // tlpPlayerItems
            // 
            this.tlpPlayerItems.AllowDrop = true;
            this.tlpPlayerItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlpPlayerItems.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpPlayerItems.ColumnCount = 2;
            this.tlpPlayerItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayerItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayerItems.Location = new System.Drawing.Point(435, 269);
            this.tlpPlayerItems.Name = "tlpPlayerItems";
            this.tlpPlayerItems.RowCount = 6;
            this.tlpPlayerItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpPlayerItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpPlayerItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpPlayerItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpPlayerItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpPlayerItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpPlayerItems.Size = new System.Drawing.Size(79, 229);
            this.tlpPlayerItems.TabIndex = 7;
            this.tlpPlayerItems.Tag = "2";
            this.tlpPlayerItems.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.TlpPlayerItems_CellPaint);
            this.tlpPlayerItems.DragDrop += new System.Windows.Forms.DragEventHandler(this.TableLayoutPanel_DragDrop);
            this.tlpPlayerItems.DragEnter += new System.Windows.Forms.DragEventHandler(this.TableLayoutPanel_DragEnter);
            this.tlpPlayerItems.MouseEnter += new System.EventHandler(this.Tlp_MouseEnter);
            // 
            // tlpBotItems
            // 
            this.tlpBotItems.AllowDrop = true;
            this.tlpBotItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlpBotItems.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpBotItems.ColumnCount = 2;
            this.tlpBotItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBotItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBotItems.Location = new System.Drawing.Point(435, 34);
            this.tlpBotItems.Name = "tlpBotItems";
            this.tlpBotItems.RowCount = 6;
            this.tlpBotItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpBotItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpBotItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpBotItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpBotItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpBotItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpBotItems.Size = new System.Drawing.Size(79, 229);
            this.tlpBotItems.TabIndex = 8;
            this.tlpBotItems.Tag = "3";
            this.tlpBotItems.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.TlpBotItems_CellPaint);
            this.tlpBotItems.DragDrop += new System.Windows.Forms.DragEventHandler(this.TableLayoutPanel_DragDrop);
            this.tlpBotItems.DragEnter += new System.Windows.Forms.DragEventHandler(this.TableLayoutPanel_DragEnter);
            this.tlpBotItems.MouseEnter += new System.EventHandler(this.Tlp_MouseEnter);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.KillsNumeric);
            this.panel1.Controls.Add(this.KillsLabel);
            this.panel1.Controls.Add(this.ItemComboBox);
            this.panel1.Controls.Add(this.ItemLabel);
            this.panel1.Controls.Add(this.LevelComboBox);
            this.panel1.Controls.Add(this.LevelLabel);
            this.panel1.Controls.Add(this.HeroComboBox);
            this.panel1.Controls.Add(this.HeroLabel);
            this.panel1.Location = new System.Drawing.Point(187, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 114);
            this.panel1.TabIndex = 10;
            // 
            // KillsNumeric
            // 
            this.KillsNumeric.Location = new System.Drawing.Point(44, 58);
            this.KillsNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.KillsNumeric.Name = "KillsNumeric";
            this.KillsNumeric.Size = new System.Drawing.Size(120, 20);
            this.KillsNumeric.TabIndex = 8;
            this.KillsNumeric.ValueChanged += new System.EventHandler(this.KillsNumeric_ValueChanged);
            // 
            // KillsLabel
            // 
            this.KillsLabel.AutoSize = true;
            this.KillsLabel.Location = new System.Drawing.Point(10, 60);
            this.KillsLabel.Name = "KillsLabel";
            this.KillsLabel.Size = new System.Drawing.Size(28, 13);
            this.KillsLabel.TabIndex = 7;
            this.KillsLabel.Text = "Kills:";
            // 
            // ItemComboBox
            // 
            this.ItemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemComboBox.FormattingEnabled = true;
            this.ItemComboBox.Location = new System.Drawing.Point(44, 90);
            this.ItemComboBox.Name = "ItemComboBox";
            this.ItemComboBox.Size = new System.Drawing.Size(192, 21);
            this.ItemComboBox.TabIndex = 5;
            this.ItemComboBox.SelectionChangeCommitted += new System.EventHandler(this.ItemComboBox_SelectionChangeCommitted);
            // 
            // ItemLabel
            // 
            this.ItemLabel.AutoSize = true;
            this.ItemLabel.Location = new System.Drawing.Point(8, 93);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(30, 13);
            this.ItemLabel.TabIndex = 4;
            this.ItemLabel.Text = "Item:";
            // 
            // LevelComboBox
            // 
            this.LevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LevelComboBox.FormattingEnabled = true;
            this.LevelComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.LevelComboBox.Location = new System.Drawing.Point(44, 30);
            this.LevelComboBox.Name = "LevelComboBox";
            this.LevelComboBox.Size = new System.Drawing.Size(35, 21);
            this.LevelComboBox.TabIndex = 3;
            this.LevelComboBox.SelectionChangeCommitted += new System.EventHandler(this.LevelComboBox_SelectionChangeCommitted);
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Location = new System.Drawing.Point(3, 33);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(36, 13);
            this.LevelLabel.TabIndex = 2;
            this.LevelLabel.Text = "Level:";
            // 
            // HeroComboBox
            // 
            this.HeroComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HeroComboBox.FormattingEnabled = true;
            this.HeroComboBox.Location = new System.Drawing.Point(44, 3);
            this.HeroComboBox.Name = "HeroComboBox";
            this.HeroComboBox.Size = new System.Drawing.Size(192, 21);
            this.HeroComboBox.TabIndex = 1;
            this.HeroComboBox.SelectionChangeCommitted += new System.EventHandler(this.HeroComboBox_SelectionChangeCommitted);
            // 
            // HeroLabel
            // 
            this.HeroLabel.AutoSize = true;
            this.HeroLabel.Location = new System.Drawing.Point(9, 6);
            this.HeroLabel.Name = "HeroLabel";
            this.HeroLabel.Size = new System.Drawing.Size(29, 13);
            this.HeroLabel.TabIndex = 0;
            this.HeroLabel.Text = "Unit:";
            // 
            // PlayerAlliancesRTB
            // 
            this.PlayerAlliancesRTB.Location = new System.Drawing.Point(520, 269);
            this.PlayerAlliancesRTB.Name = "PlayerAlliancesRTB";
            this.PlayerAlliancesRTB.ReadOnly = true;
            this.PlayerAlliancesRTB.Size = new System.Drawing.Size(150, 229);
            this.PlayerAlliancesRTB.TabIndex = 11;
            this.PlayerAlliancesRTB.Text = "";
            // 
            // numericBotLife
            // 
            this.numericBotLife.Location = new System.Drawing.Point(68, 72);
            this.numericBotLife.Name = "numericBotLife";
            this.numericBotLife.Size = new System.Drawing.Size(56, 20);
            this.numericBotLife.TabIndex = 12;
            this.numericBotLife.Tag = "1";
            this.numericBotLife.ValueChanged += new System.EventHandler(this.NumericPlayerLife_ValueChanged);
            // 
            // numericBotGold
            // 
            this.numericBotGold.Location = new System.Drawing.Point(68, 99);
            this.numericBotGold.Name = "numericBotGold";
            this.numericBotGold.Size = new System.Drawing.Size(56, 20);
            this.numericBotGold.TabIndex = 13;
            this.numericBotGold.Tag = "1";
            this.numericBotGold.ValueChanged += new System.EventHandler(this.NumericPlayerGold_ValueChanged);
            // 
            // labelBotLife
            // 
            this.labelBotLife.AutoSize = true;
            this.labelBotLife.Location = new System.Drawing.Point(35, 74);
            this.labelBotLife.Name = "labelBotLife";
            this.labelBotLife.Size = new System.Drawing.Size(27, 13);
            this.labelBotLife.TabIndex = 14;
            this.labelBotLife.Text = "Life:";
            // 
            // labelBotGold
            // 
            this.labelBotGold.AutoSize = true;
            this.labelBotGold.Location = new System.Drawing.Point(30, 101);
            this.labelBotGold.Name = "labelBotGold";
            this.labelBotGold.Size = new System.Drawing.Size(32, 13);
            this.labelBotGold.TabIndex = 15;
            this.labelBotGold.Text = "Gold:";
            // 
            // numericBotLevel
            // 
            this.numericBotLevel.Location = new System.Drawing.Point(68, 126);
            this.numericBotLevel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericBotLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericBotLevel.Name = "numericBotLevel";
            this.numericBotLevel.Size = new System.Drawing.Size(56, 20);
            this.numericBotLevel.TabIndex = 16;
            this.numericBotLevel.Tag = "1";
            this.numericBotLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericBotLevel.ValueChanged += new System.EventHandler(this.NumericPlayerLevel_ValueChanged);
            // 
            // labelBotLevel
            // 
            this.labelBotLevel.AutoSize = true;
            this.labelBotLevel.Location = new System.Drawing.Point(26, 128);
            this.labelBotLevel.Name = "labelBotLevel";
            this.labelBotLevel.Size = new System.Drawing.Size(36, 13);
            this.labelBotLevel.TabIndex = 17;
            this.labelBotLevel.Text = "Level:";
            // 
            // labelPlayerLevel
            // 
            this.labelPlayerLevel.AutoSize = true;
            this.labelPlayerLevel.Location = new System.Drawing.Point(26, 326);
            this.labelPlayerLevel.Name = "labelPlayerLevel";
            this.labelPlayerLevel.Size = new System.Drawing.Size(36, 13);
            this.labelPlayerLevel.TabIndex = 23;
            this.labelPlayerLevel.Text = "Level:";
            // 
            // numericPlayerLevel
            // 
            this.numericPlayerLevel.Location = new System.Drawing.Point(68, 324);
            this.numericPlayerLevel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericPlayerLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPlayerLevel.Name = "numericPlayerLevel";
            this.numericPlayerLevel.Size = new System.Drawing.Size(56, 20);
            this.numericPlayerLevel.TabIndex = 22;
            this.numericPlayerLevel.Tag = "0";
            this.numericPlayerLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPlayerLevel.ValueChanged += new System.EventHandler(this.NumericPlayerLevel_ValueChanged);
            // 
            // labelPlayerGold
            // 
            this.labelPlayerGold.AutoSize = true;
            this.labelPlayerGold.Location = new System.Drawing.Point(30, 299);
            this.labelPlayerGold.Name = "labelPlayerGold";
            this.labelPlayerGold.Size = new System.Drawing.Size(32, 13);
            this.labelPlayerGold.TabIndex = 21;
            this.labelPlayerGold.Text = "Gold:";
            // 
            // labelPlayerLife
            // 
            this.labelPlayerLife.AutoSize = true;
            this.labelPlayerLife.Location = new System.Drawing.Point(35, 272);
            this.labelPlayerLife.Name = "labelPlayerLife";
            this.labelPlayerLife.Size = new System.Drawing.Size(27, 13);
            this.labelPlayerLife.TabIndex = 20;
            this.labelPlayerLife.Text = "Life:";
            // 
            // numericPlayerGold
            // 
            this.numericPlayerGold.Location = new System.Drawing.Point(68, 297);
            this.numericPlayerGold.Name = "numericPlayerGold";
            this.numericPlayerGold.Size = new System.Drawing.Size(56, 20);
            this.numericPlayerGold.TabIndex = 19;
            this.numericPlayerGold.Tag = "0";
            this.numericPlayerGold.ValueChanged += new System.EventHandler(this.NumericPlayerGold_ValueChanged);
            // 
            // numericPlayerLife
            // 
            this.numericPlayerLife.Location = new System.Drawing.Point(68, 270);
            this.numericPlayerLife.Name = "numericPlayerLife";
            this.numericPlayerLife.Size = new System.Drawing.Size(56, 20);
            this.numericPlayerLife.TabIndex = 18;
            this.numericPlayerLife.Tag = "0";
            this.numericPlayerLife.ValueChanged += new System.EventHandler(this.NumericPlayerLife_ValueChanged);
            // 
            // numericRound
            // 
            this.numericRound.Location = new System.Drawing.Point(244, 12);
            this.numericRound.Name = "numericRound";
            this.numericRound.Size = new System.Drawing.Size(120, 20);
            this.numericRound.TabIndex = 25;
            this.numericRound.ValueChanged += new System.EventHandler(this.NumericRound_ValueChanged);
            // 
            // labelRound
            // 
            this.labelRound.AutoSize = true;
            this.labelRound.Location = new System.Drawing.Point(196, 14);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(42, 13);
            this.labelRound.TabIndex = 26;
            this.labelRound.Text = "Round:";
            // 
            // buttonCreatePlayerHero
            // 
            this.buttonCreatePlayerHero.Location = new System.Drawing.Point(49, 350);
            this.buttonCreatePlayerHero.Name = "buttonCreatePlayerHero";
            this.buttonCreatePlayerHero.Size = new System.Drawing.Size(75, 23);
            this.buttonCreatePlayerHero.TabIndex = 27;
            this.buttonCreatePlayerHero.Tag = "1";
            this.buttonCreatePlayerHero.Text = "Create Hero";
            this.buttonCreatePlayerHero.UseVisualStyleBackColor = true;
            this.buttonCreatePlayerHero.Click += new System.EventHandler(this.ButtonCreateHero_Click);
            // 
            // buttonCreateBotHero
            // 
            this.buttonCreateBotHero.Location = new System.Drawing.Point(49, 152);
            this.buttonCreateBotHero.Name = "buttonCreateBotHero";
            this.buttonCreateBotHero.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateBotHero.TabIndex = 28;
            this.buttonCreateBotHero.Tag = "2";
            this.buttonCreateBotHero.Text = "Create Hero";
            this.buttonCreateBotHero.UseVisualStyleBackColor = true;
            this.buttonCreateBotHero.Click += new System.EventHandler(this.ButtonCreateHero_Click);
            // 
            // buttonLock
            // 
            this.buttonLock.Location = new System.Drawing.Point(12, 474);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(75, 23);
            this.buttonLock.TabIndex = 29;
            this.buttonLock.Text = "Lock Board";
            this.buttonLock.UseVisualStyleBackColor = true;
            this.buttonLock.Click += new System.EventHandler(this.ButtonLock_Click);
            // 
            // labelLock
            // 
            this.labelLock.AutoSize = true;
            this.labelLock.Location = new System.Drawing.Point(87, 479);
            this.labelLock.Name = "labelLock";
            this.labelLock.Size = new System.Drawing.Size(53, 13);
            this.labelLock.TabIndex = 30;
            this.labelLock.Text = "Unlocked";
            // 
            // buttonKillBots
            // 
            this.buttonKillBots.Location = new System.Drawing.Point(12, 500);
            this.buttonKillBots.Name = "buttonKillBots";
            this.buttonKillBots.Size = new System.Drawing.Size(75, 23);
            this.buttonKillBots.TabIndex = 31;
            this.buttonKillBots.Text = "Kill Bots";
            this.buttonKillBots.UseVisualStyleBackColor = true;
            this.buttonKillBots.Click += new System.EventHandler(this.ButtonKillBots_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(12, 525);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 32;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 637);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonKillBots);
            this.Controls.Add(this.labelLock);
            this.Controls.Add(this.buttonLock);
            this.Controls.Add(this.buttonCreateBotHero);
            this.Controls.Add(this.buttonCreatePlayerHero);
            this.Controls.Add(this.labelRound);
            this.Controls.Add(this.numericRound);
            this.Controls.Add(this.labelPlayerLevel);
            this.Controls.Add(this.numericPlayerLevel);
            this.Controls.Add(this.labelPlayerGold);
            this.Controls.Add(this.labelPlayerLife);
            this.Controls.Add(this.numericPlayerGold);
            this.Controls.Add(this.numericPlayerLife);
            this.Controls.Add(this.labelBotLevel);
            this.Controls.Add(this.numericBotLevel);
            this.Controls.Add(this.labelBotGold);
            this.Controls.Add(this.labelBotLife);
            this.Controls.Add(this.numericBotGold);
            this.Controls.Add(this.numericBotLife);
            this.Controls.Add(this.PlayerAlliancesRTB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tlpBotItems);
            this.Controls.Add(this.tlpPlayerItems);
            this.Controls.Add(this.tlpBotUnits);
            this.Controls.Add(this.tlpPlayerUnits);
            this.Controls.Add(this.buttonLoadAddresses);
            this.Controls.Add(this.BotAlliancesRTB);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Underlords Tester";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KillsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox BotAlliancesRTB;
        private System.Windows.Forms.Button buttonLoadAddresses;
        private System.Windows.Forms.TableLayoutPanel tlpPlayerUnits;
        private System.Windows.Forms.TableLayoutPanel tlpBotUnits;
        private System.Windows.Forms.TableLayoutPanel tlpPlayerItems;
        private System.Windows.Forms.TableLayoutPanel tlpBotItems;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox HeroComboBox;
        private System.Windows.Forms.Label HeroLabel;
        private System.Windows.Forms.ComboBox LevelComboBox;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.ComboBox ItemComboBox;
        private System.Windows.Forms.Label ItemLabel;
        private System.Windows.Forms.RichTextBox PlayerAlliancesRTB;
        private System.Windows.Forms.Label KillsLabel;
        private System.Windows.Forms.NumericUpDown KillsNumeric;
        private System.Windows.Forms.NumericUpDown numericBotLife;
        private System.Windows.Forms.NumericUpDown numericBotGold;
        private System.Windows.Forms.Label labelBotLife;
        private System.Windows.Forms.Label labelBotGold;
        private System.Windows.Forms.NumericUpDown numericBotLevel;
        private System.Windows.Forms.Label labelBotLevel;
        private System.Windows.Forms.Label labelPlayerLevel;
        private System.Windows.Forms.NumericUpDown numericPlayerLevel;
        private System.Windows.Forms.Label labelPlayerGold;
        private System.Windows.Forms.Label labelPlayerLife;
        private System.Windows.Forms.NumericUpDown numericPlayerGold;
        private System.Windows.Forms.NumericUpDown numericPlayerLife;
        private System.Windows.Forms.NumericUpDown numericRound;
        private System.Windows.Forms.Label labelRound;
        private System.Windows.Forms.Button buttonCreatePlayerHero;
        private System.Windows.Forms.Button buttonCreateBotHero;
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.Label labelLock;
        private System.Windows.Forms.Button buttonKillBots;
        private System.Windows.Forms.Button buttonPause;
    }
}

