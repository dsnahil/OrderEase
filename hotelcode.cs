using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace OrderEase
{
    public partial class MainForm : MetroForm
    {
        private int totalAmount = 0;
        private ImageList imageList;
        
        public MainForm()
        {
            InitializeComponent();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog(); // Block until login form is closed
            if (loginForm.DialogResult != DialogResult.OK)
            {
                Application.Exit(); // Exit if login fails
            }
            InitializeMenu();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
        }

        private void InitializeMenu()
        {
            string[] foodItems = { "Pizza", "Tea", "Pasta", "Sandwich", "Coffee" };
            int[] prices = { 100, 10, 100, 30, 50 };
            imageList = new ImageList();
            
            // Adding images for food items (replace with actual image paths)
            imageList.Images.Add(Image.FromFile("pizza.png"));
            imageList.Images.Add(Image.FromFile("tea.png"));
            imageList.Images.Add(Image.FromFile("pasta.png"));
            imageList.Images.Add(Image.FromFile("sandwich.png"));
            imageList.Images.Add(Image.FromFile("coffee.png"));
            listViewMenu.SmallImageList = imageList;
    
            var orders = databaseManager.GetOrders();
            foreach (var order in orders)
            {
                ListViewItem orderItem = new ListViewItem(order.ItemName);
                orderItem.SubItems.Add(order.Price.ToString());
                orderItem.SubItems.Add(order.Quantity.ToString());
                listViewOrder.Items.Add(orderItem);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (listViewMenu.SelectedItems.Count == 0) return;
            int price = int.Parse(listViewMenu.SelectedItems[0].SubItems[1].Text);
            int quantity = (int)numericUpDownQuantity.Value;
            string itemName = listViewMenu.SelectedItems[0].Text;
            
            ListViewItem orderItem = new ListViewItem(itemName);
            orderItem.SubItems.Add(price.ToString());
            orderItem.SubItems.Add(quantity.ToString());
            listViewOrder.Items.Add(orderItem);
            
            totalAmount += price * quantity;
            lblTotal.Text = $"Total: {totalAmount} INR";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count == 0) return;
            int price = int.Parse(listViewOrder.SelectedItems[0].SubItems[1].Text);
            int quantity = int.Parse(listViewOrder.SelectedItems[0].SubItems[2].Text);
            
            totalAmount -= price * quantity;
            listViewOrder.Items.Remove(listViewOrder.SelectedItems[0]);
            lblTotal.Text = $"Total: {totalAmount} INR";
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            this.Theme = this.Theme == MetroFramework.MetroThemeStyle.Dark 
                ? MetroFramework.MetroThemeStyle.Light 
                : MetroFramework.MetroThemeStyle.Dark;
        }
    }
}
