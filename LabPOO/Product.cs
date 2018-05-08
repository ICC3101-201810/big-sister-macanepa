using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPOO
{
    public class ProductEventArgs : EventArgs
    {
        public Product product { get; set; }
    }
    [Serializable()]
    public class Product
    {
        private string name;
        private int stock;
        private int price; //Price for one unit of the product
        private string unit;

        //public event EventHandler<ProductEventArgs> AddedProduct;


        //ES AQUI DONDE IMPLEMENTAMOS EL DELEGATE
        public delegate void VideoEncodedEventHandler(object source, ProductEventArgs args);
        public event VideoEncodedEventHandler AddedProduct;


        public Product(string name, int price, int stock, string unit)
        {
            this.name = name;
            this.stock = stock;
            this.price = price;
            this.unit = unit;
        }

        public bool Agregar(List<Product> carrito)
        {
            if (stock > 0)
            {
                carrito.Add(this);
                stock--;

                OnAddedProduct(this);

                return true;



            }
            return false;
        }

        public string Name { get => name; }
        public int Stock { get => stock; }
        public int Price { get => price; }
        public string Unit { get => unit; }


        protected virtual void OnAddedProduct(Product product)
        {
            if (AddedProduct != null)
            {
                AddedProduct(this, new ProductEventArgs() { product = this });
            }
        }





    }
}
