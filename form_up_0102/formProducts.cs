using form_up_0102.Models;
using form_up_0102.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace form_up_0102
{
    public partial class FormProducts : Form
    {
        public User CurretUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormProducts(User user, bool IsGuest)
        {
            InitializeComponent();
            var colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "Фото товара";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 200;
            colPhoto.FillWeight = 30;

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "Информация о товаре";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colDiscount = new DataGridViewTextBoxColumn();
            colDiscount.Name = "Скидка";
            colDiscount.FillWeight = 60;
            colDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.AddRange(
            [
                colPhoto,colInfo,colDiscount
            ]);
            CurretUser = user;
            IsGuest = IsGuest;

            lblUserName.Text = IsGuest ? "Гость" : CurretUser.fullName;
            LoadProducts();
        }


        private void LoadProducts()
        {
            try
            {
                using (var db = new ShoeShopDbContext())
                {
                    var products = db.Products
                        .Include(i => i.Category)
                        .Include(i => i.Manufacturer)
                        .Include(i => i.Supplier)
                        .Include(i => i.Measure)
                        .ToList();

                    dgvProducts.SuspendLayout();
                    dgvProducts.Rows.Clear();
                    foreach (var product in products)
                    {
                        int rowIndex = dgvProducts.Rows.Add();
                        var row = dgvProducts.Rows[rowIndex];

                        row.Cells["Фото товара"].Value = LoadProductImage(product.PhotoUrl);

                        row.Cells["Информация о товаре"].Value = FormatProductInfo(product);

                        row.Cells["Скидка"].Value = $"{product.Discount}%";
                        row.Cells["Скидка"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        ApplyRowStyles(row, product);
                    }
                    dgvProducts.ResumeLayout();
                    dgvProducts.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ApplyRowStyles(DataGridViewRow row, Product product)
        {
            if (product.Discount > 15)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2E8B57");
                row.DefaultCellStyle.ForeColor = Color.White;
            }
            if (product.CointInStock <= 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightBlue;

                if (product.Discount <= 15)
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            if (product.Discount > 0)
            {
                row.Cells["Скидка"].Style.ForeColor = Color.Red;
                row.Cells["Скидка"].Style.Font = new Font(
                    "Times New Roman",
                    12,
                    FontStyle.Bold);
            }
        }

        private string FormatProductInfo(Product product)
        {
            string priceText;
            if (product.Discount > 0)
            {
                decimal finalProce = product.Price * (100 - product.Discount) / 100;
                priceText = $"Цена {product.Price:C} -> {finalProce:C}";
            }
            else
            {
                priceText = $"Цена {product.Price:C}";
            }
            return $"Категория товара: {product.Description}| {product.ProductType}" + Environment.NewLine +
                $"Информация о производителе: {product.Manufacturer.ManufacturerName}" + Environment.NewLine +
                $"Поставщик: {product.Supplier.SupplierName}" + Environment.NewLine +
                $"Цена товара: {priceText}" + Environment.NewLine +
                $"Еденица измерения: {product.Measure.MeasureName}" + Environment.NewLine +
                $"Количество на складе: {product.CointInStock}";
        }

        private Image LoadProductImage(string photoUrl)
        {
            if (!String.IsNullOrEmpty(photoUrl) && System.IO.File.Exists(photoUrl))
            {
                return Image.FromFile(photoUrl);
            }
            Bitmap bmp = new Bitmap(150, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.DrawRectangle(Pens.LightGray, 0, 0, 149, 99);

            }

            return Resources.Picture;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
