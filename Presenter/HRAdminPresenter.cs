using DB_course.Repositories;
using DB_course.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.view.SearchEvent += SearchPet;
            this.view.AddNewEvent += AddNewPet;
            this.view.EditEvent += LoadSelectedPetToEdit;
            this.view.DeleteEvent += DeleteSelectedPet;
            this.view.SaveEvent += SavePet;
            this.view.CancelEvent += CancelAction;
            //Set pets bindind source
            this.view.SetWorkerListBindingSource(workersBindingSource);
            //Load pet list view
            LoadAllPetList();
            //Show view
            this.view.Show();
        }
        //Methods
        private void LoadAllPetList()
        {
            personList = repository.GetList();
            workersBindingSource.DataSource = personList;//Set data source.
        }
        private void SearchPet(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                personList = repository.Get(this.view.SearchValue);
            else personList = repository.GetList();
            workersBindingSource.DataSource = personList;
        }
        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void SavePet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void DeleteSelectedPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void LoadSelectedPetToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void AddNewPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
