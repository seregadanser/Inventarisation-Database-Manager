using DB_course.Models.CompositModels;
using DB_course.Models;
using DB_course.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models.DBModels;
using System.Globalization;

namespace DB_course.Presenter
{
    public class WarehouseAdminPresenter
    {
        private IWarehouseAdminView view;
        private WarehouseAdminModel model;
        private BindingSource productsBindingSource;
        private IEnumerable<AdminCompose> productList;
        private BindingSource placesBindingSource;
        private IEnumerable<Place> placesList;

        //Constructor
        public WarehouseAdminPresenter(IWarehouseAdminView view, IModel model)
        {
            this.productsBindingSource = new BindingSource();
            placesBindingSource = new BindingSource();

            this.view = view;
            this.model = (WarehouseAdminModel)model;


            //Set pets bindind source
            this.view.SetProductListBindingSource(productsBindingSource);
            this.view.SetPlaceListBindingSource(placesBindingSource);
            LoadAllLists();

            this.view.DeleteEvent += DeleteSelectedProduct;
            this.view.SaveEvent += AddNewProduct;
            this.view.CancelEvent += CancelAction;
            this.view.SearchEvent += SearchProduct;

            this.view.Show();
        }
        //Methods

        private void SearchWorker(object sender, EventArgs e)
        {
            placesList = model.GetPlace();
            placesBindingSource.DataSource = placesList;

        }
        private void PlaceCancelAction(object sender, EventArgs e)
        {
            view.PlaceId1 = "";
            view.PlaceLayer = "";
            view.PlaceSize = "";
            view.PlaceStay = "";
        }
        private void SaveWorker(object sender, EventArgs e)
        {
            try
            {
                var person = new Person();
                person.Name = view.WorkerName;
                person.SecondName = view.WorkerSecondName;
                person.Position = view.WorkerPosition;
                person.DateOfBirthday = null;


                if (view.IsEdit)
                {
                    person.Login = log;
                    person.Password = pass;
                    person.NumberOfCome = count;
                    model.UpdatePerson(log, person);
                    view.Message = "worker edited successfuly";
                }
                else
                {
                    person.Login = view.WorkerLogin;
                    person.Password = Hash.HashFunc(view.WorkerPassword);
                    person.NumberOfCome = 0;
                    model.AddPerson(person);
                    view.Message = "worker added sucessfully";
                }

                view.IsSuccessful = true;
                personList = model.LookPerson();
                workersBindingSource.DataSource = personList;

                view.WorkerSecondName = "";
                view.WorkerPosition = "";
                view.WorkerName = "";
                view.WorkerBirthday = "";
                view.WorkerLogin = "";
                view.WorkerPassword = "";
                view.WorkerLogin = "";

            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
        private void DeleteSelectedWorker(object sender, EventArgs e)
        {
            try
            {
                var worker = (Person)workersBindingSource.Current;
                if (worker == null) throw new Exception("Cant delit empty person");
                model.RemovePerson(worker.Login);
                view.IsSuccessful = true;
                view.Message = "worker deleted successfully";
                personList = model.LookPerson();
                workersBindingSource.DataSource = personList;

            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
        private void LoadSelectedPlaceToEdit(object sender, EventArgs e)
        {
            try
            {
                Place worker = (Place)placesBindingSource.Current ?? throw new Exception("Empty product");

                view.PlaceId1 = Convert.ToString( worker.Id);
                view.PlaceLayer = Convert.ToString(worker.NumberLayer);
                view.PlaceStay = Convert.ToString(worker.NumberStay);
                view.PlaceSize = Convert.ToString(worker.Size);

                view.IsEdit = true;
                view.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void AddNewPlace(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadAllLists()
        {
            productList = model.GetProducts();
            productsBindingSource.DataSource = productList;
            placesList = model.GetPlace();
            placesBindingSource.DataSource = placesList;
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

        private void DeleteSelectedProduct(object sender, EventArgs e)
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
                product.DateCome = DateTime.ParseExact(view.DateCome, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                product.ProductId = view.ProductId;
                product.PlaceId = view.PlaceId;
                product.InventoryNumber = view.InventoryNumber;
                product.DateProduction = DateTime.ParseExact(view.DateProduction, "dd.MM.yyyy", CultureInfo.InvariantCulture);
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
