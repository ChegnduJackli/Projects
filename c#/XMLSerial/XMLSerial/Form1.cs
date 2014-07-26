using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace XMLSerial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product pd = new Product();
            //set some properties
            pd.ProductID = 200;
            pd.CategoryID = 100;
            pd.Discontinued = false;
            pd.ProductName = "Serialize Objects";
            pd.QuantityPerUnit = "6";
            pd.ReorderLevel = 1;
            pd.SupplierID = 1;
            pd.UnitPrice = 1000;
            pd.UnitsInStock = 10;
            pd.UnitsOnOrder = 0;
            try
            {
                //new TextWriter and XmlSerializer
                TextWriter tr = new StreamWriter("serialprod.xml");
                XmlSerializer sr = new XmlSerializer(typeof(Product));
                //serialize object
                sr.Serialize(tr, pd);
                tr.Close();
                webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "serialprod.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product newPd;
            //new filestream to open serialized object
            FileStream f = new FileStream("serialprod.xml", FileMode.Open);
            //new serializer
            XmlSerializer newSr = new XmlSerializer(typeof(Product));
            //deserialize the object
            newPd = (Product)newSr.Deserialize(f);
            f.Close();
            MessageBox.Show(newPd.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //create new book and bookproducts objects
            Product newProd = new Product();
            BookProduct newBook = new BookProduct();
            //set som eproperties
            newProd.ProductID = 100;
            newProd.ProductName = "Product Thing";
            newProd.SupplierID = 10;

            newBook.ProductID = 101;
            newBook.ProductName = "How to Use Your New Product Thing";
            newBook.SupplierID = 10;
            newBook.ISBN = "123456789";
            //add the items to an array
            Product[] addProd = { newProd, newBook };
            //new inventory object using the addProd array
            Inventory inv = new Inventory();
            inv.InventoryItems = addProd;
            //serialize the Inventory object
            TextWriter tr = new StreamWriter("order.xml");
            XmlSerializer sr = new XmlSerializer(typeof(Inventory));

            sr.Serialize(tr, inv);
            tr.Close();
            webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "order.xml");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Inventory newInv;
            FileStream f = new FileStream("order.xml", FileMode.Open);
            XmlSerializer newSr = new XmlSerializer(typeof(Inventory));
            newInv = (Inventory)newSr.Deserialize(f);
            foreach (Product prod in newInv.InventoryItems)
            {
                listBox1.Items.Add(prod.ProductName);
            }
            f.Close();
        }
    }
}
