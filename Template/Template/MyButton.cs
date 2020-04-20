using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template
{
    public class MyButton : Button
    {
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), this.ClientRectangle);

            pevent.Graphics.FillEllipse(new LinearGradientBrush(this.ClientRectangle, Color.DeepPink, Color.DarkSlateBlue, 90)
                , this.ClientRectangle);


            this.Parent.Text = c++.ToString();
        }

        int c = 0;

        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                if (value != Color.Pink)
                    base.BackColor = value;
            }
        }
    }
}
