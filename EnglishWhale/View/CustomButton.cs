using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishWhale.View
{
    class CustomButton : Button
    {
        public CustomButton()
        {
            this.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FlatStyle = FlatStyle.Flat;
            this.ForeColor = System.Drawing.Color.White;
            this.Image = global::EnglishWhale.Properties.Resources.button_back;
            this.MouseDown += new MouseEventHandler(this.button_MouseDown);
            this.MouseEnter += new EventHandler(this.button_MouseEnter);
            this.MouseLeave += new EventHandler(this.button_MouseLeave);
            this.MouseUp += new MouseEventHandler(this.button_MouseUp);
        }
        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Image = global::EnglishWhale.Properties.Resources.button_back_mouse_enter;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Image = global::EnglishWhale.Properties.Resources.button_back;
            btn.ForeColor = System.Drawing.Color.White;
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.Image = global::EnglishWhale.Properties.Resources.button_back_mouse_clicked;
            btn.ForeColor = System.Drawing.Color.Black;
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.Image = global::EnglishWhale.Properties.Resources.button_back;
            btn.ForeColor = System.Drawing.Color.White;
        }

    }
}
