using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public interface IErrorModel
    {
        int ErrorNumber
        {
            get;
            set;
        }
        string Description { get; set; }
        void SendMail();
    }

    public class DbError : IErrorModel
    {
        private int _errorNumber;
        private string _description;

        public int ErrorNumber {
            get
            {
                return _errorNumber;
            }
            set
            {
                _errorNumber = value;
            }
        }

        public string Description {
            get
            {
                return _description; 
            }
            set
            {
                _description = value;
            }
        }

        public void SendMail()
        {
            Console.WriteLine("{0}{1} -> Db Hatası Gönderildi.",ErrorNumber.ToString(), Description);
        }
    }

    //Servislerde oluşan hataları bünyesinde tutacak
    public class ServiceError : IErrorModel
    {
        private int _errorNumber;
        private string _description;

        public int ErrorNumber
        {
          get
          {
             return _errorNumber;
          }
          set
          {
             _errorNumber = value;
              
          }
        }

        public string Description
        {
          get
          {
                return _description;
          }
          set
          {
                _description = value;
          }   
        }

        public void SendMail()
        {
            Console.WriteLine("{0]{1} -> Service hatası gönderildi.",ErrorNumber.ToString(), Description);
        }
    }

    //Adapter Class
    public class FaxAdapter : IErrorModel
    {
        private Fax _fax; //adapte edilecek tip
        public FaxAdapter(Fax fax)
        {
            _fax = fax; 
        }

        public int ErrorNumber
        {
            get
            {
                return _fax.FaxErrorCode;
            }
            set
            {
                _fax.FaxErrorCode = value;
            }    
        }
        public string Description
        {
            get
            {
                return _fax.ErrorDescription;
            }
            set
            {
                _fax.ErrorDescription = value;
            }
        }

        public void SendMail()
        {
            Console.WriteLine("{0}{1} -> Fax hatası alındı.", ErrorNumber.ToString(), Description);
        }
    }


    //Adaptee yapısı -> Amacımız bu yapıyı kendi sistemimize adapte etmek
    public class Fax
    {
        public int FaxErrorCode { get; set; }
        public string ErrorDescription {get; set;}

        void Send()
        {

        }

        void Get()
        {

        }


    }
}
