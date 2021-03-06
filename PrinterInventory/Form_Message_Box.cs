﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PrinterInventory
{
    public partial class Form_Message_Box : Form
    {

        Main parent;
        bool Allow_Close_ = true;
        string LabelString = "";

       // public Form_Message_Box(Receipt _parent, string Label_Text, bool Allow_Close = true, int grow_height = 0, Point g = new Point(), Size s = new Size())
        public Form_Message_Box(Main _parent, string Label_Text, bool Allow_Close, int grow_height, Point g = new Point(), Size s = new Size())
        {
            LabelString = Label_Text;
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            label1.Text = Label_Text;
            parent = _parent;
            Allow_Close_ = Allow_Close;
            this.Height += grow_height;
            parent.Grey_Out();

            this.Location = new Point(g.X + (s.Width / 2) - (this.Width / 2), g.Y + (s.Height / 2) - (this.Height / 2));
        }

        // Form mnemonics
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    {
                        close_button.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            // Mousedown anywhere to drag
            //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            //this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            if (!Allow_Close_) close_button.Visible = false;

            //if ((LabelString.Contains("Cannot overwrite existing Excel document. ") || LabelString == "Generating Excel File") && custom_Location != null) this.Location = custom_Location;
            //this.Location = new Point(-150, -150);

        }

        private void minimize_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            parent.Grey_In();
            try
            {
                parent.Focus();
            }
            catch
            {
                // parent not active;
            }
            this.Dispose();
            this.Close();
        }

        public void Set_Form_Color(Color randomColor)
        {
            //minimize_button.ForeColor = randomColor;
            //close_button.ForeColor = randomColor;
            textBox1.BackColor = randomColor;
            textBox2.BackColor = randomColor;
            textBox3.BackColor = randomColor;
            textBox4.BackColor = randomColor; 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Close_Form()
        {
            parent.Grey_In();
            this.Dispose();
            this.Close();
        }
    }
}
