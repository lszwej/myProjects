using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SpeechLib;
using AIMLbot;
using System.Text.RegularExpressions;

namespace ChatterBot
{
    public partial class ChatterBot : Form
    {
        private const string defaultExtension = ".txt";
        private const string filter = "Text files |*.txt|All files |*.*";
        private OpenFileDialog loadConversationDialog;
        private SaveFileDialog saveConversationDialog;
        private Bot ourBot
        private User ourUser;

        public ChatterBot()
        {
            InitializeComponent();
        }

        private void ChatterBot_Load(object sender, EventArgs e)
        {
            try
            {
                loadConversationDialog = new OpenFileDialog();
                saveConversationDialog = new SaveFileDialog();

                ourBot = new Bot();
                ourUser = new User("USER", ourBot);
            
                ourBot.loadSettings();
                ourBot.loadAIMLFromFiles();
                ourBot.isAcceptingUserInput = true;
            }

            catch (IOException)
            {
                MessageBox.Show("Cannot load settings from a file", "Error settings", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }

            catch (System.Xml.XmlException ex)
            {
                MessageBox.Show(ex.Message, "Error XML", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void sendbut_Click(object sender, EventArgs e)
        {
            try
            {
                string userText = input.Text.Trim();
                        
                if (!string.IsNullOrWhiteSpace(userText))
                {
                    ourBot.isAcceptingUserInput = true;
                    richTxtBox.AppendText("USER: " + userText + Environment.NewLine);
                    Request request = new Request(userText, ourUser, ourBot);
                    Result result = ourBot.Chat(request);
                    richTxtBox.AppendText("BOT: " + result.Output + Environment.NewLine);
                    richTxtBox.ScrollToCaret();
                    if (soundMenu.Checked == true)
                    {
                        SpVoice sound = new SpVoice();
                        sound.Speak(result.Output);
                        sound.SynchronousSpeakTimeout = 5;
                        sound.Rate = 50;
                        sound.Volume = 100;
                    }
                }
                else
                    ourBot.isAcceptingUserInput = false;
                input.Text = "";
            }

            catch (System.FormatException)
            {
                    MessageBox.Show("Cannot get an answer from a chatterbot", "Error answer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearbut_Click(object sender, EventArgs e)
        {
            richTxtBox.Text = "";
            input.Text = "";
            soundMenu.CheckState = CheckState.Unchecked;
        }

        private void soundMenu_Click(object sender, EventArgs e)
        {
            if (soundMenu.Checked == true)
                soundMenu.CheckState = CheckState.Unchecked;
            else
                soundMenu.CheckState = CheckState.Checked;
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            loadConversationDialog.DefaultExt = defaultExtension;
            loadConversationDialog.Filter = filter;
            loadConversationDialog.Multiselect = false;

            try
            {
                if (loadConversationDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    richTxtBox.Text = File.ReadAllText(loadConversationDialog.FileName, Encoding.UTF8);
                richTxtBox.ScrollToCaret();

            }
            catch (IOException)
            {
                MessageBox.Show("Cannot open a file", "Error file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveMenu_Click(object sender, EventArgs e)
        {
            saveConversationDialog.DefaultExt = defaultExtension;
            saveConversationDialog.Filter = filter;
            saveConversationDialog.FileName = "conversation.txt";

            try
            {
                if (saveConversationDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    File.WriteAllText(saveConversationDialog.FileName, richTxtBox.Text);
                richTxtBox.ScrollToCaret();

            }
            catch (IOException)
            {
                MessageBox.Show("Cannot open a file", "Error file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sendbut_Click(sender, e);
        }
    }
}
