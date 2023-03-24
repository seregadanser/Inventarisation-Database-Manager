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
            this.view.SaveEvent += AddNewProduct;
            this.view.CancelEvent += CancelAction;
            this.view.SearchEvent += SearchProduct;

            this.view.Show();
        }
        //Methods
        private void LoadAllLists()
        {
            productList = model.GetProducts();
            productsBindingSource.DataSource = productList;
        }
        private void SearchProduct(object sender, EventArgs e)
        {
            productList = model.GetProducts(view.SearchValue);
            productsBindingSource.DataSource = productList;
        }
        private void CancelAction(object sender, EventArgs e)
        {
            view.ProductId = 0;
            view.DateCome = "";
            view.PlaceId = "";
            view.InventoryNumber = 0;
            view.DateProduction = "";
            view.ProductName = "";
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

        private void AddNewProduct(object sender, EventArgs e)
        {
            try
            {
                var product = new AdminCompose();
                //product.DateCome = view.DateCome;
                product.ProductId = view.ProductId;
                product.PlaceId = view.PlaceId;
                product.InventoryNumber = view.InventoryNumber;
                //product.DateProduction = view.DateProduction;
                product.Name = view.ProductName;

                model.AddProduct(product);
                view.Message = "product added sucessfully";

                view.IsSuccessful = true;
                productList = model.GetProducts();
                productsBindingSource.DataSource = productList;

                CancelAction(sender, e);

            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
    }
}
