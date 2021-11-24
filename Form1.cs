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
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            Text = "Google Mail CSV Creator";
            saveFileDialog1.FileName = "";
            openFileDialog1.FileName = "";
            
        }

        

        private void настройкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public static string GetPass(int x)
        {
            string pass = "";
            var r = new Random();
            while (pass.Length < x)
            {
                Char c = (char)r.Next(33, 125);
                if (Char.IsLetterOrDigit(c))
                    pass += c;
            }
            return pass;
        }
        



        private void button1_Click(object sender, EventArgs e)
        {
            //змінна з адресою пошти
            string mailaddr = "";
            string domain = "";
            //транслітерація імені
            string val = textBox2.Text;
            TranslitMethods.Translitter trn = new TranslitMethods.Translitter();
            string str = trn.Translit(val, TranslitMethods.TranslitType.Gost);
            
            //захоплення першої літери з імені
            var firstLetters = new String(str.Split(' ').Select(x => x[0]).ToArray());
            
            //транслітерація прізвища
            string val2 = textBox1.Text;
            TranslitMethods.Translitter trn2 = new TranslitMethods.Translitter();
            string str2 = trn2.Translit(val2, TranslitMethods.TranslitType.Gost);

            //змінна складання адреси пошти
            if (comboBox1.Text.Length == 0)
            return;
            else

             mailaddr = firstLetters + "." + str2 + comboBox1.Text;
            

            //результат
            textBox4.Text = mailaddr;

            if (comboBox1.Text.Length == 0)
            {
                MessageBox.Show("Оберіть домен", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string pass = GetPass(8);
            string ch;
            if (checkBox1.Checked == true)
                ch = "TRUE";
            else
                ch = "0";


            if (saveFileDialog1.FileName.Length == 0 && openFileDialog1.FileName.Length == 0)
                {
                MessageBox.Show("Файл не обрано або не створено!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            
            if (saveFileDialog1.FileName.Length == 0)
                {
                    
                    string filename3 = openFileDialog1.FileName;
                    StreamWriter f_out = new StreamWriter(filename3, true);
                    f_out.WriteLine(textBox1.Text + "," + textBox2.Text + " " + textBox3.Text + "," + textBox4.Text + "," + pass + ",,/,," + textBox5.Text + ",,," + textBox6.Text + ",,,,,,,,,,,,,,," + ch + ",");
                    f_out.Close();
                }
            else
                {

                
                string filename2 = saveFileDialog1.FileName;
                StreamWriter f_out = new StreamWriter(filename2, true);
                f_out.WriteLine(textBox1.Text + "," + textBox2.Text + " " + textBox3.Text + "," + textBox4.Text + "," + pass + ",,/,," + textBox5.Text + ",,," + textBox6.Text + ",,,,,,,,,,,,,,," + ch + ",");
                f_out.Close();
                }
                        
        }

        

        private void вихідToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            openFileDialog1.Filter = "CSV file(*.csv)|*.csv|Text file(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            label7.Text = openFileDialog1.FileName;
        }

        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            string curdate = "MailUserList_" + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss");
            saveFileDialog1.Filter = "CSV file(*.csv)|*.csv|Text file(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.FileName = curdate;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
           
            label7.Text = saveFileDialog1.FileName;
            string filename1 = saveFileDialog1.FileName;


            
            StreamWriter f_out = new StreamWriter(filename1, true);
            f_out.WriteLine("First Name [Required],Last Name [Required],Email Address [Required],Password [Required],Password Hash Function [UPLOAD ONLY],Org Unit Path [Required],New Primary Email [UPLOAD ONLY],Recovery Email,Home Secondary Email,Work Secondary Email,Recovery Phone [MUST BE IN THE E.164 FORMAT],Work Phone,Home Phone,Mobile Phone,Work Address,Home Address,Employee ID,Employee Type,Employee Title,Manager Email,Department,Cost Center,Building ID,Floor Name,Floor Section,Change Password at Next Sign-In,New Status [UPLOAD ONLY]");
            f_out.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName.Length == 0 && saveFileDialog1.FileName.Length == 0)
            {
                MessageBox.Show("Файл не обрано або не створено!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (openFileDialog1.FileName.Length > 0) 
                Process.Start(new ProcessStartInfo(openFileDialog1.FileName) { UseShellExecute = true });
            else if (saveFileDialog1.FileName.Length > 0)
                Process.Start(new ProcessStartInfo(saveFileDialog1.FileName) { UseShellExecute = true });
            
        }

        private void транслітToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string val = textBox1.Text;
            TranslitMethods.Translitter trn = new TranslitMethods.Translitter();
            string str = trn.Translit(val, TranslitMethods.TranslitType.Gost);
            textBox7.Text  = str;


        }

    }
}