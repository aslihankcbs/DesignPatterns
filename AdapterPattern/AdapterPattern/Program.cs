using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Fax fax = new Fax{FaxErrorCode = 4000, ErrorDescription = "Karşı taraftan cevap gelmiyor."};

            IErrorModel[] errors =
            {
                new DbError{ErrorNumber=1000, Description="Bağlantı sağlanamadı." },
                new DbError{ErrorNumber=1001, Description="Sorgulama hatası." },
                new ServiceError{ErrorNumber=3000, Description="Yetki yok." },
                new ServiceError{ErrorNumber=3004,Description="Service bulunamadı." },
                new FaxAdapter(fax)
            };

            foreach (IErrorModel error in errors)
            {
                error.SendMail();
            }
        }
    }
}



