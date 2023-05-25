using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsList_Command_MVVM_WpfApp2.My_Work.Model;

namespace ProductsList_Command_MVVM_WpfApp2.mvvm
{
    public class DB
    {
        static ProductslistCommandMvvmDbContext instance;
        public static ProductslistCommandMvvmDbContext GetInstance()
        {
            if (instance == null)
                instance = new ProductslistCommandMvvmDbContext();
            return instance;
        }
    }
}
