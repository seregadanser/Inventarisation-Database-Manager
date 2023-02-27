using DB_course.Repositories;
using DB_course.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace DB_course.Presenter
{
    public class HRAdminPresenter
    {
        private IHRAdminView view;
        private IRepository<Person> repository;
        private BindingSource workersBindingSource;
        private IEnumerable<Person> personList;
        //Constructor
        public HRAdminPresenter(IHRAdminView view, IRepository<Person> repository)
        {
            this.workersBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchWorker;
            this.view.AddNewEvent += AddNewWorker;
            this.view.EditEvent += LoadSelectedWorkerToEdit;
            this.view.DeleteEvent += DeleteSelectedWorker;
            this.view.SaveEvent += SaveWorker;
            this.view.CancelEvent += CancelAction;
            //Set pets bindind source
            this.view.SetWorkerListBindingSource(workersBindingSource);
            //Load pet list view
            LoadAllWorkerList();
            //Show view
            this.view.Show();
        }
        //Methods
        private void LoadAllWorkerList()
        {
            personList = repository.GetList();
            workersBindingSource.DataSource = personList;//Set data source.
        }
        private void SearchWorker(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                personList = repository.Get(this.view.SearchValue);
            else personList = repository.GetList();
            workersBindingSource.DataSource = personList;
        }
        private void CancelAction(object sender, EventArgs e)
        {
            view.WorkerSecondName = "";
            view.WorkerPosition = "";
            view.WorkerName = "";
            view.WorkerId = 0;
            view.WorkerBirthday = "";
        }
        private void SaveWorker(object sender, EventArgs e)
        {
            var model = new Person();
            model.Id = 6;
            model.Name = view.WorkerName;
            model.SecondName = view.WorkerSecondName;
            model.Position = view.WorkerPosition;
            model.DateOfBirthday = null;
            try
            {
               // new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)//Edit model
                {
                    repository.Update(model);
                    view.Message = "worker edited successfuly";
                }
                else //Add new model
                {
                    repository.Create(model);
                    view.Message = "Pet added sucessfully";
                }
                view.IsSuccessful = true;
                personList = repository.GetList();
                workersBindingSource.DataSource = personList;//Set data source.
                view.WorkerSecondName = "";
                view.WorkerPosition = "";
                view.WorkerName = "";
                //view.WorkerId = 0;
                view.WorkerBirthday = "";
                repository.Save();
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
                var pet = (Person)workersBindingSource.Current;
                repository.Delete(pet.Id);
                view.IsSuccessful = true;
                view.Message = "Pet deleted successfully";
                personList = repository.GetList();
                workersBindingSource.DataSource = personList;//Set data source.
                repository.Save();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not delete pet";
            }
        }
        private void LoadSelectedWorkerToEdit(object sender, EventArgs e)
        {
            var pet = (Person)workersBindingSource.Current;
            //view.PetId = pet.Id.ToString();
            view.WorkerName = pet.Name;
            view.WorkerSecondName = pet.SecondName;
            view.WorkerPosition = pet.Position;
            view.WorkerBirthday = pet.DateOfBirthday.ToString();
            view.IsEdit = true;
        }
        private void AddNewWorker(object sender, EventArgs e)
        {
             view.IsEdit = false;
        }
    }
}
