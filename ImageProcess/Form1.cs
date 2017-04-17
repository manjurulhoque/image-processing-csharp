using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace ImageProcess
{
    public partial class Form1 : Form
    {
        private Bitmap image;
        private IFilter sharpern = new Sharpen();
        private IFilter gaussianblur = new GaussianBlur();
        private IFilter sepia = new Sepia();
        private IFilter oilpainting = new OilPainting();
        private IFilter invert = new Invert();
        private IFilter grasycle = new Grayscale(0.2125, 0.7154, 0.0721);
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(ofd.FileName);
                pictureBox1.Image = image;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        image.Save(sfd.FileName);
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
            }
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = sharpern.Apply(image);
            pictureBox1.Image = image;
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = gaussianblur.Apply(image);
            pictureBox1.Image = image;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = sepia.Apply(image);
            pictureBox1.Image = image;
        }

        private void oilPaintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = oilpainting.Apply(image);
            pictureBox1.Image = image;
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = invert.Apply(image);
            pictureBox1.Image = image;
        }

        private void grasycleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = grasycle.Apply(image);
            pictureBox1.Image = image;
        }
        private IFilter jitter = new Jitter();
        private void jitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = jitter.Apply(image);
            pictureBox1.Image = image;
        }

        private IFilter brightness = new BrightnessCorrection();
        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = brightness.Apply(image);
            pictureBox1.Image = image;
        }
        private IFilter contrast = new ContrastCorrection();
        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = contrast.Apply(image);
            pictureBox1.Image = image;
        }
        private IFilter saturation = new SaturationCorrection();
        private void saturationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = saturation.Apply(image);
            pictureBox1.Image = image;
        }
    }
}
