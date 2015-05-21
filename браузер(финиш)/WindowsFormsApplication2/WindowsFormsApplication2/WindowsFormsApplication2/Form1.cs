using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using System.Net;
using System.IO;
using System.IO.Compression;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        WaveIn waveIn;
        WaveFileWriter writer;
        string outputFilename = "demo.wav";
        bool ON = false;
        public Form1()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Width = SystemInformation.PrimaryMonitorSize.Width;
            this.Height = SystemInformation.PrimaryMonitorSize.Height;
            tabControl1.TabPages.Remove(tabPage2); //скрываем вкладку с табло
            tabControl1.TabPages.Remove(tabPage3); //скрываем вкладку с закладками
            tabControl1.TabPages.Remove(tabPage4); //скрываем вкладку с историей

        }
        private void Form1_Load(object sender, EventArgs e) // загрузка формы
        {
            browser browser_web = new browser();
            browser_web.Owner = this;
            browser_web.TopLevel = false;
            browser_web.Visible = true;
            browser_web.Dock = DockStyle.Fill;
            tabControl1.SelectedTab.Controls.Add(browser_web);
            tabControl1.BackColor = BackColor;
        }
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            writer.WriteData(e.Buffer, 0, e.BytesRecorded);
        }


        void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            waveIn.Dispose();
            waveIn = null;
            writer.Close();
            writer = null;
        }

        public void tabControl1_MouseClick(object sender, MouseEventArgs e)//открытие вкладки/создание
        {
            if (e.Button == MouseButtons.Middle)
            {
                browser browser_web1 = new browser();
                TabPage tab = new TabPage();
                browser_web1.Owner = this;
                browser_web1.TopLevel = false;
                browser_web1.Visible = true;
                browser_web1.Dock = DockStyle.Fill;
                tabControl1.TabPages.Add(tab);
                tab.Controls.Add(browser_web1);
            }
        }
        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)//закрытие вкладки
        {
            if (e.Button == MouseButtons.Left)
            {
                if (tabControl1.TabPages.Count == 1)
                {
                    Close();
                }
                else tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tabControl1.SelectedTab.Text = Data.Value;
        }

        private void pictureBox1_Click(object sender, EventArgs e) //меню
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            else { panel1.Visible = false; }
        }

        private void label1_Click(object sender, EventArgs e)// если табло открыто, то больше не показывать
        {
            if (tabPage2.Parent == null)
            {
                tabControl1.TabPages.Add(tabPage2);
            }
            panel1.Visible = false;
            tabControl1.SelectTab(tabPage2); // делаем вкладку активной
        }

        private void pictureBox5_Click(object sender, EventArgs e) //yandex
        {
            browser browser_web1 = new browser();
            TabPage tab = new TabPage();
            browser_web1.Owner = this;
            browser_web1.TopLevel = false;
            browser_web1.Visible = true;
            browser_web1.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tab);
            tab.Controls.Add(browser_web1);
            tabControl1.SelectTab(tab); // делаем вкладку активной
            browser_web1.webBrowser1.Navigate("http://yandex.ru/");
        }

        private void pictureBox7_Click(object sender, EventArgs e) //mail
        {
            browser browser_web1 = new browser();
            TabPage tab = new TabPage();
            browser_web1.Owner = this;
            browser_web1.TopLevel = false;
            browser_web1.Visible = true;
            browser_web1.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tab);
            tab.Controls.Add(browser_web1);
            tabControl1.SelectTab(tab); // делаем вкладку активной
            browser_web1.webBrowser1.Navigate("http://mail.ru/");
        }

        private void pictureBox6_Click(object sender, EventArgs e)//vk
        {
            browser browser_web1 = new browser();
            TabPage tab = new TabPage();
            browser_web1.Owner = this;
            browser_web1.TopLevel = false;
            browser_web1.Visible = true;
            browser_web1.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tab);
            tab.Controls.Add(browser_web1);
            tabControl1.SelectTab(tab); // делаем вкладку активной
            browser_web1.webBrowser1.Navigate("http://vk.com/");
        }

        private void pictureBox8_Click(object sender, EventArgs e)//odnoklassniki
        {
            browser browser_web1 = new browser();
            TabPage tab = new TabPage();
            browser_web1.Owner = this;
            browser_web1.TopLevel = false;
            browser_web1.Visible = true;
            browser_web1.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tab);
            tab.Controls.Add(browser_web1);
            tabControl1.SelectTab(tab); // делаем вкладку активной
            browser_web1.webBrowser1.Navigate("http://odnoklassniki.ru/");
        }

        private void pictureBox12_Click(object sender, EventArgs e)//google
        {
            browser browser_web1 = new browser();
            TabPage tab = new TabPage();
            browser_web1.Owner = this;
            browser_web1.TopLevel = false;
            browser_web1.Visible = true;
            browser_web1.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tab);
            tab.Controls.Add(browser_web1);
            tabControl1.SelectTab(tab); // делаем вкладку активной
            browser_web1.webBrowser1.Navigate("http://google.com/");
        }

        private void pictureBox11_Click(object sender, EventArgs e)//facebook
        {
            browser browser_web1 = new browser();
            TabPage tab = new TabPage();
            browser_web1.Owner = this;
            browser_web1.TopLevel = false;
            browser_web1.Visible = true;
            browser_web1.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tab);
            tab.Controls.Add(browser_web1);
            tabControl1.SelectTab(tab); // делаем вкладку активной
            browser_web1.webBrowser1.Navigate("http://facebook.com/");
        }

        private void pictureBox10_Click(object sender, EventArgs e)//youtube
        {
            browser browser_web1 = new browser();
            TabPage tab = new TabPage();
            browser_web1.Owner = this;
            browser_web1.TopLevel = false;
            browser_web1.Visible = true;
            browser_web1.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tab);
            tab.Controls.Add(browser_web1);
            tabControl1.SelectTab(tab); // делаем вкладку активной
            browser_web1.webBrowser1.Navigate("http://youtube.com/");
        }

        private void pictureBox9_Click(object sender, EventArgs e)//wikipedia
        {
            browser browser_web1 = new browser();
            TabPage tab = new TabPage();
            browser_web1.Owner = this;
            browser_web1.TopLevel = false;
            browser_web1.Visible = true;
            browser_web1.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tab);
            tab.Controls.Add(browser_web1);
            tabControl1.SelectTab(tab); // делаем вкладку активной
            browser_web1.webBrowser1.Navigate("http://ru.wikipedia.org/");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //выбор фона 
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    pictureBox13.Image = Properties.Resources._1;//табло
                    pictureBox17.Image = Properties.Resources._1;//закладки
                    pictureBox19.Image = Properties.Resources._1;//история
                    break;
                case 1:
                    pictureBox13.Image = Properties.Resources._2;
                    pictureBox17.Image = Properties.Resources._2;
                    pictureBox19.Image = Properties.Resources._2;
                    break;
                case 2:
                    pictureBox13.Image = Properties.Resources._3;
                    pictureBox17.Image = Properties.Resources._3;
                    pictureBox19.Image = Properties.Resources._3;
                    break;

            }
        }

        private void label6_Click(object sender, EventArgs e)//выход через меню
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e) //новая вкладка через панель/меню
        {
            browser browser_web1 = new browser();
            TabPage tab = new TabPage();
            browser_web1.Owner = this;
            browser_web1.TopLevel = false;
            browser_web1.Visible = true;
            browser_web1.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tab);
            tab.Controls.Add(browser_web1);
        }

        private void label7_Click(object sender, EventArgs e)//закрыть вкладку через меню
        {
            if (tabControl1.TabPages.Count == 1)
            {
                Close();
            }
            else tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                browser browser_web1 = new browser();
                TabPage tab = new TabPage();
                browser_web1.Owner = this;
                browser_web1.TopLevel = false;
                browser_web1.Visible = true;
                browser_web1.Dock = DockStyle.Fill;
                tabControl1.TabPages.Add(tab);
                tab.Controls.Add(browser_web1);
                tabControl1.SelectTab(tab); // делаем вкладку активной
                browser_web1.webBrowser1.Navigate("http://yandex.ru/search/?lr=213&text=" + textBox3.Text + "&suggest_reqid=722156446143055714248672459210016");
                textBox3.Clear();
            }
        }

        private void textBox3_Click(object sender, EventArgs e) //очистка текстбокса табло
        {
            textBox3.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e) //очистка текстбокса закладки/активируем кнопку добавиления
        {
            textBox2.Clear();
            pictureBox16.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)//показать панель в закладках
        {
            panel2.Visible = true;
        }

        private void pictureBox16_Click(object sender, EventArgs e) //добавить закладку через меню
        {
            if (textBox2.Text != " ") //если не пусто то..
            {
                //Добавляем в список адрес и комментарий
                //Символ вертикальная черта будет в последующем использоваться
                //как разделитель комментария и адреса сайта
                listBox1.Items.Add(textBox2.Text);
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
                panel2.Visible = false;
            }
            else
            {
                MessageBox.Show("Введите URL");
            }
            textBox2.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {
            if (tabPage3.Parent == null)
            {
                tabControl1.TabPages.Add(tabPage3);
            }
            panel1.Visible = false;
            tabControl1.SelectTab(tabPage3); // делаем вкладку активной
            //
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

        private void label4_Click(object sender, EventArgs e)//история
        {
            if (tabPage4.Parent == null)
            {
                tabControl1.TabPages.Add(tabPage4);
            }
            panel1.Visible = false;
            tabControl1.SelectTab(tabPage4); // делаем вкладку активной
            using (StreamReader s = new StreamReader("history.txt"))
            {
                listBox2.Items.AddRange(System.IO.File.ReadAllLines(@"history.txt"));
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //закладки комбо
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    pictureBox13.Image = Properties.Resources._1;//табло
                    pictureBox17.Image = Properties.Resources._1;//закладки
                    pictureBox19.Image = Properties.Resources._1;//история
                    break;
                case 1:
                    pictureBox13.Image = Properties.Resources._2;
                    pictureBox17.Image = Properties.Resources._2;
                    pictureBox19.Image = Properties.Resources._2;
                    break;
                case 2:
                    pictureBox13.Image = Properties.Resources._3;
                    pictureBox17.Image = Properties.Resources._3;
                    pictureBox19.Image = Properties.Resources._3;
                    break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)//история комбо
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    pictureBox13.Image = Properties.Resources._1;//табло
                    pictureBox17.Image = Properties.Resources._1;//закладки
                    pictureBox19.Image = Properties.Resources._1;//история
                    break;
                case 1:
                    pictureBox13.Image = Properties.Resources._2;
                    pictureBox17.Image = Properties.Resources._2;
                    pictureBox19.Image = Properties.Resources._2;
                    break;
                case 2:
                    pictureBox13.Image = Properties.Resources._3;
                    pictureBox17.Image = Properties.Resources._3;
                    pictureBox19.Image = Properties.Resources._3;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)//загрузить страницу
        {
            
        }

        private void label11_Click(object sender, EventArgs e)//голос
        {
            textBox4.Visible = true;
            panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)//очитска истории вкл история
        {
            listBox2.Items.Clear();//очитска листбокса с историей    
            if (System.IO.File.Exists("history.txt") == true)//Если файл существует
            {
                File.Delete(@"history.txt"); //Удаляем
            }
            else MessageBox.Show("Файла не существует!!");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {//останавливаем запись
            textBox4.Clear();
            waveIn.StopRecording();
            label12.Text = "";
            ON = false;
            timer2.Enabled = false;
            timer3.Enabled = true;
        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            WebRequest request = WebRequest.Create("https://www.google.com/speech-api/v2/recognize?output=json&lang=ru-RU&key=AIzaSyBOti4mM-6x9WDnZIjIeyEU21OpBXqWBgw");
            //
            request.Method = "POST";
            byte[] byteArray = File.ReadAllBytes(outputFilename);
            request.ContentType = "audio/l16; rate=16000"; //"16000";
            request.ContentLength = byteArray.Length;
            request.GetRequestStream().Write(byteArray, 0, byteArray.Length);

            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(response.GetResponseStream());
            // Read the content.
            label13.Text = reader.ReadToEnd();
            // Clean up the streams.
            reader.Close();
            response.Close();
            string g = label13.Text; //основная 
            if (g.Length < 56)
            { MessageBox.Show("Данной команды не существует"); }
            else
            {
                string sub2 = g.Substring(56); //с нашего слова
                // richTextBox1.Text = sub2; //в ричбоксе
                string str = sub2; //
                string result = str.Substring(0, str.IndexOf('"'));// удаляем все что после нашего слова
                //richTextBox2.Text = result; //вывод
                switch (result)
                {
                    case "закладки":
                        {
                            if (tabPage3.Parent == null)
                            { tabControl1.TabPages.Add(tabPage3); }
                            panel1.Visible = false;
                            tabControl1.SelectTab(tabPage3);
                        }
                        break;
                    case "история":
                        {
                            if (tabPage4.Parent == null)
                            { tabControl1.TabPages.Add(tabPage4); }
                            panel1.Visible = false;
                            tabControl1.SelectTab(tabPage4);
                        }
                        break;
                    case "новая вкладка":
                        {
                            browser browser_web1 = new browser();
                            TabPage tab = new TabPage();
                            browser_web1.Owner = this;
                            browser_web1.TopLevel = false;
                            browser_web1.Visible = true;
                            browser_web1.Dock = DockStyle.Fill;
                            tabControl1.TabPages.Add(tab);
                            tab.Controls.Add(browser_web1);
                            tabControl1.SelectTab(tab);
                        }
                        break;
                    case "закрыть вкладку":
                        {
                            {
                                if (tabControl1.TabPages.Count == 1)
                                {
                                    Close();
                                }
                                else tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                            }
                        }
                        break;
                    case "табло":
                        {
                            {
                                if (tabPage2.Parent == null)
                                {
                                    tabControl1.TabPages.Add(tabPage2);
                                }
                                panel1.Visible = false;
                                tabControl1.SelectTab(tabPage2);
                            }
                            break;
                        }
                    case "выход":
                        { Application.Exit(); }
                        break;
                    default:
                        MessageBox.Show("1");
                        break;
                }
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                timer2.Enabled = true;
                waveIn = new WaveIn();
                waveIn.DeviceNumber = 0;
                waveIn.DataAvailable += waveIn_DataAvailable;
                waveIn.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(waveIn_RecordingStopped);
                waveIn.WaveFormat = new WaveFormat(16000, 1);
                writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);
                label12.Text = "Идет запись...";
                waveIn.StartRecording();
                ON = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)//удалить выбранный элемент в истории
        {
            if (listBox2.SelectedItem != null)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите значение");
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
             
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form3 abt = new Form3();
            abt.Show();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)//конт меню новая вкл
        {
            browser browser_web1 = new browser();
            TabPage tab = new TabPage();
            browser_web1.Owner = this;
            browser_web1.TopLevel = false;
            browser_web1.Visible = true;
            browser_web1.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tab);
            tab.Controls.Add(browser_web1);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)//конт меню закрыть вкл
        {
            if (tabControl1.TabPages.Count == 1)
            {
                Close();
            }
            else tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)//обновить конт меню
        {
            browser br = new browser();
            br.webBrowser1.Refresh();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)//конт меню выход
        {
            Application.Exit();
        }
    }
}