using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MicroDocContainer
{
    public class MicroservicesAndDockerContainer
    {
		public long Id { get; set; }
        public Guid Guid_Id { get; set; }
        public string? Description { get; set; }
        public string? Further_Description { get; set; }
        public bool Is_Active { get; set; }
        public DateTime Created_Date { get; set; }
	}
}
