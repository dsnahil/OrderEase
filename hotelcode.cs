using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
using System.Data; 
using System.Drawing; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
using System.Windows.Forms; 
namespace P9 
{ 
          public partial class Form1 : Form 
{ 
int total = 0, i = 0; 
public Form1() 
{ 
InitializeComponent(); 
} 
private void Form1_Load(object sender, EventArgs e) 
{ 
string[] nm = new string[5];
 int[] pr = new int[5];
 listView1.View = View.Details; 
 listView1.GridLines = true; 
 listView2.Columns.Add("QUANTITY"); 
 listView2.View = View.Details; 
 listView2.GridLines = true; 
 nm[0] = "Pizza"; 
 nm[1] = "Tea"; 
 nm[2] = "Pasta"; 
 nm[3] = "Sandwich"; 
 nm[4] = "Coffee"; 
 pr[0] = 100; 
 pr[1] = 10; 
 pr[2] = 100; 
 pr[3] = 30; 
 pr[4] = 50; 
 for (int i = 0; i < 5; i++) 
 { 
add_items(nm[i], pr[i]); 
 } 
} 
private void button1_Click(object sender, EventArgs e)  { 
 int p, q; 
 string iname; 
 p = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);  q = int.Parse(numericUpDown1.Text); 
iname = listView1.SelectedItems[0].Text; 
listView2.Items.Add(iname); 
listView2.Items[i].SubItems.Add(p.ToString());  listView2.Items[i].SubItems.Add(q.ToString());  i++; 
p = p * q; 
total = total + p; 
label3.Text = total.ToString(); 
label3.Visible = true; 
} 
private void button2_Click(object sender, EventArgs e)  { 
int n = int.Parse(listView2.SelectedItems[0].SubItems[1].Text);  int s = int.Parse(listView2.SelectedItems[0].SubItems[2].Text);  total = total - (n * s); 
listView2.Items.Remove(listView2.SelectedItems[0]);  label3.Text = total.ToString(); 
} 
private void add_items(string name, int p) 
 { 
 ListViewItem l = new ListViewItem(name); 
 l.SubItems.Add(p.ToString()); 
 listView1.Items.Add(l); 
 } 
 } 
}
