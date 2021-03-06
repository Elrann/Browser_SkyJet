﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using System.IO.Compression;
namespace WindowsFormsApplication1
{
    public partial class browser : Form
    {
        public browser()
        {

            InitializeComponent();
            webBrowser1.IsWebBrowserContextMenuEnabled = false;//откл контекст меню
            this.Location = new Point(0, 0);
            this.Width = SystemInformation.PrimaryMonitorSize.Width;
            this.Height = SystemInformation.PrimaryMonitorSize.Height;
            this.webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate("http://yandex.ru/");
            Form1 fg = new Form1();
            fg.Owner = this;
            comboBox1.Text = "10";
        }
        //
        SpeechSynthesizer sSynt = new SpeechSynthesizer();
        PromptBuilder pBuild = new PromptBuilder();
        SpeechRecognitionEngine sReg = new SpeechRecognitionEngine();
        //
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string s;
                s = textBox3.Text;
                s = s.Replace(" ", "");
                webBrowser1.Navigate("http://" + s);
            }
            if (e.KeyCode == Keys.F12)
            {
                if (richTextBox1.Visible == true)
                {
                    richTextBox1.Visible = false;
                }
                else
                {
                    richTextBox1.Visible = true;
                    HttpWebRequest req;
                    HttpWebResponse resp;
                    StreamReader sr;
                    string content;

                    req = (HttpWebRequest)WebRequest.Create(webBrowser1.Document.Url.ToString());
                    resp = (HttpWebResponse)req.GetResponse();
                    sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                    content = sr.ReadToEnd();
                    sr.Close();
                    string p = content;
                    p = p.Replace(">", "> \n");
                    richTextBox1.Text = p;
                }
            }
        }
        public void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox3.Text = webBrowser1.Document.Url.ToString();
            Data.Value = webBrowser1.DocumentTitle;
            listBox2.Items.Add(webBrowser1.Document.Url.ToString());
            if (!(textBox1.Text == textBox3.Text))
                // Создаём переменную sw для записи данных в поток (файл)
                using (FileStream sw = new FileStream("history.txt", FileMode.Append))
                {
                    textBox1.Text = textBox3.Text;
                    string data = DateTime.Now.ToString();
                    using (StreamWriter we = new StreamWriter(sw))
                    {
                        listBox2.Items.Add(textBox1.Text);
                        we.WriteLine(data + "  " + textBox1.Text);
                    }


                }

        }
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) //статусбар
        {
            if (e.CurrentProgress >= 0 && e.CurrentProgress <= 100)
            {
                toolStripProgressBar1.Value = (int)e.CurrentProgress;
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            string newstr = "";
            int flag = 0; //flag определяет разделитель |
            char c;
            int k = str.Length;
            //Выделяем из строки адрес сайта
            for (int j = 0; j < k; j++)
            {
                c = str[j];
                if (flag != 0) newstr += c;
                if (c == '|') flag = 1;
            }
            //Подставляем в адресную строку адрес сайта
            textBox3.Text = newstr;
            webBrowser1.Navigate(textBox3.Text);
        }
        private void webBrowser1_NewWindow_1(object sender, CancelEventArgs e) //запрет IE
        {
            webBrowser1.Navigate(webBrowser1.StatusText);
            e.Cancel = true;
        }
        private void pictureBox2_Click(object sender, EventArgs e)//кнопка - назад
        {
            webBrowser1.GoBack();
        }

        private void pictureBox3_Click(object sender, EventArgs e)//кнопка - вперед
        {
            webBrowser1.GoForward();
        }

        private void pictureBox4_Click(object sender, EventArgs e)//кнопка - обновить
        {
            webBrowser1.Refresh();
        }

        private void pictureBox5_Click(object sender, EventArgs e)//кнопка - стоп
        {
            webBrowser1.Stop();
        }

        private void pictureBox6_Click(object sender, EventArgs e)//кнопка - дом
        {
            webBrowser1.Navigate("http://yandex.ru/");
        }

        private void pictureBox7_Click(object sender, EventArgs e)//кнопка поиска
        {
            webBrowser1.Navigate("http://yandex.ru/search/?lr=213&text=" + textBox3.Text + "&suggest_reqid=722156446143055714248672459210016");
        }

        private void pictureBox8_Click(object sender, EventArgs e)//кнопка - закладки
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
                pictureBox1.Visible = true;
                textBox2.Text = textBox1.Text;
                // Очищаем список от содержимого
                listBox1.Items.Clear();
                // Создаём переменную reader для чтения из файла browser.ini
                if (System.IO.File.Exists("browser.ini") == false)
                {
                    System.IO.StreamWriter textFile = new System.IO.StreamWriter(@"browser.ini");
                    textFile.WriteLine("0");
                    textFile.Close();
                }
                else
                {
                    using (StreamReader reader = new StreamReader("browser.ini"))
                    {
                        // Считываем первую строку чтобы получить число строк в списке
                        string z = reader.ReadLine();
                        //В цикле считываем остальные строки из файла
                        for (int j = 0; j < Convert.ToDouble(z); j++)
                            listBox1.Items.Add(reader.ReadLine());
                    }
                }
            }
            else
            {
                panel1.Visible = false;
            }
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.None;
        }
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.None;
        }
        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox4.BorderStyle = BorderStyle.None;
        }
        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox5.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox5.BorderStyle = BorderStyle.None;
        }
        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox6.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox6.BorderStyle = BorderStyle.None;
        }
        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox7.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox7.BorderStyle = BorderStyle.None;
        }
        private void pictureBox8_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox8.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox8_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox8.BorderStyle = BorderStyle.None;
        }
        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox9.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox9.BorderStyle = BorderStyle.None;
        }
        private void pictureBox10_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox10.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox10_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox10.BorderStyle = BorderStyle.None;
        }//здесь обработчики графического поведения кнопок. Сюда добавлять все обработчики поведения кнопокпри попадании на них мыши

        private void pictureBox9_Click(object sender, EventArgs e)//кнопка - удалить
        {
            {// Проверяем, есть ли в списке выделенная строка
                if (listBox1.SelectedIndex == -1)
                    // Если нет, то выводим сообщение.
                    MessageBox.Show("Нет выделенной строки");
                else
                    // Иначе .. Удаляем выделенную строку
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                //Сохраняем новый список в файле
                using (StreamWriter sw = new StreamWriter("browser.ini"))
                {
                    sw.WriteLine(listBox1.Items.Count.ToString());
                    for (int j = 0; j < listBox1.Items.Count; j++)
                        sw.WriteLine(listBox1.Items[j]);
                }
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)//кнопка - добавить
        {
            if (textBox1.Text != "" && textBox2.Text != " ")
            {
                //Добавляем в список адрес и комментарий
                //Символ вертикальная черта будет в последующем использоваться
                //как разделитель комментария и адреса сайта
                listBox1.Items.Add(textBox1.Text + "|" + textBox2.Text);
                // Создаём переменную sw для записи данных в поток (файл)
                using (StreamWriter sw = new StreamWriter("browser.ini"))
                {
                    // Первой строкой записываем в файл число строк в нашем списке
                    sw.WriteLine(listBox1.Items.Count.ToString());
                    // В цикле записываем все строки в файл.
                    // Count - число строк в списке
                    for (int j = 0; j < listBox1.Items.Count; j++)
                        sw.WriteLine(listBox1.Items[j]);
                }
            }
            else { MessageBox.Show("Введите имя и адрес"); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = webBrowser1.StatusText;
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)//кнопка ок таймер
        {
                SpeechSynthesizer h = new SpeechSynthesizer();
                h.Speak("Браузер будет работать" + comboBox1.Text + "минут");
                {
                    string t = comboBox1.Text;
                    int i = int.Parse(t);
                    i = i * 60000;
                    if (i > 600000)
                    {
                        timer2.Interval = i;
                        timer3.Interval = (i - 300000);
                        timer2.Enabled = true;
                        timer3.Enabled = true;
                        panel2.Visible = false;
                    }
                    else
                    {
                        panel2.Visible = false;
                    }
                }
            }
           
        private void timer2_Tick(object sender, EventArgs e)//выход по таймеру
        {
            Application.Exit();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            panel3.Visible = true;
            SpeechSynthesizer h = new SpeechSynthesizer();
            h.Speak("Осталось 5 минут");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void pictureBox12_Click(object sender, EventArgs e)//истр
        {            
            listBox2.Items.Clear();
            if (panel4.Visible == false && panel2.Visible == false)
            {
                panel4.Visible = true;
                panel2.Visible = true;
                if (System.IO.File.Exists("history.txt") == false)
                {
                    System.IO.StreamWriter textFile = new System.IO.StreamWriter(@"history.txt");
                    //textFile.WriteLine("0");
                    textFile.Close();
                }
                else
                {
                    using (StreamReader s = new StreamReader("history.txt"))
                    {
                        listBox2.Items.AddRange(System.IO.File.ReadAllLines(@"history.txt"));
                    }
                }
            }
            else
            {
                panel4.Visible = false;
                panel2.Visible = false;
            }
        }


        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            string str = listBox2.SelectedItem.ToString();
            textBox3.Text = str;
            webBrowser1.Navigate(textBox3.Text);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)//назад меню
        {
            webBrowser1.GoBack();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)//вперед меню
        {
            webBrowser1.GoForward();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)//обновить меню
        {
            webBrowser1.Refresh();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)//выход через контекстное меню
        {
            Application.Exit();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)//кнопка ОК панель с таймером
        {
            if (e.KeyCode == Keys.Enter)
            {
                SpeechSynthesizer h = new SpeechSynthesizer();
                h.Speak("Браузер будет работать" + comboBox1.Text + "минут");

                {
                    string t = comboBox1.Text;
                    int i = int.Parse(t);
                    i = i * 60000;
                    if (i > 600000)
                    {
                        timer2.Interval = i;
                        timer3.Interval = (i - 300000);
                        timer2.Enabled = true;
                        timer3.Enabled = true;
                        panel2.Visible = false;
                    }
                    else
                    {
                        panel2.Visible = false;
                    }
                }
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)//запрет ввода данных
        {
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
    }
}