using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XLabs.Forms.Controls;
using System.Threading.Tasks;

namespace TccApp
{
	public partial class IO : ContentPage
	{

		private const string TAG = "IO";

		private enum FileOperation {
			READ,
			WRITE
		}

		private enum FileSize {
			ONE_BYTE,
			EIGHT_BYTES,
			THIRTY_TWO_BYTES,
			SIXTY_FOUR_BYTES,
			ONE_KILOBYTE,
			FOUR_KILOBYTES,
			EIGHT_KILOBYTES,
			THIRTY_TWO_KILOBYTES,
			SIXTY_FOUR_KILOBYTES,
			ONE_MEGABYTE,
			FOUR_MEGABYTES,
			EIGHT_MEGABYTES,
			THIRTY_TWO_MEGABYTES,
			SIXTY_FOUR_MEGABYTES
		}

		private const string ONE_BYTE_FILENAME = "one_byte.bin";
		private const string EIGHT_BYTES_FILENAME = "eight_bytes.bin";
		private const string THIRTY_TWO_BYTES_FILENAME = "thirty_two_bytes.bin";
		private const string SIXTY_FOUR_BYTES_FILENAME = "sixty_four_bytes.bin";
		private const string ONE_KILOBYTE_FILENAME = "one_kilobyte.bin";
		private const string FOUR_KILOBYTES_FILENAME = "four_kilobytes.bin";
		private const string EIGHT_KILOBYTES_FILENAME = "eight_kilobytes.bin";
		private const string THIRTY_TWO_KILOBYTES_FILENAME = "thirty_two_kilobytes.bin";
		private const string SIXTY_FOUR_KILOBYTES_FILENAME = "sixty_four_kilobytes.bin";
		private const string ONE_MEGABYTE_FILENAME = "one_megabyte.bin";
		private const string FOUR_MEGABYTES_FILENAME = "four_megabytes.bin";
		private const string EIGHT_MEGABYTES_FILENAME = "eight_megabytes.bin";
		private const string THIRTY_TWO_MEGABYTES_FILENAME = "thirty_two_megabytes.bin";
		private const string SIXTY_FOUR_MEGABYTES_FILENAME = "sixty_four_megabytes.bin";

		private const int NUMBER_OF_TESTS = 50;

		private FileSize fileSize;
		private FileOperation fileOperation;

		private ISaveAndLoadFile saveAndLoadFile;

		public IO ()
		{
			InitializeComponent ();

			InitialLoad ();
		}

		private void InitialLoad() {
			pckFileOperation.ItemsSource = new [] { 
				"Leitura",
				"Escrita"
			};
			pckFileSize.ItemsSource = new [] { 
				"1 byte",
				"8 bytes",
				"32 bytes",
				"64 bytes",
				"1 KB",
				"4 KB",
				"8 KB",
				"32 KB",
				"64 KB",
				"1 MB",
				"4 MB",
				"8 MB",
				"32 MB",
				"64 MB",
			};

			CreateTestFiles ();

			pckFileOperation.CheckedChanged += PckFileOperation_CheckedChanged;
			pckFileSize.CheckedChanged += PckFileSize_CheckedChanged;

			saveAndLoadFile = DependencyService.Get<ISaveAndLoadFile> ();

			btnCalculate.Clicked += BtnCalculate_Clicked;
		}

		private async Task WriteFile(byte[] data, FileSize fSize) {
			await saveAndLoadFile.SaveTextAsync (GetFileNameBySize (fSize), data.ToString ());
		}

		private async Task ReadFile(FileSize fsize) {
			await saveAndLoadFile.LoadTextAsync (GetFileNameBySize (fsize));
		}

		private async Task CreateTestFiles() {
			System.Diagnostics.Debug.WriteLine(TAG, "createTestFiles() called.");

			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.ONE_BYTE)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.ONE_BYTE)) != 1) {
				await WriteFile (GetTextBySize (FileSize.ONE_BYTE), FileSize.ONE_BYTE);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.EIGHT_BYTES)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.EIGHT_BYTES)) != 8) {
				await WriteFile (GetTextBySize (FileSize.EIGHT_BYTES), FileSize.EIGHT_BYTES);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.THIRTY_TWO_BYTES)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.THIRTY_TWO_BYTES)) != 32) {
				await WriteFile (GetTextBySize (FileSize.THIRTY_TWO_BYTES), FileSize.THIRTY_TWO_BYTES);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.SIXTY_FOUR_BYTES)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.SIXTY_FOUR_BYTES)) != 64) {
				await WriteFile (GetTextBySize (FileSize.SIXTY_FOUR_BYTES), FileSize.SIXTY_FOUR_BYTES);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.ONE_KILOBYTE)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.ONE_KILOBYTE)) != 1024) {
				await WriteFile (GetTextBySize (FileSize.ONE_KILOBYTE), FileSize.ONE_KILOBYTE);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.FOUR_KILOBYTES)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.FOUR_KILOBYTES)) != 4096) {
				await WriteFile (GetTextBySize (FileSize.FOUR_KILOBYTES), FileSize.FOUR_KILOBYTES);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.EIGHT_KILOBYTES)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.EIGHT_KILOBYTES)) != 8192) {
				await WriteFile (GetTextBySize (FileSize.EIGHT_KILOBYTES), FileSize.EIGHT_KILOBYTES);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.THIRTY_TWO_KILOBYTES)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.THIRTY_TWO_KILOBYTES)) != 32 * 1024) {
				await WriteFile (GetTextBySize (FileSize.THIRTY_TWO_KILOBYTES), FileSize.THIRTY_TWO_KILOBYTES);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.SIXTY_FOUR_KILOBYTES)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.SIXTY_FOUR_KILOBYTES)) != 64 * 1024) {
				await WriteFile (GetTextBySize (FileSize.SIXTY_FOUR_KILOBYTES), FileSize.SIXTY_FOUR_KILOBYTES);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.ONE_MEGABYTE)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.ONE_MEGABYTE)) != 1024 * 1024) {
				await WriteFile (GetTextBySize (FileSize.ONE_MEGABYTE), FileSize.ONE_MEGABYTE);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.FOUR_MEGABYTES)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.FOUR_MEGABYTES)) != 4 * 1024 * 1024) {
				await WriteFile (GetTextBySize (FileSize.FOUR_MEGABYTES), FileSize.FOUR_MEGABYTES);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.EIGHT_MEGABYTES)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.EIGHT_MEGABYTES)) != 8 * 1024 * 1024) {
				await WriteFile (GetTextBySize (FileSize.EIGHT_MEGABYTES), FileSize.EIGHT_MEGABYTES);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.THIRTY_TWO_MEGABYTES)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.THIRTY_TWO_MEGABYTES)) != 32 * 1024 * 1024) {
				await WriteFile (GetTextBySize (FileSize.THIRTY_TWO_MEGABYTES), FileSize.THIRTY_TWO_MEGABYTES);
			}
			if (!saveAndLoadFile.FileExists (GetFileNameBySize (FileSize.SIXTY_FOUR_MEGABYTES)) ||
				saveAndLoadFile.Length(GetFileNameBySize(FileSize.SIXTY_FOUR_MEGABYTES)) != 64 * 1024 * 1024) {
				await WriteFile (GetTextBySize (FileSize.SIXTY_FOUR_MEGABYTES), FileSize.SIXTY_FOUR_MEGABYTES);
			}
		}

		void BtnCalculate_Clicked (object sender, EventArgs e)
		{

			//string msg = "Favor selecionar um tipo de operação e um tamanho de arquivo";

			try {
				if (fileOperation == FileOperation.READ) {
					ReadOperationTest ();
				} else if (fileOperation == FileOperation.WRITE) {
					WriteOperationTest ();
				} else {
					//DisplayAlert("", msg, "Ok");
					DisplayAlert ("", "Favor selecionar um tipo de operação e um tamanho de arquivo", "OK");
				}
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine (TAG + "BtnCalculate_Clicked() error: " + ex.Message);
			}
		}

		private void ReadOperationTest() {
			double averageTime = 0;
			double shortestTime = Double.MaxValue;
			double largestTime = Double.MinValue;
			double totalTime = 0;

			long startTimestamp, endTimestamp;
			long [] eachExecutionTime = new long[NUMBER_OF_TESTS];

			startTimestamp = (long)DateTime.UtcNow.ToUniversalTime ().Subtract (new DateTime (1970, 1, 1, 0, 0, 0,
				DateTimeKind.Utc)).TotalMilliseconds;

			for (int i = 0; i < NUMBER_OF_TESTS; i++) {
				DateTime startTime = DateTime.Now;
				ReadFile (fileSize);
				DateTime endTime = DateTime.Now;

				TimeSpan diffTime = endTime - startTime;

				eachExecutionTime [i] = (long)diffTime.TotalMilliseconds;

				if (diffTime.TotalMilliseconds < shortestTime) {
					shortestTime = diffTime.TotalMilliseconds;
				}

				if (diffTime.TotalMilliseconds > largestTime) {
					largestTime = diffTime.TotalMilliseconds;
				}
				totalTime += diffTime.TotalMilliseconds;
			}

			endTimestamp = (long)DateTime.UtcNow.ToUniversalTime ().Subtract (new DateTime (1970, 1, 1, 0, 0, 0,
				DateTimeKind.Utc)).TotalMilliseconds;

			averageTime = totalTime / NUMBER_OF_TESTS;

			double averageTimeInSeconds = averageTime / 1000;
			double shortestTimeInSeconds = shortestTime / 1000;
			double largestTimeInSeconds = largestTime / 1000;
			double totalTimeInSeconds = totalTime / 1000;

			ShowResults (averageTimeInSeconds, shortestTimeInSeconds, largestTimeInSeconds, totalTimeInSeconds, 
				startTimestamp, endTimestamp, eachExecutionTime);

		}

		private void WriteOperationTest() {
			double averageTime = 0;
			double shortestTime = Double.MaxValue;
			double largestTime = Double.MinValue;
			double totalTime = 0;

			long startTimestamp, endTimestamp;
			long [] eachExecutionTime = new long[NUMBER_OF_TESTS];

			startTimestamp = (long)DateTime.UtcNow.ToUniversalTime ().Subtract (new DateTime (1970, 1, 1, 0, 0, 0,
				DateTimeKind.Utc)).TotalMilliseconds;

			for (int i = 0; i < NUMBER_OF_TESTS; i++) {
				DateTime startTime = DateTime.Now;
				WriteFile (GetTextBySize (fileSize), fileSize);
				DateTime endTime = DateTime.Now;

				TimeSpan diffTime = endTime - startTime;
				eachExecutionTime [i] = (long)diffTime.TotalMilliseconds;
				if (diffTime.TotalMilliseconds < shortestTime) {
					shortestTime = diffTime.TotalMilliseconds;
				}

				if (diffTime.TotalMilliseconds > largestTime) {
					largestTime = diffTime.TotalMilliseconds;
				}
				totalTime += diffTime.TotalMilliseconds;
			}

			endTimestamp = (long)DateTime.UtcNow.ToUniversalTime ().Subtract (new DateTime (1970, 1, 1, 0, 0, 0,
				DateTimeKind.Utc)).TotalMilliseconds;
			averageTime = totalTime / NUMBER_OF_TESTS;

			double averageTimeInSeconds = averageTime / 1000;
			double shortestTimeInSeconds = shortestTime / 1000;
			double largestTimeInSeconds = largestTime / 1000;
			double totalTimeInSeconds = totalTime / 1000;

			ShowResults (averageTimeInSeconds, shortestTimeInSeconds, largestTimeInSeconds, totalTimeInSeconds, 
				startTimestamp, endTimestamp, eachExecutionTime);
		}

		void PckFileSize_CheckedChanged (object sender, int e)
		{
			switch (e) {
			case 0:
				fileSize = FileSize.ONE_BYTE;
				break;
			case 1:
				fileSize = FileSize.EIGHT_BYTES;
				break;
			case 2:
				fileSize = FileSize.THIRTY_TWO_BYTES;
				break;
			case 3:
				fileSize = FileSize.SIXTY_FOUR_BYTES;
				break;
			case 4:
				fileSize = FileSize.ONE_KILOBYTE;
				break;
			case 5:
				fileSize = FileSize.FOUR_KILOBYTES;
				break;
			case 6:
				fileSize = FileSize.EIGHT_KILOBYTES;
				break;
			case 7:
				fileSize = FileSize.THIRTY_TWO_KILOBYTES;
				break;
			case 8:
				fileSize = FileSize.SIXTY_FOUR_KILOBYTES;
				break;
			case 9:
				fileSize = FileSize.ONE_MEGABYTE;
				break;
			case 10:
				fileSize = FileSize.FOUR_MEGABYTES;
				break;
			case 11:
				fileSize = FileSize.EIGHT_MEGABYTES;
				break;
			case 12:
				fileSize = FileSize.THIRTY_TWO_MEGABYTES;
				break;
			case 13:
				fileSize = FileSize.SIXTY_FOUR_MEGABYTES;
				break;
			default:
				fileSize = FileSize.EIGHT_BYTES;
				break;
			}
		}

		void PckFileOperation_CheckedChanged (object sender, int e)
		{

			var radio = sender as CustomRadioButton;

			if (radio == null || radio.Id == -1)
			{
				return;
			}
			switch (e) {
			case 0:
				fileOperation = FileOperation.READ;
				break;
			case 1:
				fileOperation = FileOperation.WRITE;
				break;
			default:
				fileOperation = FileOperation.READ;
				break;
			}
		}

		private string GetFileNameBySize(FileSize fSize) {
			switch (fSize) {
			case FileSize.ONE_BYTE:
				return ONE_BYTE_FILENAME;
			case FileSize.EIGHT_BYTES:
				return EIGHT_BYTES_FILENAME;
			case FileSize.THIRTY_TWO_BYTES:
				return THIRTY_TWO_BYTES_FILENAME;
			case FileSize.SIXTY_FOUR_BYTES:
				return SIXTY_FOUR_BYTES_FILENAME;
			case FileSize.ONE_KILOBYTE:
				return ONE_KILOBYTE_FILENAME;
			case FileSize.FOUR_KILOBYTES:
				return FOUR_KILOBYTES_FILENAME;
			case FileSize.EIGHT_KILOBYTES:
				return EIGHT_KILOBYTES_FILENAME;
			case FileSize.THIRTY_TWO_KILOBYTES:
				return THIRTY_TWO_KILOBYTES_FILENAME;
			case FileSize.SIXTY_FOUR_KILOBYTES:
				return SIXTY_FOUR_KILOBYTES_FILENAME;
			case FileSize.ONE_MEGABYTE:
				return ONE_MEGABYTE_FILENAME;
			case FileSize.FOUR_MEGABYTES:
				return FOUR_MEGABYTES_FILENAME;
			case FileSize.EIGHT_MEGABYTES:
				return EIGHT_MEGABYTES_FILENAME;
			case FileSize.THIRTY_TWO_MEGABYTES:
				return THIRTY_TWO_MEGABYTES_FILENAME;
			case FileSize.SIXTY_FOUR_MEGABYTES:
				return SIXTY_FOUR_MEGABYTES_FILENAME;
			default:
				return EIGHT_BYTES_FILENAME;
			}
		}

		private byte[] GetTextBySize(FileSize fSize) {
			switch(fSize) {
			case FileSize.ONE_BYTE:
				return FillArrayOfBytes(1);
			case FileSize.EIGHT_BYTES:
				return FillArrayOfBytes(8);
			case FileSize.THIRTY_TWO_BYTES:
				return FillArrayOfBytes(32);
			case FileSize.SIXTY_FOUR_BYTES:
				return FillArrayOfBytes(64);
			case FileSize.ONE_KILOBYTE:
				return FillArrayOfBytes(1024);
			case FileSize.FOUR_KILOBYTES:
				return FillArrayOfBytes(4096);
			case FileSize.EIGHT_KILOBYTES:
				return FillArrayOfBytes(8192);
			case FileSize.THIRTY_TWO_KILOBYTES:
				return FillArrayOfBytes(32768);
			case FileSize.SIXTY_FOUR_KILOBYTES:
				return FillArrayOfBytes(65536);
			case FileSize.ONE_MEGABYTE:
				return FillArrayOfBytes(1024 * 1024);
			case FileSize.FOUR_MEGABYTES:
				return FillArrayOfBytes(4096 * 1024);
			case FileSize.EIGHT_MEGABYTES:
				return FillArrayOfBytes(8192 * 1024);
			case FileSize.THIRTY_TWO_MEGABYTES:
				return FillArrayOfBytes(32768 * 1024);
			case FileSize.SIXTY_FOUR_MEGABYTES:
				return FillArrayOfBytes(65536 * 1024);
			default:
				return FillArrayOfBytes(8);
			}
		}

		private byte[] FillArrayOfBytes(int size) {
			byte[] byteArray = new byte[size];
			for(int i = 0; i < size; i++) {
				byteArray [i] = Byte.Parse ("A");;
			}
			return byteArray;
		}

		private void ShowResults(double averageTimeInSeconds, double shortestTimeInSeconds, double largestTimeInSeconds,
			double totalTimeInSeconds, long startTimestamp, long endTimestamp, long[] eachExecutionTime) {

			lblStartTimestamp.Text = "Timestamp inicial: " + startTimestamp;

			lblAverageTime.Text = "Tempo médio: " + averageTimeInSeconds.ToString () + " segundos.";
			lblShortestTime.Text = "Menor tempo: " + shortestTimeInSeconds.ToString () + " segundos.";
			lblLargestTime.Text = "Maior tempo: " + largestTimeInSeconds.ToString () + " segundos.";
			lblTotalTime.Text = "Tempo total: " + totalTimeInSeconds.ToString () + " segundos.";

			lblEndTimestamp.Text = "Timestamp final: " + endTimestamp;
			lblVariance.Text = "Variância: " + Statistics.GetVariance (eachExecutionTime);
			lblStandardDeviation.Text = "Desvio padrão: " + Statistics.GetStandardDeviation (eachExecutionTime);

		}

	}
}