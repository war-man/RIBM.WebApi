﻿using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class MachineAssignment
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int ClientId { get; set; }
        public int ClientLocationId { get; set; }
        public string PaymentTerms { get; set; }
        public decimal BaseCharges { get; set; }
        public decimal? OvertimeCharges { get; set; }
        public decimal? OvertimeChargesPerHour { get; set; }
        public decimal? MobilizationCharges { get; set; }
        public decimal? DeMobilizationCharges { get; set; }
        public decimal? LoadingUnloadingCharges { get; set; }
        public decimal? ExtraOperatorRequiredCharges { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public int MachineStatusId { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Client Client { get; set; }
        public ClientLocation ClientLocation { get; set; }
        public Users EntryUser { get; set; }
        public Machine Machine { get; set; }
        public MachineStatus MachineStatus { get; set; }
        public Users UpdateUser { get; set; }
    }
}
