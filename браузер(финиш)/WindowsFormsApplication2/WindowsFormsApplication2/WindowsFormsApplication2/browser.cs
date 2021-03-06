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

namespace WindowsFormsApplication1
{
    public partial class browser : Form
    {
        public browser()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Width = SystemInformation.PrimaryMonitorSize.Width;
            this.Height = SystemInformation.PrimaryMonitorSize.Height;
            this.webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
            webBrowser1.ScriptErrorsSuppressed = true;
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        { 
        if (e.KeyCode == Keys.Enter)
        {
            webBrowser1.Navigate("http://" + textBox3.Text);
        }
        }
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox3.Text = webBrowser1.Document.Url.ToString();
        }
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) //статусбар
        {
            if (e.CurrentProgress >= 0 && e.CurrentProgress <= 100)
            {
                toolStripProgressBar1.Value = (int)e.CurrentProgress;
            }

            toolStripStatusLabel1.Text = webBrowser1.StatusText;

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
            textBox1.Text = newstr;
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
            webBrowser1.GoHome();
        }

        private void pictureBox7_Click(object sender, EventArgs e)//кнопка поиска
        {
            webBrowser1.Navigate("http://yandex.ru/search/?lr=213&text=" + textBox3.Text + "&suggest_reqid=722156446143055714248672459210016");
        }

        private void pictureBox8_Click(object sender, EventArgs e)//кнопка - закладки
        {
            panel1.Visible = true;
            //button5.Visible = false;
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
    }
}