using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using ProductsList_Command_MVVM_WpfApp2.mvvm;
using ProductsList_Command_MVVM_WpfApp2.My_Work.Model;

namespace ProductsList_Command_MVVM_WpfApp2.MVVM.ViewModel
{

    public class MainVM : Changed
    {
        public List<Product> Products { get; set; }
        public List<Manufactorer> Manufactorers { get; set; } = new();
        public Command StartFilter { get; private set; }
        public Command EndFilter { get; private set; }
        public List<Category> Categories { get; set; } = new();

        public Manufactorer SelectedManufactorer { get; set; }
        public Category SelectedCategory { get; set; }

        public MainVM()
        {
            Products = Get().ToList();
            Signal(nameof(Products));
            Categories = DB.GetInstance().Categories.ToList();
            Manufactorers = DB.GetInstance().Manufactorers.ToList();

            StartFilter = new Command(() =>
            {
                var list = Get();
                if (SelectedCategory != null)
                {
                    list = list.Where(s => s.Idcategory == 
                    SelectedCategory.Id).ToList();
                }
                if(SelectedManufactorer != null)
                {
                    list = list.Where(s => s.Idmanufactorer == 
                    SelectedManufactorer.Id).ToList();
                }
                Products = list.ToList();
                Signal(nameof(Products));
            }) ;
            
            EndFilter = new Command(() =>
            {
                Products = Get().ToList();
                Signal(nameof(Products));
                SelectedCategory = null;
                SelectedManufactorer = null;
                Signal(nameof(SelectedCategory));
                Signal(nameof(SelectedManufactorer));
            });
        }
        List<Product> Get()
        {
            var list = DB.GetInstance().Products.
                Include(s => s.IdcategoryNavigation).
                Include(s => s.IddiscountNavigation).
                Include(s => s.IdmanufactorerNavigation
                ).ToList();
            return list;
        }
    }
}
