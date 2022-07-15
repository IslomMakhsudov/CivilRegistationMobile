using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagsDbServerProject.Responces
{
    public class MyApplicationsResponse
    {
        public int ApplicationID { get; set; }
        public DateTime LastStatusTime { get; set; }
        public int ApplicationStatusID { get; set; }
        public string ApplicationStatusLabel { get; set; }

        
    }
}
