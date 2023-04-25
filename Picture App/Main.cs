using System.Drawing.Imaging;

namespace Picture_App
{
    public partial class Main : Form
    {

        string picturePath = "";
        string markPath = "";

        public Main()
        {
            InitializeComponent();
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            picturePath = InserPictureBox(pbPicture);
        }

        private void btnDeletePicture_Click(object sender, EventArgs e)
        {
            pbPicture.Image = null;
            picturePath = "";
            ButtonsVisibility();
        }

        private void btnSafe_Click(object sender, EventArgs e)
        {
            if (pbPicture.Image != null && pbMark.Image != null)
            {
                Image originalImage = Image.FromFile(picturePath);
                Image watermarkImage = Image.FromFile(markPath);

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
            markPath = InserPictureBox(pbMark);
        }

        private void btnDeleteMark_Click(object sender, EventArgs e)
        {
            pbMark.Image = null;
            markPath = "";
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
                pictureBox.Image = Image.FromFile(picturePath);
                ButtonsVisibility();
            }
            return path;
        }

        void ButtonsVisibility()
        {
            btnDeleteMark.Visible = !string.IsNullOrEmpty(markPath);
            btnDeletePicture.Visible = !string.IsNullOrEmpty(picturePath);
            btnSafe.Visible = (!string.IsNullOrEmpty(markPath) && !string.IsNullOrEmpty(picturePath));
        }

        string SaveImage(Image mergeImage)
        {
            var mergedImagePath = Path.Combine(Path.GetDirectoryName(picturePath),
                Path.GetFileNameWithoutExtension(picturePath) + "_merged" + Path.GetExtension(picturePath));
            mergeImage.Save(mergedImagePath, pbPicture.Image.RawFormat);

            return mergedImagePath;
        }
    }
}