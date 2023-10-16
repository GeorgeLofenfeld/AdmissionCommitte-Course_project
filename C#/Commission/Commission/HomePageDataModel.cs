using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commission
{
    /// <summary>
    /// Модель данных выводимой таблицы в главном окне
    /// </summary>
    public class HomePageDataModel
    {
        public int number { get; set; }
        public string? lastName { get; set; }
        public string? firstName { get; set; }
        public string? middleName { get; set; }
        public string? dateOfBirth { get; set; }
        public string? specialtyCode { get; set; }
        public double averageScore { get; set; }
        public string? dateOfStatement { get; set; }
        public int numberOfStatement { get; set; }
    }
}
