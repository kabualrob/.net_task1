using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ahmed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayerController : ControllerBase
    {
        private string club;

        private static List<FootballPlayer> player = new List<FootballPlayer>()
            {
                new FootballPlayer{id=1,name="messi",Fname="leonel",Lname="messi",Club="FCB"},

                 new FootballPlayer{id=2,name="xavi",Fname="noidea",Lname="xavi",Club="FCB"}

            };

        [HttpGet]
        public IActionResult Get()
        {



            return Ok(player);
        }
        [HttpGet("id")]
        public IActionResult Get(int id)
        {

            var playerr = player.Find(p => p.id == id);
            if (playerr == null)
                return BadRequest("player not found");

            return Ok(player);
        }


        [HttpPost]
        public IActionResult Addplayer(FootballPlayer playerr)

        {
            player.Add(playerr);

            return Ok(player);
        }
        [HttpPut]
        public IActionResult updateplayer(FootballPlayer request)

        {
            var playerr = player.Find(p => p.id == request.id);
            if (playerr == null)
                return BadRequest("player not found");

            playerr.name = request.name;
            playerr.Fname = request.Fname;
            playerr.Lname = request.Lname;
            playerr.Club = request.Club;

            return Ok(player);

        }
        [HttpDelete("id")]
        public IActionResult Delete (int id)
        {

            var playerr = player.Find(p => p.id == id);
            if (playerr == null)
                return BadRequest("player not found");
            player.Remove(playerr);

            return Ok(player);
        }
    }  


    

}