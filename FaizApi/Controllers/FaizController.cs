using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaizApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class FaizController : ControllerBase
    {
        private double AylikFaizOrani = 0.01;
        
        // GET: api/Faiz
        [HttpGet]
        [Route("FaizMiktar")]
        public IEnumerable<double> GetAmounts([FromQuery] int AnaPara, int Vade)
        {
            double FaizTutari = AnaPara * AylikFaizOrani * Vade;
            double ToplamOdenecekTutar = AnaPara + FaizTutari;
            return new Double[] { ToplamOdenecekTutar, FaizTutari };
        }

        [HttpGet]
        [Route("OdemeListesi")]
        public IEnumerable<double> GetList([FromQuery] int AnaPara, int Vade)
        {
            double FaizTutari = AnaPara * AylikFaizOrani * Vade;
            double ToplamOdenecekTutar = AnaPara + FaizTutari;
            Double [] list = new Double[Vade];
            for (int i = 0; i < Vade; i++)
            {
                list[i] = ToplamOdenecekTutar / Vade;
            }
            return list;
        }

    }
}
