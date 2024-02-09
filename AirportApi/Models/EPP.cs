using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class EPP
	{
		[Key]
		public int idEPP { get; set; }
		public string Descripcion { get; set; }
	}
}
