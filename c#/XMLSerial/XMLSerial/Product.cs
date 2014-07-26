using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XMLSerial
{
    [XmlRootAttribute]
    public class Product
    {
        private int prodId;
        private string prodName;
        private int suppId;
        private int catId;
        private string qtyPerUnit;
        private Decimal unitPrice;
        private short unitsInStock;
        private short unitsOnOrder;
        private short reorderLvl;
        private bool discont;
        private int disc;

        //added the Discount attribute
        [XmlAttributeAttribute(AttributeName = "Discount")]
        public int Discount
        {
            get { return disc; }
            set { disc = value; }
        }

        [XmlAttribute]
        public int ProductID
        {
            get { return prodId; }
            set { prodId = value; }
        }
        [XmlAttribute]
        public string ProductName
        {
            get { return prodName; }
            set { prodName = value; }
        }
        [XmlAttribute]
        public int SupplierID
        {
            get { return suppId; }
            set { suppId = value; }
        }

        [XmlAttribute]
        public int CategoryID
        {
            get { return catId; }
            set { catId = value; }
        }

        [XmlAttribute]
        public string QuantityPerUnit
        {
            get { return qtyPerUnit; }
            set { qtyPerUnit = value; }
        }

        [XmlAttribute]
        public Decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        [XmlAttribute]
        public short UnitsInStock
        {
            get { return unitsInStock; }
            set { unitsInStock = value; }
        }

        [XmlAttribute]
        public short UnitsOnOrder
        {
            get { return unitsOnOrder; }
            set { unitsOnOrder = value; }
        }

        [XmlAttribute]
        public short ReorderLevel
        {
            get { return reorderLvl; }
            set { reorderLvl = value; }
        }

        [XmlAttribute]
        public bool Discontinued
        {
            get { return discont; }
            set { discont = value; }
        }
        public override string ToString()
        {
            StringBuilder outText = new StringBuilder();
            outText.Append(prodId);
            outText.Append("\r\n");
            outText.Append(prodName);
            outText.Append("\r\n ");
            outText.Append(unitPrice);
            return outText.ToString();
        }

    }


    public class Inventory
    {
        private Product[] stuff;
        //ctor
        public Inventory() { }
        //need have an attribute entry for each data type
        [XmlArrayItem("Prod", typeof(Product)),
        XmlArrayItem("Book", typeof(BookProduct))]

        public Product[] InventoryItems
        {
            get { return stuff; }
            set { stuff = value; }
        }

        public override string ToString()
        {
            StringBuilder outText = new StringBuilder();
            foreach (Product prod in stuff)
            {
                outText.Append(prod.ProductName);
                outText.Append("\r\n");
            }
            return outText.ToString();
        }
    }

    public class BookProduct : Product
    {
        private string isbnNum;

        public BookProduct() { }

        public string ISBN
        {
            get { return isbnNum; }
            set { isbnNum = value; }
        }

    }
}
