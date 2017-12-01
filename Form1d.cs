using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Cola cabeza;
        Comida comida;
        Comida comida1;
        obstaculo obstaculo;
        obstaculo obstaculo1;
        obstaculo obstaculo2;
        obstaculo obstaculo3;
        int puntaje = 0;
        Graphics g;
        int xdir = 0, ydir = 0;
        int cuadro = 10;
        Boolean ejex = true, ejey = true;
        public Form1()
        {
            InitializeComponent();
            cabeza = new Cola(10, 10);
            comida = new Comida();
            comida1 = new Comida();
            obstaculo = new obstaculo(50,50);
            obstaculo1 = new obstaculo(60,60);
            obstaculo2 = new obstaculo(70,70);
            g = canvas.CreateGraphics();
           
        }
        
        public void movimiento()
        {
            cabeza.setxy(cabeza.verX() + xdir, cabeza.verY() + ydir);
        }

        private void bucle_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            cabeza.dibujar(g);
            comida.dibujar(g);
            comida1.dibujar(g);
            obstaculos();
            obstaculo1.dibujar(g);
            obstaculo2.dibujar(g);
            movimiento();
            choquecuerpo();
            choquepared();
            if (cabeza.interseccion(comida1))
            {
                comida1.colocar();
                cabeza.meter();
                puntaje++;
                puntos.Text = puntaje.ToString();
            }
            if (cabeza.interseccion(comida))
            {
                comida.colocar();
                cabeza.meter();
                puntaje++;
                puntos.Text = puntaje.ToString();
            }
            
        }
        
        public void obstaculos()
        {
            if (cabeza.interseccion(obstaculo1) || cabeza.interseccion(obstaculo2))
            {
                findejuego();
            }
        }
        public void choquepared()
        {
            if(cabeza.verX() < 0 || cabeza.verX() > 770 || cabeza.verY() <0 || cabeza.verY() > 380)
            {
                findejuego();
            }
        }
        public void findejuego()
        {
            puntaje = 0;
            puntos.Text = "0";
            ejex = true;
            ejey = true;
            xdir = 0;
            ydir = 0;
            cabeza = new Cola(10, 10);
            comida = new Comida();
            comida1 = new Comida();
            MessageBox.Show("haz perdido");
        }
        public void choquecuerpo()
        {
            Cola temp;
            try
            {
                temp = cabeza.versiguiente().versiguiente();

            } catch (Exception err)
            {
                temp = null;

            }
            while(temp != null)
            {
                if (cabeza.interseccion(temp))
                {
                    findejuego();
                }else
                {
                    temp = temp.versiguiente();
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ejex)
            {
                if(e.KeyCode == Keys.Up)
                {
                    ydir = -cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
                if(e.KeyCode == Keys.Down)
                {
                    ydir = cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
            }
            if (ejey)
            {
                if(e.KeyCode == Keys.Right)
                {
                    ydir = 0;
                    xdir = cuadro;
                    ejex = true;
                    ejey = false;
                }
                if(e.KeyCode == Keys.Left)
                {
                    ydir = 0;
                    xdir = -cuadro;
                    ejex = true;
                    ejey = false;
                }
            }

        }
    }
}
