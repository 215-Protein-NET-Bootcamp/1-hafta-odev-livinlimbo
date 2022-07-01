
using Microsoft.AspNetCore.Mvc;

namespace FaizApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class FaizController : ControllerBase
    {
        private double _aylikFaizOrani = 0.01;
        
        [HttpGet]
        [Route("FaizMiktar")]
        public IEnumerable<double> GetAmounts([FromQuery] int anaPara, int Vade)
        {
            double faizTutari = anaPara * _aylikFaizOrani * Vade;
            double toplamOdenecekTutar = anaPara + faizTutari;
            return new[] { toplamOdenecekTutar, faizTutari };
        }

        [HttpGet]
        [Route("OdemeListesi")]
        public IEnumerable<double> GetList([FromQuery] int anaPara, int vade)
        {
            double faizTutari = anaPara * _aylikFaizOrani * vade;
            double toplamOdenecekTutar = anaPara + faizTutari;
            Double [] list = new Double[vade];
            for (int i = 0; i < vade; i++)
            {
                list[i] = toplamOdenecekTutar / vade;
            }
            return list;
        }

    }
}
