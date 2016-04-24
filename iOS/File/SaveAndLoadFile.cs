using System;
using Xamarin.Forms;
using TccApp.iOS;
using System.IO;
using System.Threading.Tasks;
using TccApp;
using Foundation;
using System.Linq;

[assembly:Dependency(typeof(TccApp.iOS.SaveAndLoadFile))]
namespace TccApp.iOS
{
	public class SaveAndLoadFile : ISaveAndLoadFile
	{

		public SaveAndLoadFile() {
			
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

		public static string DocumentsPath {
			get {
				var documentsDirUrl = NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.DocumentDirectory,
					NSSearchPathDomain.User).Last ();
				return documentsDirUrl.Path;
			}
		}

		string CreatePathToFile(string filename) {
			return Path.Combine (DocumentsPath, filename);
		}
	}
}

