using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SXCheatTool
{
    public partial class Form1 : Form
    {
        private bool wordWrap = false;

        public Form1()
        {
            InitializeComponent();
        }

        static int count = 0; // used to keep track of cont register that user chose

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a program designed to make working with the SX OS cheat codetypes easier for people who do not want to or have the time to learn about the cheat codetypes.\n\nAll conversions will be done illicitly. There will be no logic checking. If you want your code to work, then make sure you enter actual information and not random stuff, because the program will accept pretty much anything as an input and doesn't care if it will produce a working code or not.", "About");
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-DarkFlare for creating the program\n-Team Xecuter for SX cheat codetypes", "Credits");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
            checkBox6.Visible = false;
            checkBox7.Visible = false;
            checkBox8.Visible = false;
            checkBox9.Visible = false;
            checkBox10.Visible = false;
            checkBox11.Visible = false;
            checkBox12.Visible = false;
            checkBox13.Visible = false;
            checkBox14.Visible = false;
            checkBox15.Visible = false;
            checkBox16.Visible = false;
            checkBox17.Visible = false;
            checkBox18.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            groupBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            groupBox4.Visible = false;
            radioButton13.Visible = false;
            groupBox4.Text = "Comparison:";
            radioButton9.Text = "Equal";
            radioButton10.Text = "Less than";
            radioButton11.Text = "Not equal";
            radioButton12.Text = "Greater than";
            if (comboBox1.SelectedIndex == 0) // memory write
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                label5.Visible = true;
                label5.Text = "Address relevent to NSO:";
                label6.Visible = true;
                groupBox3.Visible = true;
                label6.Text = "Value:";
                radioButton1.Text = "Write to NSO";
                radioButton2.Text = "Write to HEAP";
            }
            if (comboBox1.SelectedIndex == 1) // terminator
            {
            }
            if (comboBox1.SelectedIndex == 2) // button activator
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = true;
                checkBox7.Visible = true;
                checkBox8.Visible = true;
                checkBox9.Visible = true;
                checkBox10.Visible = true;
                checkBox11.Visible = true;
                checkBox12.Visible = true;
                checkBox13.Visible = true;
                checkBox14.Visible = true;
                checkBox15.Visible = true;
                checkBox16.Visible = true;
                checkBox17.Visible = true;
                checkBox18.Visible = true;
            }
            if (comboBox1.SelectedIndex == 3) // conditional
            {
                label5.Text = "Address relevent to NSO:";
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label6.Text = "Value to compare against:";
                groupBox3.Visible = true;
                groupBox4.Visible = true;
                radioButton1.Text = "Compare NSO";
                radioButton2.Text = "Compare HEAP";
            }
            if (comboBox1.SelectedIndex == 4) // loop start
            {
                label5.Visible = true;
                label5.Text = "Count register:";
                textBox4.Visible = true;
                label6.Visible = true;
                label6.Text = "Number of times to loop:";
                textBox5.Visible = true;
            }
            if (comboBox1.SelectedIndex == 5) // loop end
            {
            }
            if (comboBox1.SelectedIndex == 6) // load register with value
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton1.Text = "From RAM";
                radioButton2.Text = "Specific Value";
                textBox4.Visible = true;
                textBox5.Visible = true;
                label5.Visible = true;
                label5.Text = "Register:";
                label6.Visible = true;
                label6.Text = "Address:";
                groupBox3.Visible = true;
            }
            if (comboBox1.SelectedIndex == 7) // store register to memory
            {
                textBox4.Visible = true;
                textBox5.Visible = true;
                label5.Visible = true;
                label5.Text = "Register containing RAM address:";
                label6.Visible = true;
                label6.Text = "Value to store to memory:";
                groupBox3.Visible = true;
            }
            if (comboBox1.SelectedIndex == 8) // apply Arithmic operation
            {
                groupBox4.Visible = true;
                radioButton13.Visible = true;
                groupBox4.Text = "Arithmic Operation:";
                radioButton9.Text = "Addition";
                radioButton10.Text = "Shift left";
                radioButton11.Text = "Multiplication";
                radioButton12.Text = "Subtraction";
                radioButton13.Text = "Shift right";
                textBox4.Visible = true;
                textBox5.Visible = true;
                label5.Visible = true;
                label5.Text = "Register to apply operation to:";
                label6.Visible = true;
                label6.Text = "Value to use for operation:";
                groupBox3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                int T = 0;
                string text = "";
                text = textBox5.Text.PadLeft(8, '0');
                if (radioButton5.Checked)
                    T = 1;
                if (radioButton6.Checked)
                    T = 2;
                if (radioButton7.Checked)
                    T = 4;
                if (radioButton8.Checked)
                {
                    T = 8;
                    text = textBox5.Text.PadLeft(16, '0');
                    text = text.Substring(0, 8) + " " + text.Substring(8);
                }
                text = "0" + T + Convert.ToInt32(radioButton2.Checked) + "F00" + textBox4.Text.PadLeft(10, '0') + text + System.Environment.NewLine;
                text = text.Substring(0, 8) + " " + text.Substring(8);
                text = text.Substring(0, 17) + " " + text.Substring(17);
                richTextBox1.Text += text;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text += "20000000" + System.Environment.NewLine;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                int result = 0;
                int[] buttons = { 0x1, 0x2, 0x4, 0x8, 0x10, 0x20, 0x40, 0x80, 0x100, 0x200, 0x400, 0x800, 0x1000, 0x2000, 0x4000, 0x8000, 0x10000, 0x20000, 0x40000, 0x80000, 0x100000, 0x200000, 0x400000, 0x800000, 0x1000000, 0x2000000 };
                if (checkBox1.Checked)
                    result += buttons[0];
                if (checkBox2.Checked)
                    result += buttons[1];
                if (checkBox3.Checked)
                    result += buttons[2];
                if (checkBox4.Checked)
                    result += buttons[3];
                if (checkBox5.Checked)
                    result += buttons[4];
                if (checkBox12.Checked)
                    result += buttons[5];
                if (checkBox6.Checked)
                    result += buttons[6];
                if (checkBox7.Checked)
                    result += buttons[7];
                if (checkBox8.Checked)
                    result += buttons[8];
                if (checkBox9.Checked)
                    result += buttons[9];
                if (checkBox10.Checked)
                    result += buttons[10];
                if (checkBox11.Checked)
                    result += buttons[11];
                if (checkBox14.Checked)
                    result += buttons[12];
                if (checkBox13.Checked)
                    result += buttons[13];
                if (checkBox15.Checked)
                    result += buttons[14];
                if (checkBox16.Checked)
                    result += buttons[15];
                if (checkBox17.Checked)
                    result += buttons[24];
                if (checkBox18.Checked)
                    result += buttons[25];
                richTextBox1.Text += "8" + result.ToString("X").PadLeft(7, '0') + System.Environment.NewLine;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                int T = 0, F = 0;
                string text = "";
                text = textBox5.Text.PadLeft(8, '0');
                if (radioButton5.Checked)
                    T = 1;
                if (radioButton6.Checked)
                    T = 2;
                if (radioButton7.Checked)
                    T = 4;
                if (radioButton8.Checked)
                {
                    T = 8;
                    text = textBox5.Text.PadLeft(16, '0');
                    text = text.Substring(0, 8) + " " + text.Substring(8);
                }
                text = "1" + T + Convert.ToInt32(radioButton2.Checked) + F + "00" + textBox4.Text.PadLeft(10, '0') + text + System.Environment.NewLine;
                text = text.Substring(0, 8) + " " + text.Substring(8);
                text = text.Substring(0, 17) + " " + text.Substring(17);
                richTextBox1.Text += text;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                count = Convert.ToInt32(textBox4.Text);
                richTextBox1.Text += "300" + textBox4.Text + "0000 " + textBox5.Text.PadLeft(8, '0') + System.Environment.NewLine;
            }
            if (comboBox1.SelectedIndex == 5)
            {
                richTextBox1.Text += "310" + count + "0000" + System.Environment.NewLine;
            }
            if (comboBox1.SelectedIndex == 6)
            {
                if (radioButton2.Checked)
                    richTextBox1.Text += "400" + textBox4.Text.PadLeft(1, '0') + "0000 " + textBox5.Text.PadLeft(16, '0').Substring(0, 8) + " " + textBox5.Text.PadLeft(16, '0').Substring(8, 8) + System.Environment.NewLine;
                if (radioButton1.Checked)
                {
                    int T = 0;
                    if (radioButton5.Checked)
                        T = 1;
                    if (radioButton6.Checked)
                        T = 2;
                    if (radioButton7.Checked)
                        T = 4;
                    if (radioButton8.Checked)
                        T = 8;
                    richTextBox1.Text += "5" + T + "1" + textBox4.Text.PadLeft(1, '0') + "00" + textBox5.Text.PadLeft(10, '0').Substring(0, 2) + " " + textBox5.Text.PadLeft(10, '0').Substring(2, 8) + System.Environment.NewLine;
                }
            }
            if (comboBox1.SelectedIndex == 7)
            {
                int T = 0;
                if (radioButton5.Checked)
                    T = 1;
                if (radioButton6.Checked)
                    T = 2;
                if (radioButton7.Checked)
                    T = 4;
                if (radioButton8.Checked)
                    T = 8;
                richTextBox1.Text += "6" + T + "0" + textBox4.Text.PadLeft(1, '0') + "0000 " + textBox5.Text.PadLeft(16, '0').Substring(0, 8) + " " + textBox5.Text.PadLeft(16, '0').Substring(8, 8) + System.Environment.NewLine;
            }
            if (comboBox1.SelectedIndex == 8)
            {
                int T = 0, C = 0;
                if (radioButton5.Checked)
                    T = 1;
                if (radioButton6.Checked)
                    T = 2;
                if (radioButton7.Checked)
                    T = 4;
                if (radioButton8.Checked)
                    T = 8;
                if (radioButton9.Checked)
                    C = 0;
                if (radioButton10.Checked)
                    C = 3;
                if (radioButton11.Checked)
                    C = 2;
                if (radioButton12.Checked)
                    C = 1;
                if (radioButton13.Checked)
                    C = 4;
                richTextBox1.Text += "7" + T + "0" + textBox4.Text + C + "000 " + textBox5.Text.PadLeft(8, '0') + System.Environment.NewLine;
            }
        }

        private void button1_Click_1(object sender, EventArgs e) // assembly conversions
        {
            MessageBox.Show("This feature will probably be worked on later. Since Team Xecuter did not release any additional information regarding conditional statements, there isn't much to do here.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            string temp = "", temp2 = "";
            string readall = richTextBox2.Text;
            string line = null;
            StringReader LineString = new StringReader(readall);
            richTextBox3.Text = "";
            while (true)
            {
                line = LineString.ReadLine();
                if (line == null)
                    break;
                if (line.Contains(" "))
                    line = line.Replace(" ", "");
                if (line.StartsWith("li"))
                {
                    temp = Regex.Match(line, @"\d+").Value;
                    temp = temp.Substring(0, 1);
                    temp2 = new String(line.Where(Char.IsDigit).ToArray());
                    temp2 = temp2.Substring(1);
                    //textBox2.Text += "400" + temp + "0000 " + temp2;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (radioButton2.Checked)
                    label5.Text = "Address relevent to HEAP:";
                else
                    label5.Text = "Address relevent to NSO:";
            }
            if (comboBox1.SelectedIndex == 3)
            {
                if (radioButton2.Checked)
                    label5.Text = "Address relevent to HEAP:";
                else
                    label5.Text = "Address relevent to NSO:";
            }
            if (comboBox1.SelectedIndex == 6)
            {
                if (radioButton2.Checked)
                {
                    label6.Text = "Value:";
                    groupBox3.Visible = false;
                }
                else
                {
                    label6.Text = "Address:";
                    groupBox3.Visible = true;
                }
            }
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    checkForUpdatesToolStripMenuItem.Enabled = false;
                }));
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/DarkFlare69/SXCheatTool/raw/master/Release/SXCheatTool.exe", "SX Cheat Tool-latest.exe");
                    DialogResult result = MessageBox.Show("The latest update has just been downloaded! You can close this application and delete it. Run the 'SX Cheat Tool-latest.exe' file alongside this one.\n\nDo you want to exit the program now?", "Finished", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result.Equals(DialogResult.Yes))
                    {
                        Environment.Exit(0);
                    }
                }
                Invoke(new Action(() =>
                {
                    checkForUpdatesToolStripMenuItem.Enabled = true;
                }));
            }).Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.reloadWordWrap(Properties.Settings.Default.WordWrap);
        }

        private void enableWordWrappToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.reloadWordWrap(!this.wordWrap);
        }

        private void reloadWordWrap(bool wordWrap)
        {
            this.wordWrap = wordWrap;
            enableWordWrappToolStripMenuItem.Checked = wordWrap;

            richTextBox1.WordWrap = !wordWrap;
            richTextBox2.WordWrap = !wordWrap;
            richTextBox3.WordWrap = !wordWrap;

            Properties.Settings.Default.WordWrap = wordWrap;
            Properties.Settings.Default.Save();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.inputToolStripMenuItem_Click(sender, e);
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.reloadWordWrap(false);
        }

        private void exportCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text File|*.txt|Any File|*.*";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    RichTextBox selectedBox = null;
                    if(tabControl1.SelectedIndex == 0)
                    {
                        selectedBox = richTextBox1;
                    } else if(tabControl1.SelectedIndex == 1)
                    {
                        selectedBox = richTextBox3;
                    } else
                    {
                        MessageBox.Show("This page has not been implemented yet!\nPlease contact the developer and report the issue.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    foreach(String line in selectedBox.Lines)
                    {
                        sw.WriteLine(line);
                        sw.Flush();
                    }
                    sw.Close();
                }

                MessageBox.Show("The code has been successfully saved to the selected file.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
