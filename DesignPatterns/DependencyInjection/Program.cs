using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new ProductDal());
            productManager.Save();
        }
    }

    interface IProductDal
    {
        void Save();
    }

    class ProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF");
        }
        
    }

    class ProductManager
    {
        #region dependency injection ile
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        #endregion

        //business code
        public void Save()
        {
            #region dependency injection olmadan
            //ProductDal productDal = new ProductDal();
            //productDal.Save();
            #endregion

            _productDal.Save();

        }

    }
}
