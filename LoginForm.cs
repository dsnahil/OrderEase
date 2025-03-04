using System;
using System.Windows.Forms;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;

        // A basic login validation (this can be improved with a database of users)
        if (username == "admin" && password == "password")
        {
            MessageBox.Show("Login Successful!");
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
        else
        {
            MessageBox.Show("Invalid credentials!");
        }
    }
}
