using System;

namespace ZagsDbServerProject.Responces
{
    public class LogsResponse
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int OperationTypeID { get; set; }
        public string OperationTypeName { get; set; }
        public string Comment { get; set; }
        public int? ApplicationID { get; set; }
        public DateTime EventTime { get; set; }
    }
}
