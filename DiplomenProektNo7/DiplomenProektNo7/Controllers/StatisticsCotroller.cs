using DiplomenProektNo7.Abstraction;
using DiplomenProektNo7.Models.Statistics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomenProektNo7.Controllers
{
    public class StatisticsCotroller : Controller
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsCotroller(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }
        public IActionResult Index()
        {
            StatisticsVM statistics = new StatisticsVM();

            statistics.CountClients = statisticsService.CountClients();
            statistics.CountShoes = statisticsService.CountShoes();
            statistics.CountOrders = statisticsService.CountOrders();
            statistics.SumOrders = statisticsService.SumOrders();

            return View(statistics);
        }
    }
}
