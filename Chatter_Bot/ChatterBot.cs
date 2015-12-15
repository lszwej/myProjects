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

        // zmienna do otwierania pliku
        private OpenFileDialog opdialog;
        // zmienna do zapisu pliku
        private SaveFileDialog svdialog;
        private Bot  ourBot;
        private User ourUser;

        public ChatterBot()
        {
            InitializeComponent();
        }

        private void ChatterBot_Load(object sender, EventArgs e)
        {
            try
            {
                // inicjalizacja zmiennych do obsługi zapisu oraz odczytu z pliku
                opdialog = new OpenFileDialog();
                svdialog = new SaveFileDialog();

                // inicjalizacja bota oraz usera
                ourBot = new Bot();
                ourUser = new User("USER", ourBot);
            
                // załadowanie ustawien z domyslnych folderow, bot odpowiada
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
                        // usuniecie bialych znakow z poczatku i konca tekstu
                        string userText = input.Text.Trim();
                        
                        if (!userText.Equals(""))
                        {
                            // jezeli tekst usera nie jest pusty to wypisz go w oknie, bot odpowiada
                            ourBot.isAcceptingUserInput = true;
                            richTxtBox.AppendText("USER: " + userText + Environment.NewLine);
                            // pobranie i wypisanie odpowiedzi bota
                            Request req = new Request(userText, ourUser, ourBot);
                            Result res = ourBot.Chat(req);
                            richTxtBox.AppendText("BOT: " + res.Output + Environment.NewLine);
                            richTxtBox.ScrollToCaret();
                            // sprawdzenie obslugi dzwieku
                            if (soundMenu.Checked == true)
                            {
                                SpVoice sound = new SpVoice();
                                sound.Speak(res.Output);
                                sound.SynchronousSpeakTimeout = 5;
                                sound.Rate = 50;
                                sound.Volume = 100;
                            }
                        }
                        else
                            // w przeciwnym razie bot nie odpowiada
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
            // przywrocenie domyslnych wlasciwosci
            richTxtBox.Text = "";
            input.Text = "";
            soundMenu.CheckState = CheckState.Unchecked;

        }

        private void soundMenu_Click(object sender, EventArgs e)
        {
            // jezeli dzwiek jest wlaczony po kliknieciu zostanie wylaczony, w przeciwnym razie zostanie wlaczony
            if (soundMenu.Checked == true)
                soundMenu.CheckState = CheckState.Unchecked;
            else
                soundMenu.CheckState = CheckState.Checked;
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            // ustawienie domyslnego rozszerznia pliku, listy obslugiwanych rozszerzen i ustalenie wyboru tylko jednego pliku
            opdialog.DefaultExt = ".txt";
            opdialog.Filter = "Text files |*.txt|All files |*.*";
            opdialog.Multiselect = false;

            try
            {
                // wczytanie rozmowy z pliku
                if (opdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    richTxtBox.Text = File.ReadAllText(opdialog.FileName, Encoding.UTF8);
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
            // ustawienie domyslnego rozszerznia pliku, listy obslugiwanych rozszerzen i ustalenie wyboru tylko jednego pliku
            svdialog.DefaultExt = ".txt";
            svdialog.Filter = "Text files |*.txt|All files |*.*";
            svdialog.FileName = "conversation.txt";

            try
            {
                // zapis rozmowy do pliku
                if (svdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    File.WriteAllText(svdialog.FileName, richTxtBox.Text);
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
            // wylaczenie programu
            this.Close();
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            // reakcja na nacisniecie enter w polu wprowadzania tesktu
            if (e.KeyCode == Keys.Enter)
                sendbut_Click(sender, e);
        }

        

    }
}
