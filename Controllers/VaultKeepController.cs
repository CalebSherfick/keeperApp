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

    //GETALL keeps by vaultId   api/vaultkeeps/{{vaultId}}/keeps
    [HttpGet("{vaultId}/keeps")]
    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> results = _vkr.GetAllVaultKeeps(vaultId, userId);
      if (results == null)
      {
        return BadRequest("Unable to GETALLVAULTKEEPS: Results are not there.");
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

    //CREATE VAULTKEEP (ADD KEEP TO VAULT) api/vaultkeeps
    [HttpPost]
    [Authorize]
    public ActionResult<Vault> AddKeep([FromBody] VaultKeep payloadVK)
    {
      payloadVK.UserId = HttpContext.User.Identity.Name;
      VaultKeep newVaultKeep = _vkr.CreateVaultKeep(payloadVK);
      if (newVaultKeep == null) { return BadRequest("Unable to POST: VaultKeep doesn't exist."); }
      return Ok(newVaultKeep);
    }

    //DELETE VAULTKEEP
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vkr.Delete(id);
      if (!successful) { return BadRequest("Unable to DELETE: Delete was not successful."); }
      return Ok();
    }

  }
}
