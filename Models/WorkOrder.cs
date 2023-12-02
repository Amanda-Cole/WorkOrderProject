using System.ComponentModel.DataAnnotations;

namespace WorkOrderProject.Models
{
    public class WorkOrder
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime RepairDate { get; set; }
        public string? PropertyAddress { get; set; }

        public string? RepairDetails { get; set; }
        public decimal Cost { get; set; }
    }
}
