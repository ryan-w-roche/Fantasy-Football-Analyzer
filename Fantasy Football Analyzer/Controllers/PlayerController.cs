using Fantasy_Football_Analyzer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy_Football_Analyzer.Controllers
{
    public class PlayerController : Controller
    {
        public async Task<IActionResult> Player(int id)
        {
            Console.WriteLine("In Player " + id);
            var player = await PlayerDAO.GetPlayer(id);

            return View(player);
        }

        public async Task<IActionResult> PlayerList()
        {
            var players = await PlayerDAO.GetPlayerList();

            return View(players);
        }
    }
}
