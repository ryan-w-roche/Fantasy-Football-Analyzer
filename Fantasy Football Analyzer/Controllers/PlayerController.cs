using Fantasy_Football_Analyzer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy_Football_Analyzer.Controllers
{
    public class PlayerController : Controller
    {
        public async Task<IActionResult> Player()
        {
            var player = await PlayerDAO.GetPlayer(3121422);

            return View(player);
        }
    }
}
