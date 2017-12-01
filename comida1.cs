using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class Comida1 : objeto
    {
        public Comida1()
        {
            this.x = generar(70);
            this.y = generar(30);
        }
        public void dibujar(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Black), this.x, this.y, this.ancho, this.ancho);
        }
        public void colocar()
        {
            this.x = generar(70);
            this.y = generar(30);
        }
        public int generar(int n)
        {
            Random random = new Random();
            int num = random.Next(0, n) * 5;
            return num;
        }

    }
}
 
