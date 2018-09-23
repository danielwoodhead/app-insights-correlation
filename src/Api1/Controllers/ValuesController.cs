using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IValuesClient _valuesClient;
		private readonly ILogger<ValuesController> _logger;

		public ValuesController(IValuesClient valuesClient, ILogger<ValuesController> logger)
		{
			_valuesClient = valuesClient;
			_logger = logger;
		}

		// GET api/values
		[HttpGet]
		public async Task<ActionResult<IEnumerable<string>>> Get()
		{
			_logger.LogWarning("Custom logging from Api1");

			var values = await _valuesClient.GetAsync();

			return values.ToArray();
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
