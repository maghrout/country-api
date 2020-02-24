using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Security.Principal;
    using Newtonsoft.Json;
    using Services;

    public class HomeController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public HomeController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/country/{countryCode}")]
        public CountryResponse GetCountryCode(string countryCode)
        {
            var countryByCountryCode = _countryRepository.GetCountryByCountryCode(countryCode);

            if (countryByCountryCode == null)
            {
                return new CountryResponse
                {
                    Country = "",
                    HttpStatusCode = HttpStatusCode.ServiceUnavailable
                };
            }
            else if (countryByCountryCode == "")
            {
                return new CountryResponse
                {
                    Country = "",
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }

            return new CountryResponse
            {
                Country = countryByCountryCode,
                HttpStatusCode = HttpStatusCode.OK
            };
        }
    }

    public class CountryResponse
    {
        public string Country { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
