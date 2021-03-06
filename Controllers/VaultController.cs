using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _vr;
    public VaultsController(VaultsRepository vr)
    {
      _vr = vr;
    }

    //GETALL
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      string UserId = HttpContext.User.Identity.Name;
      IEnumerable<Vault> results = _vr.GetALL(UserId);
      if (results == null)
      {
        return BadRequest("Unable to GETALL: Results are not there.");
      }
      return Ok(results);
    }

    //CREATE
    [HttpPost]
    [Authorize]
    public ActionResult<Vault> Create([FromBody] Vault vault)
    {
      vault.UserId = HttpContext.User.Identity.Name;
      Vault newVault = _vr.CreateVault(vault);
      if (newVault == null) { return BadRequest("Unable to POST: Vault doesn't exist."); }
      return Ok(newVault);
    }

    //DELETE
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      // var UserId = HttpContext.User.Identity.Name;
      // if (UserId == Vault.UserId)
      bool successful = _vr.Delete(id);
      if (!successful) { return BadRequest("Unable to DELETE: Delete was not successful."); }
      return Ok();
    }

  }
}
