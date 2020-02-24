using System.Collections.Generic;

namespace ApiTest.Services
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;

    public interface ICountryRepository
    {
        string GetCountryByCountryCode(string countryCode);
    }

    public class CountryRepository : ICountryRepository
    {
        public Dictionary<string, string> Countries { get; set; }

        public CountryRepository(IConfiguration configuration)
        {
            var value = configuration.GetValue<string>("CountryDataFilePath");
            try
            {
                StreamReader streamReader = new StreamReader(value);

                string json = streamReader.ReadToEnd();
                Countries = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public string GetCountryByCountryCode(string countryCode)
        {
            if (Countries == null)
            {
                return null;
            }

            return Countries.TryGetValue(countryCode.ToUpper(), out string value) ? value : "";
        }
    }
}
