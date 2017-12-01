using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class obstaculo : objeto
    {
        public obstaculo(int posicionX, int posicionY)
        {
            this.x = posicionX;
            this.y = posicionY;
        }
        public void dibujar(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Yellow), this.x, this.y, this.ancho, this.ancho);
        }
    }
}
