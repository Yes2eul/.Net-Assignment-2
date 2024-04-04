using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace _13978248_Assignment_2
{
    public partial class TextEditor : Form
    {
        LoginScreen loginScreen;
        string name, userType, currentFile;

        public TextEditor(LoginScreen loginScreen, string name, string userType)
        {
            InitializeComponent();
            this.loginScreen = loginScreen;
            this.name = name;
            this.userType = userType;
        }

        private void TextEditor_Load(object sender, EventArgs e)
        {
            un_toolStripLabel.Text = $"User Name: {name}";
            if (userType == "View")
            {
                newCtrlNToolStripMenuItem.Enabled = false;
                saveCtrlSToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                richTextBox.Enabled = false;
                top_toolStrip.Enabled = false;
                left_toolStrip.Enabled = false;
            }
        }

        private void newCtrlNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges() != DialogResult.Cancel)
            {
                currentFile = string.Empty;
                Text = "Text Editor";
                richTextBox.Text = string.Empty;
            }
        }

        private void openCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open";
            dialog.Filter = "Rich Text Format files (*.rtf)|*.rtf|" +
                "Plain Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = dialog.FileName;
                Text = currentFile;
                LoadFile();
            }
        }

        private void saveCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFile))
                SaveFile();
            else
                saveAsToolStripMenuItem_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save As";
            dialog.Filter = "Rich Text Format file (*.rtf)|*.rtf|" +
                "Plain Text file (*.txt)|*.txt|All file (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = dialog.FileName;
                Text = currentFile;
                SaveFile();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges() != DialogResult.Cancel)
            {
                Close();
                loginScreen.Show();
            }
        }

        private void SaveFile()
        {
            string fileExtension = Path.GetExtension(currentFile);
            if (fileExtension == ".rtf")
                File.WriteAllText(currentFile, richTextBox.Rtf);
            else if (fileExtension == ".txt")
                File.WriteAllText(currentFile, richTextBox.Text);
        }

        private void LoadFile()
        {
            string fileExtension = Path.GetExtension(currentFile);
            if (fileExtension == ".rtf")
                richTextBox.LoadFile(currentFile, RichTextBoxStreamType.RichText);
            else if (fileExtension == ".txt")
                richTextBox.LoadFile(currentFile, RichTextBoxStreamType.PlainText);
        }

        private DialogResult UnsavedChanges()
        {
            DialogResult result = DialogResult.None;

            if (!string.IsNullOrEmpty(currentFile) &&
                File.ReadAllText(currentFile) != richTextBox.Rtf &&
                File.ReadAllText(currentFile) != richTextBox.Text &&
                (result = MessageBox.Show($"Do you want to change saves to\n{currentFile}?", "Save File",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)) == DialogResult.Yes)
            {
                SaveFile();
            }

            return result;
        }

        private void cut_toolStripButton_Click(object sender, EventArgs e)
        {
            cutCtrlXToolStripMenuItem_Click(sender, e);
        }

        private void copy_toolStripButton_Click(object sender, EventArgs e)
        {
            copyCtrlCToolStripMenuItem_Click(sender, e);
        }

        private void paste_toolStripButton_Click(object sender, EventArgs e)
        {
            pasteCtrlVToolStripMenuItem_Click(sender, e);
        }

        private void new_toolStripButton_Click(object sender, EventArgs e)
        {
            newCtrlNToolStripMenuItem_Click(sender, e);
        }

        private void open_toolStripButton_Click(object sender, EventArgs e)
        {
            openCtrlOToolStripMenuItem_Click(sender, e);
        }

        private void save_toolStripButton_Click(object sender, EventArgs e)
        {
            saveCtrlSToolStripMenuItem_Click(sender, e);
        }

        private void saveas_toolStripButton_Click(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem_Click(sender, e);
        }

        private void cutCtrlXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0)
                richTextBox.Cut();
        }

        private void copyCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0)
                richTextBox.Copy();
        }

        private void pasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Text Editor v1.0.0\nCreator: Yeseul Shin", "About",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void b_toolStripButton_Click(object sender, EventArgs e)
        {
            if (b_toolStripButton.Checked == false)
            {
                b_toolStripButton.Checked = true; // BOLD is true
            }
            else if (b_toolStripButton.Checked == true)
            {
                b_toolStripButton.Checked = false;    // BOLD is false
            }

            if (richTextBox.SelectionFont == null)
            {
                return;
            }

            // create fontStyle object
            FontStyle style = richTextBox.SelectionFont.Style;

            // determines the font style
            if (richTextBox.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
            }
            else
            {
                style |= FontStyle.Bold;

            }
            richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, style);     // sets the font style
        }

        private void i_toolStripButton_Click(object sender, EventArgs e)
        {
            if (i_toolStripButton.Checked == false)
            {
                i_toolStripButton.Checked = true;    // ITALICS is active
            }
            else if (i_toolStripButton.Checked == true)
            {
                i_toolStripButton.Checked = false;    // ITALICS is not active
            }

            if (richTextBox.SelectionFont == null)
            {
                return;
            }
            // create fontStyle object
            FontStyle style = richTextBox.SelectionFont.Style;

            // determines font style
            if (richTextBox.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
            }
            else
            {
                style |= FontStyle.Italic;
            }
            richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, style);    // sets the font style
        }

        private void u_toolStripButton_Click(object sender, EventArgs e)
        {
            if (u_toolStripButton.Checked == false)
            {
                u_toolStripButton.Checked = true;     // UNDERLINE is active
            }
            else if (u_toolStripButton.Checked == true)
            {
                u_toolStripButton.Checked = false;    // UNDERLINE is not active
            }

            if (richTextBox.SelectionFont == null)
            {
                return;
            }

            // create fontStyle object
            FontStyle style = richTextBox.SelectionFont.Style;

            // determines the font style
            if (richTextBox.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
            }
            else
            {
                style |= FontStyle.Underline;
            }
            richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, style);    // sets the font style
        }

        private void richTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateFontStyleButtonState();
        }

        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateFontStyleButtonState();
        }

        private void font_toolStripComboBox_Click(object sender, EventArgs e)
        {
            font_toolStripComboBox.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
        }

        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (font_toolStripComboBox.SelectedIndex)
            {
                case 0:
                    richTextBox.SelectionFont = new Font("Consolas", 8);
                    break;
                case 1:
                    richTextBox.SelectionFont = new Font("Consolas", 10);
                    break;
                case 2:
                    richTextBox.SelectionFont = new Font("Consolas", 12);
                    break;
                case 3:
                    richTextBox.SelectionFont = new Font("Consolas", 14);
                    break;
                case 4:
                    richTextBox.SelectionFont = new Font("Consolas", 16);
                    break;
                case 5:
                    richTextBox.SelectionFont = new Font("Consolas", 18);
                    break;
                case 6:
                    richTextBox.SelectionFont = new Font("Consolas", 20);
                    break;
            }
        }

        private void help_toolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a help message.", "Help",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateFontStyleButtonState()
        {
            Font currentFont = richTextBox.SelectionFont;
            if (currentFont != null)
            {
                b_toolStripButton.Checked = currentFont.Bold;
                i_toolStripButton.Checked = currentFont.Italic;
                u_toolStripButton.Checked = currentFont.Underline;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditor));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCtrlNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCtrlOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveCtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutCtrlXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCtrlCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteCtrlVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.top_toolStrip = new System.Windows.Forms.ToolStrip();
            this.new_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.open_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.save_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveas_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.b_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.i_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.u_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.font_toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.help_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.un_toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.left_toolStrip = new System.Windows.Forms.ToolStrip();
            this.cut_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copy_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.paste_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip.SuspendLayout();
            this.top_toolStrip.SuspendLayout();
            this.left_toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1254, 40);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCtrlNToolStripMenuItem,
            this.openCtrlOToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveCtrlSToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.logoutToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newCtrlNToolStripMenuItem
            // 
            this.newCtrlNToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newCtrlNToolStripMenuItem.Image")));
            this.newCtrlNToolStripMenuItem.MergeIndex = 0;
            this.newCtrlNToolStripMenuItem.Name = "newCtrlNToolStripMenuItem";
            this.newCtrlNToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.newCtrlNToolStripMenuItem.Text = "New          Ctrl+N";
            this.newCtrlNToolStripMenuItem.Click += new System.EventHandler(this.newCtrlNToolStripMenuItem_Click);
            // 
            // openCtrlOToolStripMenuItem
            // 
            this.openCtrlOToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openCtrlOToolStripMenuItem.Image")));
            this.openCtrlOToolStripMenuItem.Name = "openCtrlOToolStripMenuItem";
            this.openCtrlOToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.openCtrlOToolStripMenuItem.Text = "Open         Ctrl+O";
            this.openCtrlOToolStripMenuItem.Click += new System.EventHandler(this.openCtrlOToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(356, 6);
            // 
            // saveCtrlSToolStripMenuItem
            // 
            this.saveCtrlSToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveCtrlSToolStripMenuItem.Image")));
            this.saveCtrlSToolStripMenuItem.Name = "saveCtrlSToolStripMenuItem";
            this.saveCtrlSToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.saveCtrlSToolStripMenuItem.Text = "Save           Ctrl+S";
            this.saveCtrlSToolStripMenuItem.Click += new System.EventHandler(this.saveCtrlSToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(356, 6);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logoutToolStripMenuItem.Image")));
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutCtrlXToolStripMenuItem,
            this.copyCtrlCToolStripMenuItem,
            this.pasteCtrlVToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(74, 36);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutCtrlXToolStripMenuItem
            // 
            this.cutCtrlXToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutCtrlXToolStripMenuItem.Image")));
            this.cutCtrlXToolStripMenuItem.Name = "cutCtrlXToolStripMenuItem";
            this.cutCtrlXToolStripMenuItem.Size = new System.Drawing.Size(337, 44);
            this.cutCtrlXToolStripMenuItem.Text = "Cut          Ctrl+X";
            this.cutCtrlXToolStripMenuItem.Click += new System.EventHandler(this.cutCtrlXToolStripMenuItem_Click);
            // 
            // copyCtrlCToolStripMenuItem
            // 
            this.copyCtrlCToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyCtrlCToolStripMenuItem.Image")));
            this.copyCtrlCToolStripMenuItem.Name = "copyCtrlCToolStripMenuItem";
            this.copyCtrlCToolStripMenuItem.Size = new System.Drawing.Size(337, 44);
            this.copyCtrlCToolStripMenuItem.Text = "Copy        Ctrl+C";
            this.copyCtrlCToolStripMenuItem.Click += new System.EventHandler(this.copyCtrlCToolStripMenuItem_Click);
            // 
            // pasteCtrlVToolStripMenuItem
            // 
            this.pasteCtrlVToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteCtrlVToolStripMenuItem.Image")));
            this.pasteCtrlVToolStripMenuItem.Name = "pasteCtrlVToolStripMenuItem";
            this.pasteCtrlVToolStripMenuItem.Size = new System.Drawing.Size(337, 44);
            this.pasteCtrlVToolStripMenuItem.Text = "Paste        Ctrl+V";
            this.pasteCtrlVToolStripMenuItem.Click += new System.EventHandler(this.pasteCtrlVToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(84, 36);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(228, 44);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // top_toolStrip
            // 
            this.top_toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.top_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new_toolStripButton,
            this.open_toolStripButton,
            this.save_toolStripButton,
            this.saveas_toolStripButton,
            this.toolStripSeparator1,
            this.b_toolStripButton,
            this.i_toolStripButton,
            this.u_toolStripButton,
            this.font_toolStripComboBox,
            this.toolStripSeparator4,
            this.help_toolStripButton,
            this.un_toolStripLabel});
            this.top_toolStrip.Location = new System.Drawing.Point(0, 40);
            this.top_toolStrip.Name = "top_toolStrip";
            this.top_toolStrip.Size = new System.Drawing.Size(1254, 42);
            this.top_toolStrip.TabIndex = 1;
            this.top_toolStrip.Text = "toolStrip1";
            // 
            // new_toolStripButton
            // 
            this.new_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.new_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("new_toolStripButton.Image")));
            this.new_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.new_toolStripButton.Name = "new_toolStripButton";
            this.new_toolStripButton.Size = new System.Drawing.Size(46, 36);
            this.new_toolStripButton.Text = "toolStripButton1";
            this.new_toolStripButton.Click += new System.EventHandler(this.new_toolStripButton_Click);
            // 
            // open_toolStripButton
            // 
            this.open_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.open_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("open_toolStripButton.Image")));
            this.open_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open_toolStripButton.Name = "open_toolStripButton";
            this.open_toolStripButton.Size = new System.Drawing.Size(46, 36);
            this.open_toolStripButton.Text = "toolStripButton2";
            this.open_toolStripButton.Click += new System.EventHandler(this.open_toolStripButton_Click);
            // 
            // save_toolStripButton
            // 
            this.save_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("save_toolStripButton.Image")));
            this.save_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save_toolStripButton.Name = "save_toolStripButton";
            this.save_toolStripButton.Size = new System.Drawing.Size(46, 36);
            this.save_toolStripButton.Text = "toolStripButton3";
            this.save_toolStripButton.Click += new System.EventHandler(this.save_toolStripButton_Click);
            // 
            // saveas_toolStripButton
            // 
            this.saveas_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveas_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveas_toolStripButton.Image")));
            this.saveas_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveas_toolStripButton.Name = "saveas_toolStripButton";
            this.saveas_toolStripButton.Size = new System.Drawing.Size(46, 36);
            this.saveas_toolStripButton.Text = "toolStripButton4";
            this.saveas_toolStripButton.Click += new System.EventHandler(this.saveas_toolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // b_toolStripButton
            // 
            this.b_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.b_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("b_toolStripButton.Image")));
            this.b_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_toolStripButton.Name = "b_toolStripButton";
            this.b_toolStripButton.Size = new System.Drawing.Size(46, 36);
            this.b_toolStripButton.Text = "toolStripButton5";
            this.b_toolStripButton.Click += new System.EventHandler(this.b_toolStripButton_Click);
            // 
            // i_toolStripButton
            // 
            this.i_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.i_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("i_toolStripButton.Image")));
            this.i_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.i_toolStripButton.Name = "i_toolStripButton";
            this.i_toolStripButton.Size = new System.Drawing.Size(46, 36);
            this.i_toolStripButton.Text = "toolStripButton6";
            this.i_toolStripButton.Click += new System.EventHandler(this.i_toolStripButton_Click);
            // 
            // u_toolStripButton
            // 
            this.u_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.u_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("u_toolStripButton.Image")));
            this.u_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.u_toolStripButton.Name = "u_toolStripButton";
            this.u_toolStripButton.Size = new System.Drawing.Size(46, 36);
            this.u_toolStripButton.Text = "toolStripButton7";
            this.u_toolStripButton.Click += new System.EventHandler(this.u_toolStripButton_Click);
            // 
            // font_toolStripComboBox
            // 
            this.font_toolStripComboBox.Items.AddRange(new object[] {
            "8",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20"});
            this.font_toolStripComboBox.Name = "font_toolStripComboBox";
            this.font_toolStripComboBox.Size = new System.Drawing.Size(130, 42);
            this.font_toolStripComboBox.Click += new System.EventHandler(this.font_toolStripComboBox_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 42);
            // 
            // help_toolStripButton
            // 
            this.help_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.help_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("help_toolStripButton.Image")));
            this.help_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.help_toolStripButton.Name = "help_toolStripButton";
            this.help_toolStripButton.Size = new System.Drawing.Size(46, 36);
            this.help_toolStripButton.Text = "help_toolStripButton";
            this.help_toolStripButton.Click += new System.EventHandler(this.help_toolStripButton_Click);
            // 
            // un_toolStripLabel
            // 
            this.un_toolStripLabel.Name = "un_toolStripLabel";
            this.un_toolStripLabel.Size = new System.Drawing.Size(0, 36);
            // 
            // left_toolStrip
            // 
            this.left_toolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.left_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cut_toolStripButton,
            this.copy_toolStripButton,
            this.paste_toolStripButton});
            this.left_toolStrip.Location = new System.Drawing.Point(0, 82);
            this.left_toolStrip.Name = "left_toolStrip";
            this.left_toolStrip.Size = new System.Drawing.Size(48, 647);
            this.left_toolStrip.TabIndex = 2;
            this.left_toolStrip.Text = "toolStrip2";
            // 
            // cut_toolStripButton
            // 
            this.cut_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cut_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cut_toolStripButton.Image")));
            this.cut_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cut_toolStripButton.Name = "cut_toolStripButton";
            this.cut_toolStripButton.Size = new System.Drawing.Size(43, 36);
            this.cut_toolStripButton.Text = "toolStripButton8";
            this.cut_toolStripButton.Click += new System.EventHandler(this.cut_toolStripButton_Click);
            // 
            // copy_toolStripButton
            // 
            this.copy_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copy_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copy_toolStripButton.Image")));
            this.copy_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copy_toolStripButton.Name = "copy_toolStripButton";
            this.copy_toolStripButton.Size = new System.Drawing.Size(43, 36);
            this.copy_toolStripButton.Text = "toolStripButton9";
            this.copy_toolStripButton.Click += new System.EventHandler(this.copy_toolStripButton_Click);
            // 
            // paste_toolStripButton
            // 
            this.paste_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.paste_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("paste_toolStripButton.Image")));
            this.paste_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paste_toolStripButton.Name = "paste_toolStripButton";
            this.paste_toolStripButton.Size = new System.Drawing.Size(43, 36);
            this.paste_toolStripButton.Text = "toolStripButton10";
            this.paste_toolStripButton.Click += new System.EventHandler(this.paste_toolStripButton_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.Location = new System.Drawing.Point(51, 85);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(1203, 647);
            this.richTextBox.TabIndex = 3;
            this.richTextBox.Text = "";
            this.richTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseClick);
            this.richTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyDown);
            // 
            // TextEditor
            // 
            this.ClientSize = new System.Drawing.Size(1254, 729);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.left_toolStrip);
            this.Controls.Add(this.top_toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TextEditor";
            this.Text = "Text Editor";
            this.Load += new System.EventHandler(this.TextEditor_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.top_toolStrip.ResumeLayout(false);
            this.top_toolStrip.PerformLayout();
            this.left_toolStrip.ResumeLayout(false);
            this.left_toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
