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
    public partial class formProducts : Form
    {
        public User CurretUser { get; private set; }
        public bool IsGuest { get; private set; }

        public formProducts(User user, bool IsGuest)
        {
            InitializeComponent();
            var colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "colPhoto";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 200;
            colPhoto.FillWeight = 30;

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colDiscount = new DataGridViewTextBoxColumn();
            colDiscount.Name = "colDiscount";
            colDiscount.FillWeight = 60;
            colDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.AddRange(
            [
                colPhoto,colInfo,colDiscount
            ]);
            CurretUser = user;
            IsGuest = IsGuest;

            lblUserName.Text = IsGuest ? "гость" : CurretUser.fullName;
            LoadProducts();
            }
            
            
        private void LoadProducts(){
            try
            {
                using (var db = new ShoeShopDbContext())
                {
                    var products = db.Products
                        .Include(i => i.Categores)
                        .Include(i => i.Manufacturers)
                        .Include(i => i.Suppliers)
                        .Include(i => i.Measures)
                        .ToList();
                    
                    dgvProducts.SuspendLayout();
                    dgvProducts.Rows.Clear();
                    foreach (var product in products)
                    {
                        int rowIndex = dgvProducts.Rows.Add();
                        var row = dgvProducts.Rows[rowIndex];

                        row.Cells["colPhoto"].Value = LoadProductImage(product.PhotoUrl);
                        row.Cells["colInfo"].Value = FormatProductInfo(product);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
                
        }

        private string FormatProductInfo(Product product)
        {
            string priceText;
            if (product.Discount > 0)
            {
                decimal finalProce = product.Price* (100 - product.Discount)/100;
                priceText = $"Цена {product.Price:C} -> { finalProce:C}";
            }
            else  
            {
                priceText = $"Цена {product.Price:C}";
            }
            return $"Категория товара: {product.Description}| {product.ProductTypes}" + Environment.NewLine +
                $"Информация о производителе:{product.Manufacturers}" + Environment.NewLine +
                $"Поставщик:{product.Suppliers.SupplierName}" + Environment.NewLine +
                $"Цена товара:{priceText}" + Environment.NewLine +
                $"Еденица измерения:{product.Measures.MeasureName}" + Environment.NewLine +
                $"Количество на складе:{product.CointInStock}";
        }

        private Image LoadProductImage(string photoUrl)
            {
                if (!String.IsNullOrEmpty(photoUrl)&& System.IO.File.Exists(photoUrl))
                {
                    return Image.FromFile(photoUrl);
                }
                Bitmap bmp = new Bitmap(150,100);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.DrawRectangle(Pens.LightGray, 0, 0, 149, 99);
                    
                }

            return Resources.Picture;
            }
    }
}
