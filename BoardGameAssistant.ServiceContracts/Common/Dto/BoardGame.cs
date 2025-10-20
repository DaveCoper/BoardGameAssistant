using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameAssistant.ServiceContracts.Common.Dto
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearPublished { get; set; }
    }
}
