using DB_course.Models.CompositModels;
using DB_course.Models;
using DB_course.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Presenter
{
    public class WarehouseAdminPresenter
    {
        private IWarehouseAdminForm view;
        private WarehouseAdminModel model;
        private BindingSource productsBindingSource;
        private IEnumerable<AdminCompose> productList;


        //Constructor
        public WarehouseAdminPresenter(IWarehouseAdminForm view, IModel model)
        {
            this.productsBindingSource = new BindingSource();

            this.view = view;
            this.model = (WarehouseAdminModel)model;


            //Set pets bindind source
            this.view.SetProductListBindingSource(productsBindingSource);
            LoadAllLists();

     

            this.view.Show();
        }
        //Methods
        private void LoadAllLists()
        {
            productList = model.GetProducts();
            productsBindingSource.DataSource = productList;
        }
    }
}
