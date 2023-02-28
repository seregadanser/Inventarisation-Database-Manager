using DB_course.Models;
using DB_course.Models.DBModels;
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
        private HRAdminModel model;
        private BindingSource workersBindingSource;
        private IEnumerable<Person> personList;
        private Person curperson;

        public HRAdminPresenter(IHRAdminView view, IModel model)
        {
            this.workersBindingSource = new BindingSource();
            this.view = view;
            this.model = (HRAdminModel)model;

            this.view.SearchEvent += SearchWorker;
            this.view.AddNewEvent += AddNewWorker;
            this.view.EditEvent += LoadSelectedWorkerToEdit;
            this.view.DeleteEvent += DeleteSelectedWorker;
            this.view.SaveEvent += SaveWorker;
            this.view.CancelEvent += CancelAction;

            this.view.SetWorkerListBindingSource(workersBindingSource);

            LoadAllWorkerList();

            this.view.Show();
        }
        //Methods
        private void LoadAllWorkerList()
        {
            personList = model.LookPerson();
            workersBindingSource.DataSource = personList;
        }
        private void SearchWorker(object sender, EventArgs e)
        {
            personList = model.LookPerson(view.SearchValue);
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
            try
            {
                var person = new Person();
                person.Name = view.WorkerName;
                person.SecondName = view.WorkerSecondName;
                person.Position = view.WorkerPosition;
                person.Login = view.WorkerLogin;
                person.DateOfBirthday = null;

                // new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)
                {
                    model.UpdatePerson(view.WorkerId, person);
                    view.Message = "worker edited successfuly";
                }
                else
                {
                    person.Id = model.MaxId + 1;
                    model.AddPerson(person);
                    view.Message = "worker added sucessfully";
                }
 
                view.IsSuccessful = true;
                personList = model.LookPerson();
                workersBindingSource.DataSource = personList;

                view.WorkerSecondName = "";
                view.WorkerPosition = "";
                view.WorkerName = "";
                view.WorkerId = 0;
                view.WorkerBirthday = "";
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
                if (worker == null) throw new Exception();
                model.RemovePerson(worker.Id);
                view.IsSuccessful = true;
                view.Message = "worker deleted successfully";
                personList = model.LookPerson();
                workersBindingSource.DataSource = personList;
               
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not delete worker";
            }
        }
        private void LoadSelectedWorkerToEdit(object sender, EventArgs e)
        {
            try
            {
                var worker = (Person)workersBindingSource.Current;
                if (worker == null) throw new Exception();
                view.WorkerId = worker.Id;
                view.WorkerName = worker.Name;
                view.WorkerSecondName = worker.SecondName;
                view.WorkerPosition = worker.Position;
                view.WorkerBirthday = worker.DateOfBirthday.ToString();
                view.WorkerLogin = worker.Login;
                view.IsEdit = true;
                view.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not edit worker";
            }
        }
        private void AddNewWorker(object sender, EventArgs e)
        {
             view.IsEdit = false;
        }
    }
}
