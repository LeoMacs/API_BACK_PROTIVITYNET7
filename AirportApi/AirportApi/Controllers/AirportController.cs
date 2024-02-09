using AirportApi.DataAccess.Data;
using AirportApi.DataAccess.Implementacion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirportApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AirportController : ControllerBase
	{
		private readonly AppDBContext appDBContext;
		
		public AirportController(AppDBContext appDBContext )
		{
			this.appDBContext = appDBContext;
		}


		[HttpGet]
		public async Task<IActionResult> GetAllColaboradores()
		{
			try
			{
				var listColaboradores = await appDBContext.colaborador.ToListAsync();
				return Ok(listColaboradores);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		[HttpGet("byId")]
		public async Task<IActionResult> GetColaborador(int id)
		{
			try
			{
				Colaborador colaborador = new Colaborador();
				colaborador = await appDBContext.colaborador.FirstOrDefaultAsync(x => x.idColaborador == id) ?? new Colaborador();
				return Ok(colaborador);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddColaborador([FromBody] Colaborador colaborador)
		{
			try
			{
				appDBContext.Add(colaborador);
				await appDBContext.SaveChangesAsync();
				return Ok(colaborador);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public async Task<IActionResult> EditColaborador([FromBody] Colaborador colaborador)
		{
			try
			{
				appDBContext.Update(colaborador);
				await appDBContext.SaveChangesAsync();
				return Ok(colaborador);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteColaborador(int id)
		{
			try
			{
				var colaborador = await appDBContext.colaborador.FindAsync(id);
				if (colaborador == null)
				{
					return NotFound();
				}
				appDBContext.Remove(colaborador);
				await appDBContext.SaveChangesAsync();
				return Ok(colaborador);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		////////////////EPPS////////////////////
		[HttpGet("epp")]
		public async Task<IActionResult> GetEPPS()
		{
			try
			{
				var ePPs = await appDBContext.epp.ToListAsync();
				return Ok(ePPs);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("epp/byId")]
		public async Task<IActionResult> GetEPP(int id)
		{
			try
			{
				EPP epp = new EPP();
				epp = await appDBContext.epp.FirstOrDefaultAsync(x => x.idEPP == id) ?? new EPP();
				return Ok(epp);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("epp")]
		public async Task<IActionResult> AddEPPS([FromBody] EPP epp)
		{
			try
			{
				appDBContext.Add(epp);
				await appDBContext.SaveChangesAsync();
				return Ok(epp);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("epp")]
		public async Task<IActionResult> EditEPP([FromBody] EPP epp)
		{
			try
			{
				appDBContext.Update(epp);
				await appDBContext.SaveChangesAsync();
				return Ok(epp);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("epp")]
		public async Task<IActionResult> DeleteEPP(int id)
		{
			try
			{
				var epp = await appDBContext.epp.FindAsync(id);
				if (epp == null)
				{
					return NotFound();
				}
				appDBContext.Remove(epp);
				await appDBContext.SaveChangesAsync();
				return Ok(epp);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		


	}
}
