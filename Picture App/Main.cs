using System.Drawing.Imaging;

namespace Picture_App
{
    public partial class Main : Form
    {

        string _picturePath = "";
        string _markPath = "";

        public Main()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.PicturePath))
            {
                _picturePath = Properties.Settings.Default.PicturePath;
                Properties.Settings.Default.PicturePath = null;
                pbPicture.Image = Image.FromFile(_picturePath);
            }

            if (!string.IsNullOrEmpty(Properties.Settings.Default.MarkPath))
            {
                _markPath = Properties.Settings.Default.MarkPath;
                Properties.Settings.Default.MarkPath = null;
                pbMark.Image = Image.FromFile(_markPath);
            }

            ButtonsVisibility();
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            _picturePath = InserPictureBox(pbPicture);
            ButtonsVisibility();
        }

        private void btnDeletePicture_Click(object sender, EventArgs e)
        {
            pbPicture.Image = null;
            _picturePath = "";
            ButtonsVisibility();
        }

        private void btnSafe_Click(object sender, EventArgs e)
        {
            if (pbPicture.Image != null && pbMark.Image != null)
            {
                Image originalImage = Image.FromFile(_picturePath);
                Image watermarkImage = Image.FromFile(_markPath);

                float transparency = 0.2f;
                ColorMatrix colorMatrix = new ColorMatrix();
                colorMatrix.Matrix33 = transparency;

                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                int x = originalImage.Width - watermarkImage.Width - 10;
                int y = originalImage.Height - watermarkImage.Height - 10;

                using (Graphics g = Graphics.FromImage(originalImage))
                {
                    g.DrawImage(watermarkImage, new Rectangle(x, y, watermarkImage.Width, watermarkImage.Height),
                        0, 0, watermarkImage.Width, watermarkImage.Height, GraphicsUnit.Pixel, imageAttributes);
                }

                var path = SaveImage(originalImage);

                MessageBox.Show($"Zapisano po³¹czony obraz w pliku {path}", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nie wybrano obrazu lub znaku wodnego.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddMark_Click(object sender, EventArgs e)
        {
            _markPath = InserPictureBox(pbMark);
            ButtonsVisibility();
        }

        private void btnDeleteMark_Click(object sender, EventArgs e)
        {
            pbMark.Image = null;
            _markPath = "";
            ButtonsVisibility();
        }
        string InserPictureBox(PictureBox pictureBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki obrazów (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            string path = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                pictureBox.Image = Image.FromFile(path);
            }
            return path;
        }

        void ButtonsVisibility()
        {
            btnDeleteMark.Visible = !string.IsNullOrEmpty(_markPath);
            btnDeletePicture.Visible = !string.IsNullOrEmpty(_picturePath);
            btnSafe.Visible = (!string.IsNullOrEmpty(_markPath) && !string.IsNullOrEmpty(_picturePath));
        }

        string SaveImage(Image mergeImage)
        {
            var mergedImagePath = Path.Combine(Path.GetDirectoryName(_picturePath),
                Path.GetFileNameWithoutExtension(_picturePath) + "_merged" + Path.GetExtension(_picturePath));
            mergeImage.Save(mergedImagePath, pbPicture.Image.RawFormat);

            return mergedImagePath;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pbPicture.Image != null)
                Properties.Settings.Default.PicturePath = _picturePath;

            if (pbMark.Image != null)
                Properties.Settings.Default.MarkPath = _markPath;

            Properties.Settings.Default.Save();

        }
    }
}