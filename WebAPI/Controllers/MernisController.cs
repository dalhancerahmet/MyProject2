using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MernisController : ControllerBase
    {
        IKimlikDogrulamaServisi _kimlikDogrulamaYonetimi;
        [HttpGet("dogrula")]
        public IActionResult Dogrula(long tcno, string ad, string soyad, int dogumYili)
        {
            // return Ok(_kimlikDogrulamaYonetimi.Dogrula(tcno, ad, soyad, dogumYili));
            return  Ok(true);
        }
    }
}
