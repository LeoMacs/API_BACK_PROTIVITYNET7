using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportApi.DataAccess.Data
{
	public class AppDBContext : DbContext
	{
		/// <summary>
		/// /// el dbset debe tener el mismo nombre de la tabla de la base de datos que hace referencia ,sino saldrá error
		/// </summary>
		public DbSet<Colaborador> colaborador { get; set; }
		public DbSet<EPP> epp { get; set; }

		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{

		}
	}
}
