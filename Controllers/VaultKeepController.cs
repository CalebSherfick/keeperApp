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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _vkr;
    public VaultKeepsController(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }

    //GETALL keeps by vault   api/vaultkeeps
    [HttpGet]
    public ActionResult<IEnumerable<VaultKeep>> Get()
    {
      IEnumerable<VaultKeep> results = _vkr.GetALL();
      if (results == null)
      {
        return BadRequest("Unable to GETALL: Results are not there.");
      }
      return Ok(results);
    }

    // //GET BY ID api/vaultkeeps/id
    // [HttpGet("{id}")]
    // public ActionResult<VaultKeep> Get(int id)
    // {
    //   VaultKeep found = _vkr.GetById(id);
    //   if (found == null) { return BadRequest("Unable to GETBYID: Nothing was found."); }
    //   return Ok(found);
    // }

    //CREATE
    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep vaultkeep)
    {
      vaultkeep.UserId = HttpContext.User.Identity.Name;
      VaultKeep newVaultKeep = _vkr.CreateKeep(vaultkeep);
      if (newVaultKeep == null) { return BadRequest("Unable to POST: VaultKeep doesn't exist."); }
      return Ok(newVaultKeep);
    }

    //DELETE
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vkr.Delete(id);
      if (!successful) { return BadRequest("Unable to DELETE: Delete was not successful."); }
      return Ok();
    }

  }
}
