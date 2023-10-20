using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commission
{
    public class ChangeCountOfSpecialtyesDataModel
    {
        public string? Specialty_Code { get; set; }
        public string? Budget_places { get; set; }
        public string? Extra_budgetary_places { get; set; }
    }
}
