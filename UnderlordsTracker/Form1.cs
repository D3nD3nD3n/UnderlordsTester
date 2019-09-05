using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UnderlordsTracker.Structs;

namespace UnderlordsTracker
{
    public partial class Form1 : Form
    {
        Addresses addresses;
        Addresses ad
        {
            get
            {
                return addresses;
            }
            set
            {
                addresses = value;
                if (addresses == null)
                {
                    buttonLoadAddresses.Enabled = true;
                    
                    buttonKillBots.Enabled = false;
                    buttonLock.Enabled = false;
                    buttonPause.Enabled = false;
                    buttonCreateBotHero.Enabled = false;
                    buttonCreatePlayerHero.Enabled = false;
                    numericBotGold.Enabled = false;
                    numericBotLevel.Enabled = false;
                    numericBotLife.Enabled = false;
                    numericPlayerGold.Enabled = false;
                    numericPlayerLevel.Enabled = false;
                    numericPlayerLife.Enabled = false;
                    numericRound.Enabled = false;
                    foreach (Control c in panel1.Controls)
                    {
                        if (c.GetType() != typeof(Label))
                        {
                            c.Enabled = false;
                        }
                    }
                }
                else
                {
                    buttonLoadAddresses.Enabled = false;

                    buttonKillBots.Enabled = true;
                    buttonLock.Enabled = true;
                    buttonPause.Enabled = true;
                    buttonCreateBotHero.Enabled = true;
                    buttonCreatePlayerHero.Enabled = true;
                    numericBotGold.Enabled = true;
                    numericBotLevel.Enabled = true;
                    numericBotLife.Enabled = true;
                    numericPlayerGold.Enabled = true;
                    numericPlayerLevel.Enabled = true;
                    numericPlayerLife.Enabled = true;
                    numericRound.Enabled = true;
                    foreach (Control c in panel1.Controls)
                    {
                        if (c.GetType() != typeof(Label))
                        {
                            c.Enabled = true;
                        }
                    }
                }

            }
        }
        NameTranslator nt;
        AllianceHandler ah;
        Point currentCell;
        bool newCell = false;
        private int currentBoard;
        int CurrentBoard
        {
            get
            {
                return currentBoard;
            }
            set
            {
                currentBoard = value;
                SetPanel();
            }
        }
        List<Hero>[,] heroLists = new List<Hero>[2, 2];
        List<Item>[,] itemLists = new List<Item>[2, 2];
        TableLayoutPanel[] tlpArray;
        NumericUpDown[] numLifeArray;
        NumericUpDown[] numLevelArray;
        NumericUpDown[] numGoldArray;
        Color[] levelColors = {Color.FromArgb(150, 150, 150),
                               Color.FromArgb(204, 181, 146),
                               Color.FromArgb(212, 232, 250),
                               Color.FromArgb(255, 251, 17)};

        Dictionary<int, int> HeroUIDtoHID = new Dictionary<int, int>(); //Holds which HID a given UID has
        Dictionary<int, int> ItemUIDtoIID = new Dictionary<int, int>(); //Holds which IID a given UID is set to


        public Form1()
        {
            
            InitializeComponent();

            nt = new NameTranslator();
            ah = new AllianceHandler(nt.GetDACtoULDict());
            ad = null;
            HeroComboBox.Items.AddRange(nt.GetHeroList());
            ItemComboBox.Items.AddRange(nt.GetItemList());
            ItemComboBox.Location = HeroComboBox.Location;
            ItemLabel.Location = HeroLabel.Location;
            CurrentBoard = -1;

            numLifeArray = new NumericUpDown[] { numericPlayerLife, numericBotLife };
            numLevelArray = new NumericUpDown[] { numericPlayerLevel, numericBotLevel };
            numGoldArray = new NumericUpDown[] { numericPlayerGold, numericBotGold };
            tlpArray = new TableLayoutPanel[] { tlpPlayerUnits, tlpBotUnits, tlpPlayerItems, tlpBotItems };
            for (int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    heroLists[i, j] = new List<Hero>();
                    itemLists[i, j] = new List<Item>();
                    for(int k = 0; k < 12; k++)
                    {
                        Item dummy;
                        dummy.player = i;
                        dummy.index = k;
                        dummy.IID = 10000;
                        dummy.UID = 0;
                        itemLists[i, j].Add(dummy);
                    }
                }
            }
            CreatePictureBoxes(tlpBotUnits);
            CreatePictureBoxes(tlpPlayerUnits);
            CreatePictureBoxes(tlpBotItems);
            CreatePictureBoxes(tlpPlayerItems);


        }

        private void CreatePictureBoxes(TableLayoutPanel tlp)
        {
            //int index = int.Parse(tlp.Tag.ToString());
            for (int i = 0; i < tlp.RowCount; i++)
            {
                for (int j = 0; j < tlp.ColumnCount; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.BackgroundImage = IconHelper.GetImageByID(0);
                    pb.BackColor = Color.Transparent;

                    pb.MouseDown += new MouseEventHandler(GridPB_MouseDown);
                    pb.Size = new Size(32, 32);
                    pb.Anchor = AnchorStyles.None;
                    pb.Visible = true;
                    tlp.Controls.Add(pb, j, i);
                    Console.WriteLine("PB added at {0}, {1}", j, i);
                }
            }
        }
        private void GridPB_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            
            if (pb.Tag != null)
            {
                pb.DoDragDrop((IDraggable)pb.Tag, DragDropEffects.Move);
            }
        }
        

        private void TableLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (ad != null)
            {
                TableLayoutPanel tlp = (TableLayoutPanel)sender;
                int tlpIndex = int.Parse(tlp.Tag.ToString());
                IDraggable d;
                if (e.Data.GetDataPresent(typeof(Hero)))
                {
                    d = ((IDraggable)e.Data.GetData(typeof(Hero)));
                }
                else
                {
                    d = ((IDraggable)e.Data.GetData(typeof(Item)));
                }
                if (d.GetPlayer() == tlpIndex % 2)//If in matching player table
                {
                    if (d.GetType() == typeof(Hero))
                    {
                        if (tlpIndex / 2 == 0)//If over hero table
                        {
                            e.Effect = DragDropEffects.Move;
                        }
                        else //If over  item table
                        {
                            e.Effect = DragDropEffects.None;
                        }
                    }
                    else //If holding an item
                    {
                        e.Effect = DragDropEffects.Move;
                    }

                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void TableLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            TableLayoutPanel tlp = (TableLayoutPanel)sender;
            Rectangle formSize = RectangleToScreen(this.ClientRectangle);
            Point p = new Point(e.X - this.Location.X - tlp.Location.X - (formSize.Left - this.Left), e.Y - this.Location.Y - tlp.Location.Y - (formSize.Top - this.Top));
            int cellWidth = tlp.Width / tlp.ColumnCount;
            int cellHeight = tlp.Height / tlp.RowCount;
            Point targetCell = new Point(p.X / cellWidth, p.Y / cellHeight);
            currentCell = targetCell;
            newCell = true;
            CurrentBoard = int.Parse(tlp.Tag.ToString());
            tlp.Invalidate();

            PictureBox pb = (PictureBox)tlp.GetControlFromPosition(targetCell.X, targetCell.Y);
            if (e.Data.GetDataPresent(typeof(Hero))) //if drag data is hero
            {
                Hero h = ((Hero)e.Data.GetData(typeof(Hero)));
                if(pb.Tag != null) //if target pb has a hero
                {
                    ad.SwapHeroes(h, (Hero)pb.Tag);
                }
                else //if target pb is empty
                {
                    ad.SetHeroPositionSmart(h.player, h.index, targetCell.X, targetCell.Y);
                }
            }
            

            else if (e.Data.GetDataPresent(typeof(Item)))
            {
                Item i = ((Item)e.Data.GetData(typeof(Item)));
                int tlpindex = int.Parse(tlp.Tag.ToString());
                if (tlpindex / 2 == 0) // if target tlp is a hero table
                {
                    if(pb.Tag != null)
                    {
                        for(int j = 0; j < itemLists[i.player,0].Count(); j++)
                        {
                            if (itemLists[i.player, 0][j].UID == ((Hero)pb.Tag).UID)
                            {
                                ad.SetItemHolder(i.player, j, 0);
                            }
                        }
                        
                        ad.SetItemHolder(i.player, i.index, ((Hero)pb.Tag).UID);
                        Console.WriteLine("nice");
                    }
                    else
                    {
                        ad.SetItemHolder(i.player, i.index, 0);
                    }
                }
            }
        }


        private void ButtonLoadAddress_Click(object sender, EventArgs e)
        {

            ad = new Addresses();
            if (ad.gameProcess == null)
            {
                ad = null;
                MessageBox.Show("Failed to find underlords");
                
            }
            else if (!ad.MatchingOpCodes())
            {
                ad = null;
                MessageBox.Show("Found unexpected memory. Aborting.");
            }

        }

        private void NewUpdate()
        {
            if (!ad.CheckGameStatus())
            {
                ah.ClearAlliances();
                ad = null;
            }
            else
            {
                int[] UnitCount = new int[2];
                UnitCount[0] = BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(ad.gameProcess, ad.GetUnitCountPtr(0), 4, out _), 0);
                UnitCount[1] = BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(ad.gameProcess, ad.GetUnitCountPtr(1), 4, out _), 0);

                for (int i = 0; i < 2; i++)
                {
                    #region hero update
                    for (int j = 0; j < UnitCount[i]; j++)
                    {
                        heroLists[i, 1].Add(ad.GetHero(i, j));
                    }
                    IEnumerable<Hero> removed = heroLists[i, 0].Except(heroLists[i, 1]);
                    IEnumerable<Hero> newHeroes = heroLists[i, 1].Except(heroLists[i, 0]);

                    foreach (Hero h in removed)
                    {
                        PictureBox pb = GetHeroPictureBox(i, h.xPos, h.yPos);
                        pb.Tag = null;
                        pb.BackgroundImage = null;
                        if (h.yPos != -1)
                            ah.RemoveAlliance(i, h.HID);
                        HeroUIDtoHID.Remove(h.UID);
                    }
                    foreach (Hero h in newHeroes)
                    {
                        PictureBox pb = GetHeroPictureBox(i, h.xPos, h.yPos);
                        pb.Tag = h;
                        if (ItemUIDtoIID.ContainsKey(h.UID)) //If an item has this hero's uid,
                        {
                            pb.BackgroundImage = IconHelper.CombineImagePair(IconHelper.GetImageByID(h.HID), IconHelper.GetMiniImageByID(ItemUIDtoIID[h.UID]));
                        }
                        else
                        {
                            pb.BackgroundImage = IconHelper.GetImageByID(h.HID);
                        }
                        if (h.yPos != -1)
                            ah.AddAlliance(i, h.HID);
                        HeroUIDtoHID.Add(h.UID, h.HID);
                    }
                    if (removed.Count() > 0 || newHeroes.Count() > 0)
                    {
                        tlpArray[i].Invalidate();
                        if (i == 0)
                            PlayerAlliancesRTB.Text = ah.GetAlliances(i);
                        else
                            BotAlliancesRTB.Text = ah.GetAlliances(i);
                    }


                    #endregion

                    #region items
                    for (int j = 0; j < 12; j++)
                    {
                        itemLists[i, 1].Add(ad.GetItem(i, j));
                        if (itemLists[i, 1][j].GetHashCode() != itemLists[i, 0][j].GetHashCode())
                        {
                            PictureBox pb = GetPBByUID(i, itemLists[i, 0][j].UID);
                            if (pb != null)
                                pb.BackgroundImage = IconHelper.GetImageByID(((Hero)pb.Tag).HID);
                            ItemUIDtoIID.Remove(itemLists[i, 0][j].UID);
                        }
                    }
                    for (int j = 0; j < 12; j++)
                    {
                        if (itemLists[i, 1][j].GetHashCode() != itemLists[i, 0][j].GetHashCode())
                        {
                            if (itemLists[i, 1][j].UID != 0)
                            {
                                ItemUIDtoIID.Add(itemLists[i, 1][j].UID, itemLists[i, 1][j].IID);
                            }
                            PictureBox pb = (PictureBox)tlpArray[2 + i].GetControlFromPosition(j / 6, j % 6);
                            pb.Tag = itemLists[i, 1][j];

                            if (HeroUIDtoHID.ContainsKey(itemLists[i, 1][j].UID))
                            {
                                //set item image pair
                                pb.BackgroundImage = IconHelper.CombineImagePair(IconHelper.GetImageByID(itemLists[i, 1][j].IID), IconHelper.GetMiniImageByID(HeroUIDtoHID[itemLists[i, 1][j].UID]));
                                //set hero image pair
                                pb = GetPBByUID(i, itemLists[i, 1][j].UID);
                                pb.BackgroundImage = IconHelper.CombineImagePair(IconHelper.GetImageByID(((Hero)pb.Tag).HID), IconHelper.GetMiniImageByID(ItemUIDtoIID[((Hero)pb.Tag).UID]));
                                //remove old hero image pair
                                pb = GetPBByUID(i, itemLists[i, 0][j].UID);
                                if (pb != null)
                                    pb.BackgroundImage = IconHelper.GetImageByID(((Hero)pb.Tag).HID);
                            }
                            else
                            {
                                pb.BackgroundImage = IconHelper.GetImageByID(itemLists[i, 1][j].IID);

                            }
                        }
                    }

                    #endregion

                    heroLists[i, 0] = new List<Hero>(heroLists[i, 1]);
                    heroLists[i, 1].Clear();
                    itemLists[i, 0] = new List<Item>(itemLists[i, 1]);
                    itemLists[i, 1].Clear();

                    UpdateControls(i);
                }
            }
        }

        private void UpdateControls(int currentPlayer)
        {
            if (newCell)
            {
                if (CurrentBoard == 0 || CurrentBoard == 1)
                {
                    PictureBox pb = (PictureBox)tlpArray[CurrentBoard].GetControlFromPosition(currentCell.X, currentCell.Y);
                    if (pb.Tag != null)
                    {
                        Hero h = (Hero)pb.Tag;
                        string name = nt.GetTranslatedName(h.HID);
                        HeroComboBox.SelectedItem = name.Remove(name.Length - 1);
                        LevelComboBox.SelectedIndex = h.level;
                        if (h.kills > KillsNumeric.Maximum)
                        {
                            KillsNumeric.Value = 1000;
                        }
                        else
                        {
                            KillsNumeric.Value = h.kills;
                        }
                    }
                    newCell = false;
                }
            }
            if (newCell)
            {
                if (CurrentBoard == 2 || CurrentBoard == 3)
                {
                    PictureBox pb = (PictureBox)tlpArray[CurrentBoard].GetControlFromPosition(currentCell.X, currentCell.Y);
                    if (pb.Tag != null)
                    {
                        Item item = (Item)pb.Tag;
                        string name = nt.GetTranslatedName(item.IID);
                        ItemComboBox.SelectedItem = name.Remove(name.Length - 1);
                    }
                }
                newCell = false;
            }
            int currentLife = ad.GetPlayerLife(currentPlayer);
            if (currentLife != (int)numLifeArray[currentPlayer].Value && !numLifeArray[currentPlayer].Focused)
            {
                numLifeArray[currentPlayer].Value = currentLife;
            }
            int currentGold = ad.GetPlayerGold(currentPlayer);
            if (currentGold != (int)numGoldArray[currentPlayer].Value && !numGoldArray[currentPlayer].Focused)
            {
                numGoldArray[currentPlayer].Value = currentGold;
            }
            int currentLevel = ad.GetPlayerLevel(currentPlayer);
            if (currentLevel != (int)numLevelArray[currentPlayer].Value && !numLevelArray[currentPlayer].Focused)
            {
                if(currentLevel >= numLevelArray[currentPlayer].Minimum && currentLevel <= numLevelArray[currentPlayer].Maximum)
                    numLevelArray[currentPlayer].Value = currentLevel;
            }
            if (ad.CurrentRound != (int)numericRound.Value && !numericRound.Focused)
            {
                if(ad.CurrentRound >= numericRound.Minimum && ad.CurrentRound <= numericRound.Maximum)
                    numericRound.Value = ad.CurrentRound;
            }
        }

        private PictureBox GetHeroPictureBox(int player, int xPos, int yPos)
        {
            PictureBox pb;
            if (player == 0)
            {
                pb = (PictureBox)tlpArray[player].GetControlFromPosition(xPos, 3 - yPos);
            }
            else
            {
                pb = (PictureBox)tlpArray[player].GetControlFromPosition(7 - xPos, yPos + 1);
            }
            return pb;
        }
        private PictureBox GetPBByUID(int player, int UID)
        {
            foreach (Hero h in heroLists[player,1])
            {
                if(h.UID == UID)
                {
                    return GetHeroPictureBox(player, h.xPos, h.yPos);
                }
            }
            return null;
        }


        private void TlpPlayer_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if(e.Row == 4)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), e.CellBounds.X, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width, e.CellBounds.Y);
            }
            TableLayoutPanel tlp = (TableLayoutPanel)sender;
            PictureBox pb = (PictureBox) tlp.GetControlFromPosition(e.Column, e.Row);
            if (pb.Tag != null)
            {
                e.Graphics.FillRectangle(new SolidBrush(levelColors[((Hero)pb.Tag).level]), e.CellBounds);
            }
            if (CurrentBoard == 0)
            {
                if (e.Column == currentCell.X && e.Row == currentCell.Y)
                {
                    Pen p = new Pen(Color.Red);
                    p.Width = 2;
                    e.Graphics.DrawRectangle(p, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2,  e.CellBounds.Width - 1));
                    for (int i = 0; i < tlpArray.Length; i++)
                    {
                        if (CurrentBoard != i)
                        {
                            tlpArray[i].Invalidate();
                        }
                    }
                }
            }
        }

        private void TlpBotUnits_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if(e.Row == 0)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), e.CellBounds.X, e.CellBounds.Height - 1 + e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width, e.CellBounds.Height - 1 + e.CellBounds.Y);
            }
            TableLayoutPanel tlp = (TableLayoutPanel)sender;
            PictureBox pb = (PictureBox)tlp.GetControlFromPosition(e.Column, e.Row);
            if (pb.Tag != null)
            {
                e.Graphics.FillRectangle(new SolidBrush(levelColors[((Hero)pb.Tag).level]), e.CellBounds);
            }
            if (CurrentBoard == 1)
            {
                if (e.Column == currentCell.X && e.Row == currentCell.Y)
                {
                    Pen p = new Pen(Color.Red);
                    p.Width = 2;
                    e.Graphics.DrawRectangle(p, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Width - 1));
                    for (int i = 0; i < tlpArray.Length; i++)
                    {
                        if (CurrentBoard != i)
                        {
                            tlpArray[i].Invalidate();
                        }
                    }
                }
            }

        }
        private void TlpPlayerItems_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (CurrentBoard == 2)
            {
                if (e.Column == currentCell.X && e.Row == currentCell.Y)
                {
                    Pen p = new Pen(Color.Red);
                    p.Width = 2;
                    e.Graphics.DrawRectangle(p, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Width - 1));
                    for(int i = 0; i < tlpArray.Length; i++)
                    {
                        if (CurrentBoard != i)
                        {
                            tlpArray[i].Invalidate();
                        }
                    }
                }
            }
        }

        private void TlpBotItems_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (CurrentBoard == 3)
            {
                if (e.Column == currentCell.X && e.Row == currentCell.Y)
                {
                    Pen p = new Pen(Color.Red);
                    p.Width = 2;
                    e.Graphics.DrawRectangle(p, new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Width - 1));
                    for (int i = 0; i < tlpArray.Length; i++)
                    {
                        if (CurrentBoard != i)
                        {
                            tlpArray[i].Invalidate();
                        }
                    }
                }
            }
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ad != null)
            {
                NewUpdate();
            }
        }

        private void Tlp_MouseEnter(object sender, EventArgs e)
        {
        }

        private void HeroComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CurrentBoard == 0 || CurrentBoard == 1)
            {
                PictureBox pb = (PictureBox)tlpArray[CurrentBoard].GetControlFromPosition(currentCell.X, currentCell.Y);
                if (pb.Tag != null)
                {
                    Hero h = (Hero)pb.Tag;
                    ComboBox cb = (ComboBox)sender;
                    if (!nt.GetTranslatedName(h.HID).Equals(cb.SelectedItem.ToString()))
                    {
                        int newHero = nt.GetID(cb.SelectedItem.ToString() + "h");
                        ad.SetHeroID(h.player, h.index, newHero);
                    }
                }
            }
        }

        private void LevelComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CurrentBoard == 0 || CurrentBoard == 1)
            {
                PictureBox pb = (PictureBox)tlpArray[CurrentBoard].GetControlFromPosition(currentCell.X, currentCell.Y);
                if (pb.Tag != null)
                {
                    Hero h = (Hero)pb.Tag;
                    ComboBox cb = (ComboBox)sender;
                    if (h.level != int.Parse(cb.SelectedItem.ToString()))
                    {
                        ad.SetHeroLevel(h.player, h.index, int.Parse(cb.SelectedItem.ToString()));
                    }
                }
            }
        }

        private void ItemComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CurrentBoard == 2 || CurrentBoard == 3)
            {
                PictureBox pb = (PictureBox)tlpArray[CurrentBoard].GetControlFromPosition(currentCell.X, currentCell.Y);
                if (pb.Tag != null)
                {
                    Item i = (Item)pb.Tag;
                    ComboBox cb = (ComboBox)sender;
                    if (!nt.GetTranslatedName(i.IID).Equals(cb.SelectedItem.ToString()))
                    {
                        int newItem = nt.GetID(cb.SelectedItem.ToString() + "i");
                        ad.SetItemID(i.player, i.index, newItem);
                    }
                }
            }
        }

        private void SetPanel()
        {
            if (currentBoard == 0 || currentBoard == 1)
            {
                HeroComboBox.Visible = true;
                LevelComboBox.Visible = true;
                HeroLabel.Visible = true;
                LevelLabel.Visible = true;
                KillsNumeric.Visible = true;
                KillsLabel.Visible = true;
                ItemComboBox.Visible = false;
                ItemLabel.Visible = false;
            }
            else if (currentBoard == 2 || currentBoard == 3)
            {
                HeroComboBox.Visible = false;
                LevelComboBox.Visible = false;
                HeroLabel.Visible = false;
                LevelLabel.Visible = false;
                KillsNumeric.Visible = false;
                KillsLabel.Visible = false;
                ItemComboBox.Visible = true;
                ItemLabel.Visible = true;
            }
            else
            {
                HeroComboBox.Visible = false;
                LevelComboBox.Visible = false;
                HeroLabel.Visible = false;
                LevelLabel.Visible = false;
                KillsNumeric.Visible = false;
                KillsLabel.Visible = false;
                ItemComboBox.Visible = false;
                ItemLabel.Visible = false;
            }
        }

        private void KillsNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentBoard == 0 || CurrentBoard == 1)
            {
                PictureBox pb = (PictureBox)tlpArray[CurrentBoard].GetControlFromPosition(currentCell.X, currentCell.Y);
                if (pb.Tag != null)
                {
                    Hero h = (Hero)pb.Tag;
                    NumericUpDown cb = (NumericUpDown)sender;
                    if (h.kills != cb.Value)
                    {
                        ad.SetHeroKills(h.player, h.index, (int)cb.Value);
                    }
                }
            }
        }

        private void NumericPlayerLevel_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            ad.SetPlayerLevel(int.Parse(num.Tag.ToString()), (int)num.Value);
        }

        private void NumericPlayerGold_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            ad.SetPlayerGold(int.Parse(num.Tag.ToString()), (int)num.Value);
        }

        private void NumericPlayerLife_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            ad.SetPlayerLife(int.Parse(num.Tag.ToString()), (int)num.Value);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void NumericRound_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            ad.CurrentRound = (int)num.Value;
        }

        private void ButtonCreatePlayerHero_Click(object sender, EventArgs e)
        {
            ad.CreateHero(1);
        }

        private void ButtonCreateBotHero_Click(object sender, EventArgs e)
        {
            ad.CreateHero(2);
        }

        private void ButtonCreateHero_Click(object sender, EventArgs e)
        {
            if(ad.HeroInjectionActive())
            {
                Button b = (Button)sender;
                ad.CreateHero(int.Parse(b.Tag.ToString()));
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Injection not found. Attempt Injection?", "", MessageBoxButtons.YesNo);
                if(confirm == DialogResult.Yes)
                {
                    ad.CreateHeroInjection();
                    if(ad.HeroInjectionActive())
                    {
                        MessageBox.Show("Injection Successful.");
                    }
                    else
                    {
                        MessageBox.Show("Injection Failed.");
                    }
                }
            }
        }

        private void ButtonLock_Click(object sender, EventArgs e)
        {
            if(ad.LockedBoard == 1)
            {
                ad.LockedBoard = 0;
            }
            else
            {
                ad.LockedBoard = 1;
            }
            UpdateLockLabel();
        }
        private void UpdateLockLabel()
        {
            if (ad.LockedBoard == 0)
            {
                labelLock.Text = "Unlocked";
            }
            else if (ad.LockedBoard == 1)
            {
                labelLock.Text = "Locked";
            }
            else
            {
                labelLock.Text = "Mixed Lock";
            }
        }

        private void ButtonKillBots_Click(object sender, EventArgs e)
        {
            for (int i = 2; i < 8; i++)
            {
                ad.SetPlayerLife(i, 0);
            }
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(ad.GamePaused)
            {
                ad.GamePaused = false;
                b.Text = "Pause";
            }
            else
            {
                ad.GamePaused = true;
                b.Text = "Unpause";
            }
        }


    }
}
