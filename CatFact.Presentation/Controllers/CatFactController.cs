using CatFact.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatFact.Controllers;

public class CatFactController : ControllerBase
{
     private readonly ICatService _catService;

     public CatFactController(ICatService catService)
     {
          _catService = catService;
     }

     [HttpGet("/catFact")]
     public async Task<ActionResult> GetCatFacts()
     {
          try
          {
               var response = await _catService.GetCatFact();
               return Ok(response);
          }
          catch (Exception e)
          {
               return BadRequest(e.Message);
          }
     }
}