using DataCore.Models.Entities;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class TemplateDetailMappingBasic :BaseViewModel<TemplateDetailMapping>
    {
        public int Id { get; set; }
        public int PaySlipTemplateId { get; set; }
        public int PayrollDetailId { get; set; }
        public bool? IsActive { get; set; }

    }
}
