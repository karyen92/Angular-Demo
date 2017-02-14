using System;
using Demo.Framework.Mediators;

namespace Demo.Core.Models
{
    public class CreateMaterialElementModel : IAsyncRequest<CommonResultModel>
    {
        public DateTime Date { get; set; }
        public string DropdownId { get; set; }
    }
}
