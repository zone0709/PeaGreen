using DataCore.Models.Entities;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class FingerScanMachineBasic : BaseViewModel<FingerScanMachine>
    {
        public int Id { get; set; }
        public string MachineCode { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public string Url { get; set; }
        public string Ip { get; set; }
        public string BrandOfMachine { get; set; }
        public DateTime? DateOfManufacture { get; set; }
        public bool Active { get; set; }
    }
}
