using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Colaborador
	{
		[Key]
		public int idColaborador { get; set; }
		public string DocIdentidad { get; set; }
		public string Nombres { get; set; }
	}
}
