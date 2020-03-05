using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return new Evento [] {
                new Evento() {
                    EventoId = 1,
                    Tema = "Angular e .NetCore",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    Local = "Agudos",
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento() {
                    EventoId = 2,
                    Tema = "React e Node",
                    Lote = "2º Lote",
                    QtdPessoas = 1000,
                    Local = "Bauru",
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                }
            };
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
            return new Evento [] {
                new Evento() {
                    EventoId = 1,
                    Tema = "Angular e .NetCore",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    Local = "Agudos",
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento() {
                    EventoId = 2,
                    Tema = "React e Node",
                    Lote = "2º Lote",
                    QtdPessoas = 1000,
                    Local = "Bauru",
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                }
            }.FirstOrDefault(x => x.EventoId == id);
        }
    }
}
