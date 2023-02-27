using DB_course.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Presenter
{
    public class WorkerPresenter
    {
        private IWorkerView view;
        //private IPetRepository repository;
        private BindingSource petsBindingSource;
      //  private IEnumerable<PetModel> petList;
        //Constructor
        public WorkerPresenter(IWorkerView view/*, IPetRepository repository*/)
        {
            this.petsBindingSource = new BindingSource();
            this.view = view;
           // this.repository = repository;
            //Subscribe event handler methods to view events
            
            //Set pets bindind source
            this.view.SetWorkerListBindingSource(petsBindingSource);
            //Load pet list view
            LoadAllPetList();
            //Show view
            this.view.Show();
        }
        //Methods
        private void LoadAllPetList()
        {
           /*petList = repository.GetAll();
            petsBindingSource.DataSource = petList;//Set data source.     */
        }
        private void SearchPet(object sender, EventArgs e)
        {
           /* bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if(emptyValue == false)
                petList = repository.GetByValue(this.view.SearchValue);
            else
                petList = repository.GetAll();
            petsBindingSource.DataSource = petList;   */
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
