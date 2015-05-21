using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Width = SystemInformation.PrimaryMonitorSize.Width;
            this.Height = SystemInformation.PrimaryMonitorSize.Height;
            tabControl1.TabPages.Remove(tabPage2); //скрываем вкладку с табло
            tabControl1.TabPages.Remove(tabPage3); //скрываем вкладку с закладками
        }
        private void Form1_Load(object sender, EventArgs e) // загрузка формы
        {
            browser browser_web = new browser();
            browser_web.Owner = this;
            browser_web.TopLevel = false;
            browser_web.Visible = true;
            browser_web.Dock = DockStyle.Fill;
            tabControl1.SelectedTab.Controls.Add(browser_web);
            BackColor = Color.Blue;
            tabControl1.BackColor = BackColor;

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

        private void pictureBox4_Click(object sender, EventArgs e) //выход
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e) //развернуть
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) //свернуть
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void label2_Click(object sender, EventArgs e) //новая вкладка через меню
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
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {
            AboutBox1 abt = new AboutBox1();
            abt.Show();
        }

    }
}