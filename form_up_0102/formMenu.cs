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
    public partial class formMenu : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public formMenu(User user, bool isGuest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = isGuest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.fullName;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenProductsForm();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenOrdersForm();
        }

        private void OpenProductsForm()
        {
            this.Hide(); 

            using (var formProducts = new FormProducts(CurrentUser, IsGuest))
            {
                formProducts.ShowDialog();
            }

            this.Show(); 
        }

        private void OpenOrdersForm()
        {
            this.Hide(); 

            using (var formOrders = new formOrders(CurrentUser, IsGuest))
            {
                formOrders.ShowDialog();
            }

            this.Show(); 
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
    }
}