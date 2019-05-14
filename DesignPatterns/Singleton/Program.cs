using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();


        //private constructor
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            //multithred programlama da aynı nesneden iki tanesini önlemek için defensive programming 
            //birisibu nesneyi üretme aşamasına geçer ve isterse ben bu nesneyi kilitleyeym kuulanıcıya cevap ver sonra cevap ver

            //eğer customer manager dan oluşturulmuş olan varsa oluşturulmuşu ver
            //null olup olmadığına bak null değilse customer manager ı döndür null ise create et
            //return _customerManager ?? (_customerManager = new CustomerManager());

            lock (_lockObject)
            {
                if(_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
               
            }
            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }
}
