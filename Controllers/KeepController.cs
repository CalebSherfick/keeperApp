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
  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _kr;
    public KeepsController(KeepsRepository kr)
    {
      _kr = kr;
    }

    //GETALL api/keeps
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> results = _kr.GetALL();
      if (results == null)
      {
        return BadRequest("Unable to GETALL: Results are not there.");
      }
      return Ok(results);
    }

    //GET MY api/keeps/mykeeps
    [HttpGet("mykeeps")]
    public ActionResult<IEnumerable<Keep>> GetMyKeeps()
    {
      string UserId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> results = _kr.GetAllMyKeeps(UserId);
      if (results == null)
      {
        return BadRequest("Unable to GETALL: Results are not there.");
      }
      return Ok(results);
    }

    // //GET BY ID api/keep/id
    // [HttpGet("{id}")]
    // public ActionResult<Keep> Get(int id)
    // {
    //   Keep found = _kr.GetById(id);
    //   if (found == null) { return BadRequest("Unable to GETBYID: Nothing was found."); }
    //   return Ok(found);
    // }

    //CREATE
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep keep)
    {
      keep.UserId = HttpContext.User.Identity.Name;
      Keep newKeep = _kr.CreateKeep(keep);
      if (newKeep == null) { return BadRequest("Unable to POST: Keep doesn't exist."); }
      return Ok(newKeep);
    }

    //EDIT
    //     [HttpPut("{id}")]
    //     public ActionResult<Keep> AddView(int id)
    //     {
    // Keep newKeep = _kr.AddView(id)
    //     }

    //DELETE
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _kr.Delete(id);
      if (!successful) { return BadRequest("Unable to DELETE: Delete was not successful."); }
      return Ok();
    }

  }
}
