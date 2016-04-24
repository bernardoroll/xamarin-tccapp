using System;
using System.Threading.Tasks;

namespace TccApp
{
	public interface ISaveAndLoadFile
	{

		Task SaveTextAsync(string filename, string text);
		Task<string> LoadTextAsync (string filename);
		bool FileExists(string filename);
		long Length(string filename);
	}
}

