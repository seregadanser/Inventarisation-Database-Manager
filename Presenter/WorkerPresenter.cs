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
    public class WorkerPresenter
    {
        private IWorkerView view;
        private WorkerModel model;
        private BindingSource productsBindingSource;
        private IEnumerable<WorkerLookCompose> productList;
        private BindingSource usingBindingSource;
        private IEnumerable<WorkerLookUsefulCompose> usingList;

        //Constructor
        public WorkerPresenter(IWorkerView view, IModel model)
        {
            this.productsBindingSource = new BindingSource();
            this.usingBindingSource = new BindingSource();
            this.view = view;
            this.model = (WorkerModel)model;

            
            //Set pets bindind source
            this.view.SetProductsListBindingSource(productsBindingSource);
            this.view.SetUsingListBindingSource(usingBindingSource);
            LoadAllLists();

            this.view.SearchEvent += SearchProduct;

            this.view.Show();
        }
        //Methods
        private void LoadAllLists()
        {
            productList = model.LookProducts();
            usingList = model.LookUsing();
            productsBindingSource.DataSource = productList;
            usingBindingSource.DataSource = usingList;  
        }
        private void SearchProduct(object sender, EventArgs e)
        {
            productList = model.LookProducts(view.SearchValue);
            productsBindingSource.DataSource = productList;
        }
       
        private void DeleteSelectedPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void AddNewPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
