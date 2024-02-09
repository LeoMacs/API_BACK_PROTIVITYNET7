using AirportApi.DataAccess.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportApi.DataAccess.Implementacion
{
	public class AirportDAO
	{
		public readonly IDbConnection connection;

		public AirportDAO(ConexionService conexionServices)
		{
			string connsql = conexionServices.getConexion();
			connection = new SqlConnection(connsql);
		}

		

		public async Task<int> AsignarEpp(Asignacion obj)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@idColaborador", obj.idColaborador, DbType.Int64);
			parameters.Add("@idEpp", obj.idEpp, DbType.Int64);
			parameters.Add("@cantidad", obj.cantidad, DbType.Int64);
			if (connection.State == ConnectionState.Closed)
			{
				connection.Open();
			}
			var nResultado = await connection.ExecuteAsync("sp_ins_AsignarEpp", parameters, commandType: CommandType.StoredProcedure);
			connection.Close();
			return nResultado;
		}



		public async Task<dynamic> getAsignacionesPendientesRecepcion()
		{
			IEnumerable<dynamic> lista = await connection.QueryAsync<dynamic>("sp_get_AsignacionesPendientesRecepcion", commandType: CommandType.StoredProcedure);
			return lista.ToList();
		}



		public async Task<int> RecepcionarEPP(int idAsignacion)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@idAsignacion", idAsignacion, DbType.String);

			if (connection.State == ConnectionState.Closed)
			{
				connection.Open();
			}
			var nResultado = await connection.ExecuteAsync("sp_upd_RecepcionarEPP", parameters, commandType: CommandType.StoredProcedure);
			connection.Close();
			return nResultado;
		}

	}
}
