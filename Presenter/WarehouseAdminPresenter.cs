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
using System.Diagnostics;

namespace DB_course.Presenter
{
    public class WarehouseAdminPresenter
    {
        private IWarehouseAdminView view;
        private AWarehouseAdminModel model;
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
            this.model = (AWarehouseAdminModel)model;


            //Set pets bindind source
            this.view.SetProductListBindingSource(productsBindingSource);
            this.view.SetPlaceListBindingSource(placesBindingSource);
            LoadAllLists();

            this.view.DeleteEvent += DeleteSelectedProduct;
            this.view.SaveEvent += AddNewProduct;
            this.view.CancelEvent += CancelAction;
            this.view.SearchEvent += SearchProduct;
            this.view.AddNewPlaceEvent += AddNewPlace;
            this.view.CancelPlaceEvent += PlaceCancelAction;
            this.view.EditPlaceEvent += LoadSelectedPlaceToEdit;
            this.view.SavePlaceEvent += SavePlace;
            this.view.DeletePlaceEvent += DeleteSelectedPlace;
            this.view.SearchPlaceEvent += SearchPlace;
            this.view.TestEvent += TestFunc;
            this.view.Show();
        }

        private void TestFunc(object? sender, EventArgs e)
        {
            for (int j = 10; j <= 500; j += 10)
            {
               // Console.WriteLine(j);
                List<Product> productList = new List<Product>();

                for (int i = 1; i <= j; i++)
                {
                    Product product = new Product();
                    product.Id = i + 1; // Set the unique ID
                    product.Name = $"Product {i}"; // Set a unique name for each product
                    product.Value = null; // Set the value as null

                    // Set non-null values for DateProduction and DateCome
                    product.DateCome = DateTime.Now.Date.AddDays(-i);
                    product.DateProduction = DateTime.Now.Date.AddMonths(-i);

                    productList.Add(product);
                }

                List<AdminCompose> adminComposeList = new List<AdminCompose>();
                Random random = new Random();

                for (int i = 1; i <= j; i++)
                {
                    AdminCompose adminCompose = new AdminCompose();
                    int prodid = random.Next(0, 10);

                    adminCompose.DateProduction = productList[prodid].DateProduction;
                    adminCompose.ProductId = productList[prodid].Id;
                    adminCompose.DateCome = productList[prodid].DateCome;
                    adminCompose.Name = productList[prodid].Name;

                    adminCompose.InventoryNumber = i + 1;
                    adminCompose.PlaceId = random.Next(1, 6).ToString();
                    adminComposeList.Add(adminCompose);
                }

                for (int i = 0; i < j; i++)
                    model.AddProduct(adminComposeList[i]);

                adminComposeList = model.GetProducts().ToList();
                Stopwatch strender = new Stopwatch();
                for (int i = 0; i < j; i++)
                {

                    strender.Start();
                   // model.RemoveProductTrigger(adminComposeList[i]);
                    model.RemoveProduct(adminComposeList[i]);
                    strender.Stop();

                }
                TimeSpan ts = strender.Elapsed;

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine(elapsedTime);
            }
        }

        //Methods

        private void SearchPlace(object sender, EventArgs e)
        {
            placesList = model.GetPlace(view.SearchPlaceValue);
            placesBindingSource.DataSource = placesList;

        }
        private void PlaceCancelAction(object sender, EventArgs e)
        {
            view.PlaceId1 = "";
            view.PlaceLayer = "";
            view.PlaceSize = "";
            view.PlaceStay = "";
        }
        private void SavePlace(object sender, EventArgs e)
        {
            try
            {
                var place = new Place();
                place.NumberLayer = int.TryParse(view.PlaceLayer, out _) ? Convert.ToInt32(view.PlaceLayer) : throw new Exception("invalid layer");
                place.NumberStay = int.TryParse(view.PlaceStay, out _) ? Convert.ToInt32(view.PlaceStay) : throw new Exception("invalid stay");
                place.Id = int.TryParse(view.PlaceId1, out _) ? Convert.ToInt32(view.PlaceId1) : throw new Exception("invalid id");
                place.Size = int.TryParse(view.PlaceSize, out _) ? Convert.ToInt32(view.PlaceSize) : throw new Exception("invalid size");


                if (view.IsEdit)
                {
                    model.UpdatePlace(place.Id,place);
                    view.Message = "Place edited successfuly";
                }
                else
                {

                    model.AddPlace(place);
                    view.Message = "Place added sucessfully";
                }

                view.IsSuccessful = true;
                placesList = model.GetPlace();
                placesBindingSource.DataSource = placesList;

                view.PlaceId1 = "";
                view.PlaceLayer = "";
                view.PlaceStay = "";
                view.PlaceSize = "";
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
        private void DeleteSelectedPlace(object sender, EventArgs e)
        {
            try
            {
                var place = (Place)placesBindingSource.Current ?? throw new Exception("Empty Place");
                model.RemovePlace(place.Id);
                view.IsSuccessful = true;
                view.Message = "Place deleted successfully";
                placesList = model.GetPlace();
                placesBindingSource.DataSource = placesList;

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
                    throw new Exception("Cant delit empty product");

                Stopwatch strender = new Stopwatch();

                strender.Start();
                model.RemoveProductTrigger(worker);
                strender.Stop();
                TimeSpan ts = strender.Elapsed;

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine(elapsedTime);
                view.IsSuccessful = true;
                view.Message = "product deleted successfully";
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
