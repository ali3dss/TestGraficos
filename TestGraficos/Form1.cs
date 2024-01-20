using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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


        //TINAS
        SolidBrush tintaAzul;
        SolidBrush tintaGris;
     
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

            //CREAMOS LAS TINTAS

            tintaAzul = new SolidBrush(Color.LightBlue);
            tintaGris= new SolidBrush(Color.LightGray);



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

        private void button2_Click(object sender, EventArgs e)
        {
          grafico.FillEllipse(tintaGris,50,50, 60,60);
            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Vamos a crear un círculo con un relleno texturizado
            // Por lo que crearemos una tinta tipo Hatch
            HatchStyle estilo1 = HatchStyle.BackwardDiagonal;
            HatchStyle estilo2 = HatchStyle.Cross;
            HatchStyle estilo3 = HatchStyle.DashedHorizontal;
            HatchStyle estilo4 = HatchStyle.Wave;

            Color colorTextura= Color.Blue;
            Color colorFondo = Color.LightBlue;


            HatchBrush texturaHatch1 = new HatchBrush(estilo1, colorTextura,colorFondo);
            HatchBrush texturaHatch2 = new HatchBrush(estilo2, colorTextura,colorFondo);
            HatchBrush texturaHatch3 = new HatchBrush(estilo3, colorTextura,colorFondo);
            HatchBrush texturaHatch4= new HatchBrush(estilo4, colorTextura,colorFondo);

            grafico.FillEllipse(texturaHatch1, 200, 100, 100, 100);
            grafico.FillEllipse(texturaHatch2, 200, 200, 100, 100);
            grafico.FillEllipse(texturaHatch3, 200, 300, 100, 100);
            grafico.FillEllipse(texturaHatch4, 200, 400, 100, 100);

            pictureBox1.Invalidate();

            


        }
    }
}
