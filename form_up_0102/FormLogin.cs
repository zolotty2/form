
using form_up_0102.Models;

namespace form_up_0102
{
    public partial class FormLogin : Form
    {
        public User CurretUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите логи или пароль","Jшибка",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            using(var db = new ShoeShopDbContext())
            {
                var user = db.Users.Where(w=>w.Login == txtLogin.Text && w.Pass==txtPassword.Text).FirstOrDefault();
                if (user != null)
                {
                    CurretUser = user;
                    IsGuest = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
