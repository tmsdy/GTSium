using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
//using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

namespace Silt.Base.Common
{
    public class Img
    {
        public Img()
		{
			///
			/// TODO: �ڴ˴���ӹ��캯���߼�
			///
           
		}
        /*
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        //����ͼ��
        public void inImg(PictureBox picBox)
        {
            Stream ms;
            byte[] picbyte;
            openFileDialog1.Filter = "BMP�ļ�(*.bmp)|*.bmp|�����ļ�(*.*)|*.*";
            saveFileDialog1.Title = "����ͼ��";
            saveFileDialog1.InitialDirectory = @"c:\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((ms = openFileDialog1.OpenFile()) != null)
                {
                    try
                    {
                        picbyte = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(picbyte, 0, Convert.ToInt32(ms.Length));
                        Bitmap bmp = new Bitmap(Bitmap.FromStream(ms));
                        //this.pictureBoxFCHARTER.Image = bmp;
                        picBox.Image = bmp;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        //����ͼ��
        public void outImg(PictureBox picBox)
        {
            string str;
            saveFileDialog1.Filter = "BMP�ļ�(*.bmp)|*.bmp|�����ļ�(*.*)|*.*";
            saveFileDialog1.Title = "����ͼ��";
            saveFileDialog1.InitialDirectory = @"c:\";
            if ((saveFileDialog1.ShowDialog()) == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != null)
                {
                    try
                    {
                        Bitmap box1 = new Bitmap(picBox.Image);
                        //Graphics g = this.CreateGraphics();
                        str = saveFileDialog1.FileName;
                        picBox.Image.Save(str);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        //���ͼ��
        public void nullImg(PictureBox picBox)
        {
            try
            {
                picBox.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/
    }
}
