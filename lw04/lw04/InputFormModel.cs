using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace lw04
{
	public sealed class InputFormModel
	{
		private const string BASE_URL = "https://www.cbr-xml-daily.ru/";
		
		private const string DAILY_FILE_NAME = "daily_json.js";
		
		private const int CURRENCIES_COUNT = 6;
		
		public string inFileName;
		
		public string outFileName;

		private string currDir;
		
		private Uri url;
		
		private HttpClient client;

		public InputFormModel()
		{
			url = new Uri(BASE_URL);
			client = new HttpClient { BaseAddress = url };
			currDir = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
		}
		public async Task<dynamic> GetCurrenciesData()
		{
			var response = await client.GetAsync(DAILY_FILE_NAME);
			if (response.StatusCode != HttpStatusCode.OK)
			{
				return null;
			}

			var json = await response.Content.ReadAsStringAsync();
			return (json != null) ? JsonConvert.DeserializeObject(json) : null;
		}

		public async Task WriteDataFromUrlAsync()
		{
			var getInputCurrenciesTask = GetCurrenciesFromInputFile();
			var getDataTask = GetCurrenciesData();
			await Task.WhenAll(getInputCurrenciesTask, getDataTask);
			
			var inputCurrencies = await getInputCurrenciesTask;
			var data = await getDataTask;
			
			var isInputFound = inputCurrencies != null;

			var outputFilePath = Path.Combine(currDir, $"{ outFileName }.json");

			Counter counter = new Counter();
			PrintCurrenciesToOut(outputFilePath, data, isInputFound, counter, inputCurrencies);
		}
		
		public void WriteDataFromUrlSync()
		{
			var inputCurrencies = GetCurrenciesFromInputFile().Result;
			var isInputFound = inputCurrencies != null;
			
			dynamic data = GetCurrenciesData().Result;

			var outputFilePath = Path.Combine(currDir, $"{ outFileName }.json");

			Counter counter = new Counter();
			PrintCurrenciesToOut(outputFilePath, data, isInputFound, counter, inputCurrencies);
		}

		private void PrintCurrenciesToOut(String outPath, dynamic data, bool isInputFound, Counter counter, List<String> inCurrencies)
		{
			using (var writer = new StreamWriter(outPath))
			{
				IDictionary<string, JToken> currenciesData = data.Valute;
				foreach (var currency in currenciesData)
				{
					if ((isInputFound && inCurrencies.Contains(currency.Key)) || (!isInputFound && counter.i < CURRENCIES_COUNT))
					{
						writer.WriteLine($"{currency.Value["Nominal"]} {currency.Key} - {currency.Value["Value"]}");
						counter.i++;
					}
				}
			}
		}

		private async Task<List<string>> GetCurrenciesFromInputFile()
		{
			var inputFilePath = Path.Combine(currDir, $"{ inFileName }.json");
			if (!File.Exists(inputFilePath))
			{
				return null;
			}

			using (var reader = new StreamReader(inputFilePath))
			{
				var file = await reader.ReadToEndAsync();
				return JsonConvert.DeserializeObject<List<string>>(file);
			}
		}
	}
}
