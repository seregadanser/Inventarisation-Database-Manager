﻿using System;
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
        event EventHandler ShowWarer;
    }
    public interface IWorkerView
    {
        void SetWorkerListBindingSource(BindingSource petList);
        void Show();
    }

    public interface IHRAdminView
    {

        string PetId { get; set; }
        string PetName { get; set; }
        string PetType { get; set; }
        string PetColour { get; set; }
        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void SetWorkerListBindingSource(BindingSource WorkerList);
        void Show();
    }
}
