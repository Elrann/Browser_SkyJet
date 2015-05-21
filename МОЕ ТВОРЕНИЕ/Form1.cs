using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           this.toolStripMenuItem1.Click+=new EventHandler(toolStripMenuItem1_Click);
           this.Location = new Point(0, 0);
           this.Width = SystemInformation.PrimaryMonitorSize.Width;
           this.Height = SystemInformation.PrimaryMonitorSize.Height;

        }
       private void Form1_Load(object sender, EventArgs e) // загрузка формы
        {
            browser browser_web = new browser();
            browser_web.Owner = this;
            browser_web.TopLevel = false;
            browser_web.Visible = true;
            browser_web.Dock = DockStyle.Fill;
            tabControl1.SelectedTab.Controls.Add(browser_web);   
        }
       private void toolStripMenuItem1_Click(object sender, EventArgs e) //создание вкладки
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

       private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
       {}

       private void toolStripMenuItem2_Click(object sender, EventArgs e) //проверка вкладок, если 1 то close app
       {
           if (tabControl1.TabPages.Count == 1) 
           {
               Close();
           }
           else tabControl1.TabPages.Remove(tabControl1.SelectedTab);
       }

       private void tabControl1_MouseClick(object sender, MouseEventArgs e)
       {}

       private void pictureBox1_Click(object sender, EventArgs e)
       {
           if (tabControl1.TabPages.Count == 1)
           {
               Close();
           }
           else tabControl1.TabPages.Remove(tabControl1.SelectedTab);
       }

    }
}