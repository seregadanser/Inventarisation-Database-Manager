using DB_course.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models;
using DB_course.Models.DBModels;
using DB_course.Models.CompositModels;

namespace DB_course.Presenter
{
    public class WarehousemanPresenter
    {
        private IWarehousemanView view;
        private AWarehousemanModel model;
        private BindingSource productsBindingSource;
        private IEnumerable<WarehousemanLookCompose> productList;
        private BindingSource usingBindingSource;
        private IEnumerable<WarehousemanLookCompose> usingList;

        //Constructor
        public WarehousemanPresenter(IWarehousemanView view, IModel model)
        {
            this.productsBindingSource = new BindingSource();
            this.usingBindingSource = new BindingSource();
            this.view = view;
            this.model = (AWarehousemanModel)model;

            
            //Set pets bindind source
          
            this.view.SetUsingListBindingSource(usingBindingSource);
            LoadAllLists();

            this.view.DeleteEvent += DeleteSelectedUseful;


            this.view.Show();
        }
        //Methods
        private void LoadAllLists()
        {
            productsBindingSource.DataSource = productList;
            usingBindingSource.DataSource = usingList;  
        }
        private void SearchProduct(object sender, EventArgs e)
        {
            productList = model.LookWarehousemanLook(view.SearchValue);
            productsBindingSource.DataSource = productList;
        }
       
        private void DeleteSelectedUseful(object sender, EventArgs e)
        {
            try
            {
                var worker = (WorkerLookUsefulCompose)usingBindingSource.Current;
                if (worker == null) throw new Exception("Cant delit empty useful product");
                model.DelitUseful(worker.Inventory_number);
                view.IsSuccessful = true;
                view.Message = "useful deleted successfully";
                usingList = model.LookWarehousemanLook();
                productsBindingSource.DataSource = productList;
                usingBindingSource.DataSource = usingList;

            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
        private void AddNewUsing(object sender, EventArgs e)
        {
            
        }
    }
}
