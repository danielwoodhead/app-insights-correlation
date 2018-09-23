using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api1.Controllers
{
	public interface IValuesClient
	{
		Task<IEnumerable<string>> GetAsync();
	}
}
