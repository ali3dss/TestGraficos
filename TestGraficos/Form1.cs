using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGraficos
{
    public partial class Form1 : Form
    {

        Bitmap bitmap;
        Graphics grafico;
        Pen plumaNegra;
        Pen plumaRoja;
        Pen plumaAzul;
     
        bool dibujarPolilinea=false;
        bool primerClick = true;

        float xInicio = 0;
        float yInicio = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap= new Bitmap(pictureBox1.Width,pictureBox1.Height);

            pictureBox1.Image= bitmap;

            grafico= Graphics.FromImage(bitmap);

            //CREAMOS LAS PLUMAS:
             plumaNegra = new Pen(Color.Black, 2f);
            plumaRoja = new Pen(Color.Red, 4f);
            plumaRoja = new Pen(Color.Red, 4f);
            plumaAzul = new Pen(Color.Blue, 5f);




        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            grafico.DrawLine(plumaNegra, 10, 10, 200, 200);
            pictureBox1.Invalidate();
          
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            grafico.DrawEllipse(plumaRoja,50,50,60,60);
            pictureBox1.Invalidate();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            grafico.DrawRectangle(plumaAzul, 30, 30, 80, 50);
            pictureBox1.Invalidate();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (dibujarPolilinea == false) { return; }

            if (primerClick)
            {
                xInicio=e.Location.X;
                yInicio=e.Location.Y;

                //DIBUJAMOS PUNTO DE REFERENCIA
                grafico.DrawEllipse(plumaRoja, xInicio, yInicio, 5, 5);
                pictureBox1.Invalidate();

                primerClick = false;

            }
            else
            {
                float xFinal= e.Location.X;
                float yFinal= e.Location.Y;

                grafico.DrawEllipse(plumaRoja, xFinal, yFinal, 5, 5);
                grafico.DrawLine(plumaAzul,xInicio,yInicio,xFinal,yFinal);

                //ACTUALIZAMOS LAS COORDENADAS DE INICIO
                xInicio = xFinal;
                yInicio=yFinal; 

                pictureBox1.Invalidate();

            }


        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //PARA CREAR NUEVA POLILINEA
            primerClick = true;

            dibujarPolilinea = true;

            MessageBox.Show("Dibúje polilínea");

        }
    }
}
