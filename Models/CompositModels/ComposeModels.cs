﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Models.CompositModels
{
   public class WorkerLookCompose              //IPr
   {
        [DisplayName("Inventory ID")]
        public int Id { get; set; }

        [DisplayName("Inventory number")]
        public int Inventory_number { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product name is requerid")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Product name must be between 3 and 50 characters")]
        public string? Name { get; set; }

        public DateTime? DateCome { get; set; }

        public DateTime? DateProduction { get; set; }

    }
    public class WarehousemanLookCompose              //UPeIPl
    {
        [DisplayName("Person ID")]
        public int Id { get; set; }

        [DisplayName("Person Name")]
        [Required(ErrorMessage = "Person name is requerid")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Person name must be between 3 and 50 characters")]
        public string? Name { get; set; }

        [DisplayName("Person Second Name")]
        [Required(ErrorMessage = "Person second name is requerid")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Person second name must be between 3 and 50 characters")]
        public string? SecondName { get; set; }

        [DisplayName("Person Login")]
        [Required(ErrorMessage = "Person login name is requerid")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Person login must be between 3 and 50 characters")]
        public string? Login { get; set; }

        public int? InventoryNumber { get; set; }

        public int? NumberStay { get; set; }

        public int? NumberLayer { get; set; }

        public DateTime? DateOfStart { get; set; }
    }
    public class WorkerLookUsefulCompose              //IPrU
    {

    }
    public class AdminCompose              //IPrPlo
    {

    }
}
