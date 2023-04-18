namespace TaskManagement.Models
{
    public class TblTaskActivityVM
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int PriorityID { get; set; }
        public string PriorityName { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime TaskCreatedOn { get; set; }
        public string EstimatedTime { get; set; }
        public string ActualTime { get; set; }

    }
}
