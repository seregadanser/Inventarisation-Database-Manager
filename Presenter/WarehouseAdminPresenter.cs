using DB_course.Models.CompositModels;
using DB_course.Models;
using DB_course.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models.DBModels;

namespace DB_course.Presenter
{
    public class WarehouseAdminPresenter
    {
        private IWarehouseAdminView view;
        private WarehouseAdminModel model;
        private BindingSource productsBindingSource;
        private IEnumerable<AdminCompose> productList;


        //Constructor
        public WarehouseAdminPresenter(IWarehouseAdminView view, IModel model)
        {
            this.productsBindingSource = new BindingSource();

            this.view = view;
            this.model = (WarehouseAdminModel)model;


            //Set pets bindind source
            this.view.SetProductListBindingSource(productsBindingSource);
            LoadAllLists();

            this.view.DeleteEvent += DeleteSelectedWorker;

            this.view.Show();
        }
        //Methods
        private void LoadAllLists()
        {
            productList = model.GetProducts();
            productsBindingSource.DataSource = productList;
        }
        private void DeleteSelectedWorker(object sender, EventArgs e)
        {
            try
            {
                var worker = (AdminCompose)productsBindingSource.Current;
                if(worker == null)
                    throw new Exception("Cant delit empty person");
                model.RemoveProduct(worker);
                view.IsSuccessful = true;
                view.Message = "worker deleted successfully";
                productList = model.GetProducts();
                productsBindingSource.DataSource = productList;

            }
            catch(Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

    }
}
