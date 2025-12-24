using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using form_up_0102.Models;
using form_up_0102.Properties;
using Microsoft.EntityFrameworkCore;

namespace form_up_0102
{
    public partial class formOrders : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public formOrders(User user, bool isGuest)
        {
            InitializeComponent();

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "Информация о заказе";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colOrderDate = new DataGridViewTextBoxColumn();
            colOrderDate.Name = "Дата доставки";
            colOrderDate.FillWeight = 15;
            colOrderDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.AddRange(
            [
                colInfo, colOrderDate
            ]);

            CurrentUser = user;
            IsGuest = isGuest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.fullName;
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                using (var db = new ShoeShopDbContext())
                {
                    
                    var orders = db.Orders
                        .Include(i => i.Status)
                        .Include(i => i.DeliveryPoint)
                        .Include(i => i.ProductsOrders)
                            .ThenInclude(po => po.Product)
                        .ToList();

                    var ordersByCode = new Dictionary<int, List<Order>>();

                    foreach (var order in orders)
                    {
                        if (!ordersByCode.ContainsKey(order.Code))
                        {
                            ordersByCode[order.Code] = new List<Order>();
                        }
                        ordersByCode[order.Code].Add(order);
                    }

                    dgvOrders.SuspendLayout();
                    dgvOrders.Rows.Clear();

                   
                    foreach (var orderGroup in ordersByCode)
                    {
                        int rowIndex = dgvOrders.Rows.Add();
                        var row = dgvOrders.Rows[rowIndex];

                        
                        var firstOrder = orderGroup.Value[0];

                        
                        var allArticleNumbers = new List<string>();
                        foreach (var order in orderGroup.Value)
                        {
                            foreach (var productOrder in order.ProductsOrders)
                            {
                                allArticleNumbers.Add(productOrder.Product.Art);
                            }
                        }

                        
                        var uniqueArticleNumbers = new HashSet<string>(allArticleNumbers);

                        row.Cells["Информация о заказе"].Value = FormatOrderInfo(firstOrder, uniqueArticleNumbers);
                        row.Cells["Дата доставки"].Value = $"{firstOrder.DeliveryDate}";
                        row.Cells["Дата доставки"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }

                    dgvOrders.ResumeLayout();
                    dgvOrders.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatOrderInfo(Order order, HashSet<string> articleNumbers)
        {
            string articlesString = string.Join(", ", articleNumbers);
            return $"Артикул заказа: {articlesString}" + Environment.NewLine +
                   $"Статус: {order.Status.StatusName}" + Environment.NewLine +
                   $"Адрес пункта выдачи: {order.DeliveryPoint.DeliveryAddress}" + Environment.NewLine +
                   $"Дата заказа: {order.OrderDate}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }
    }
}