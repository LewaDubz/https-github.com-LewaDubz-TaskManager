using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        List<ProcessClass> processClassList = new List<ProcessClass>();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                try
                {
                    processClassList.Add(new ProcessClass(theprocess.ProcessName, theprocess.Id, theprocess.VirtualMemorySize64, theprocess.StartTime, (DateTime.Now - theprocess.StartTime), theprocess.Threads));
                }
                catch (Exception) { }
            }
            foreach (ProcessClass process in processClassList)
            {
                listBox1.Items.Add(process.Name);
                Console.WriteLine(process.Name);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var processName = listBox1.SelectedItem;
            long totalMemoryUsage = 0;
            Console.WriteLine(processName);
            label2.Text = "MemoryUsage:";
            label3.Text = "StartTime:";
            label4.Text = "Runtime:";
            label5.Text = "TotalMemoryUsage:";
            foreach (ProcessClass process in processClassList)
            {
                if (process.Name.Equals(processName))
                {
                    foreach (System.Diagnostics.ProcessThread thread in process.Threads)
                    {
                        listBox2.Items.Add(thread.Id.ToString());
                    }
                    totalMemoryUsage += process.MemoryUsage;
                    label2.Text += "\n" + (((process.MemoryUsage / 1024) / 1024) / 100) + "MB";
                    label3.Text += "\n" + process.StartTime;
                    label4.Text += "\n" + (DateTime.Now - process.StartTime);
                    textBox1.Text = process.Commentary;
                }

            }
            label5.Text += "\n" + totalMemoryUsage / 1024 / 1024 / 100 + "MB";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var processName = listBox1.SelectedItem;
            foreach (ProcessClass process in processClassList)
            {
                if (process.Name.Equals(processName))
                {
                    process.Commentary = textBox1.Text;         
                    textBox1.Text = process.Commentary;
                }
            }
        }


    }
}
