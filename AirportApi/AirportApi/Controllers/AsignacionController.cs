using AirportApi.DataAccess.Data;
using AirportApi.DataAccess.Implementacion;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirportApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AsignacionController : ControllerBase
	{
		private AirportDAO _services;

		public AsignacionController( AirportDAO _services)
		{
			this._services = _services;
		}

		////////////////ASIGNACION////////////////////
		[HttpGet("asignacionpendientesRecepcion")]
		public async Task<IActionResult> GetasignacionpendientesRecepcion()
		{
			try
			{
				var asignaciones = await _services.getAsignacionesPendientesRecepcion();
				return Ok(asignaciones);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}



		[HttpPost("AsignarEpp")]
		public async Task<IActionResult> AsignarEpp([FromBody] Asignacion obj)
		{
			try
			{
				await _services.AsignarEpp(obj);
				return Ok(obj);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("RecepcionarEPP")]
		public async Task<IActionResult> RecepcionarEPP(Asignacion obj)
		{
			try
			{
				await _services.RecepcionarEPP(obj.idAsignacion);
				return Ok(obj);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}



	}
}
