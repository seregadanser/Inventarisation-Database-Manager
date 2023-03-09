using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.View
{
    public interface IMainView
    {
        event EventHandler ShowWorker;
        event EventHandler ShowAdmin;
        event EventHandler ShowHrAdmin;
        event EventHandler ShowWarer;
    }

    public interface IView
     { 
        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        void Show();
    }

    public interface IWorkerView  : IView
    {
        void SetWorkerListBindingSource(BindingSource petList);
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
    }

    public interface IHRAdminView   : IView
    {

        int WorkerId { get; set; }
        string WorkerName { get; set; }
        string WorkerSecondName { get; set; }
        string WorkerPosition { get; set; }
        string WorkerBirthday { get; set; }
        public string WorkerLogin { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void SetWorkerListBindingSource(BindingSource WorkerList);
    }
    public interface IWarehouseAdminForm : IView
    {

        int PlaceId { get; set; }
        int ProductId { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void SetPlaceListBindingSource(BindingSource WorkerList);
        void SetProductListBindingSource(BindingSource WorkerList);
    }
}
