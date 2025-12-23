namespace form_up_0102
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);

            bool exitProgram = false;
            while (!exitProgram)
            {
                using (var formLogin = new FormLogin())
                {
                    if (formLogin.ShowDialog() == DialogResult.OK)
                    {
                        using (var formProducts = new FormProducts(
                            formLogin.CurretUser,
                            formLogin.IsGuest))
                        {
                            if (formProducts.ShowDialog() == DialogResult.Cancel)
                            {
                                continue;
                            }
                            else
                            {
                                exitProgram = true;
                            }
                        }
                        ;
                    }
                    else
                    {
                        exitProgram = true;
                    }
                }
            }
        }
    }
}