namespace form_up_0102
{
    partial class formMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUserName = new Label();
            btnLogout = new Button();
            paneltop = new Panel();
            panelMenu = new Panel();
            btnOrders = new Button();
            btnProducts = new Button();
            paneltop.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Location = new Point(507, 2);
            lblUserName.Margin = new Padding(4, 0, 4, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(45, 19);
            lblUserName.TabIndex = 6;
            lblUserName.Text = "label1";
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.MediumSpringGreen;
            btnLogout.Dock = DockStyle.Right;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(552, 2);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(193, 28);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // paneltop
            // 
            paneltop.Controls.Add(lblUserName);
            paneltop.Controls.Add(btnLogout);
            paneltop.Dock = DockStyle.Top;
            paneltop.Location = new Point(0, 0);
            paneltop.Margin = new Padding(4);
            paneltop.Name = "paneltop";
            paneltop.Padding = new Padding(0, 2, 3, 13);
            paneltop.Size = new Size(748, 43);
            paneltop.TabIndex = 2;
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(btnOrders);
            panelMenu.Controls.Add(btnProducts);
            panelMenu.Dock = DockStyle.Fill;
            panelMenu.Location = new Point(0, 43);
            panelMenu.Margin = new Padding(4);
            panelMenu.Name = "panelMenu";
            panelMenu.Padding = new Padding(51);
            panelMenu.Size = new Size(748, 343);
            panelMenu.TabIndex = 3;
            // 
            // btnOrders
            // 
            btnOrders.BackColor = Color.MediumSpringGreen;
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Location = new Point(55, 196);
            btnOrders.Margin = new Padding(4);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(645, 32);
            btnOrders.TabIndex = 8;
            btnOrders.Text = "Заказы";
            btnOrders.UseVisualStyleBackColor = false;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.MediumSpringGreen;
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Location = new Point(55, 131);
            btnProducts.Margin = new Padding(4);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(645, 32);
            btnProducts.TabIndex = 7;
            btnProducts.Text = "Товары";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // formMenu
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 386);
            Controls.Add(panelMenu);
            Controls.Add(paneltop);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "formMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Меню";
            paneltop.ResumeLayout(false);
            paneltop.PerformLayout();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblUserName;
        private Button btnLogout;
        private Panel paneltop;
        private Panel panelMenu;
        private Button btnOrders;
        private Button btnProducts;
    }
}