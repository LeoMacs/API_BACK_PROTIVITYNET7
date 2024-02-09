using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Asignacion
	{
		[Key]
		public int idAsignacion { get; set; }
		public int idColaborador { get; set; }
		public int idEpp { get; set; }
		public int cantidad { get; set; }
		public string FechaAsignacion { get; set; }
		public string FechaRenovacion { get; set; }
		public string FechaRecepcion { get; set; }
		public Boolean FlgRecibido { get; set; }
	}
}
