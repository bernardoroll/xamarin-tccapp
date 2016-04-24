using System;
using Xamarin.Forms;
using TccApp;
using System.Threading.Tasks;
using System.IO;

[assembly:Dependency(typeof(TccApp.Droid.SaveAndLoadFile))]
namespace TccApp.Droid
{
	public class SaveAndLoadFile : ISaveAndLoadFile
	{

		public SaveAndLoadFile(){
		}

		public async Task SaveTextAsync(string filename, string text) {
			var completePath = CreatePathToFile (filename);
			using (StreamWriter sw = File.CreateText (completePath)) {
				await sw.WriteAsync(text);
			}
		}

		public async Task<string> LoadTextAsync(string filename) {
			var completePath = CreatePathToFile (filename);
			using (StreamReader sr = File.OpenText (completePath)) {
				return await sr.ReadToEndAsync ();
			}
		}

		public bool FileExists(string filename) {
			var completePath = CreatePathToFile (filename);
			return File.Exists (completePath);
		}

		public long Length(string filename) {
			var completePath = CreatePathToFile (filename);
			FileInfo fInfo = new FileInfo (completePath);
			return fInfo.Length;
		}

		string CreatePathToFile(string filename) {
			var path = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			return Path.Combine (path, filename);
		}

	}
}

