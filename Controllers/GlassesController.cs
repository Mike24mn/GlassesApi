using GlassesTypes.Models;
using GlassesTypes.GlassesSelection;
using Microsoft.AspNetCore.Mvc;

namespace GlassesTypes.Controllers;

[ApiController]
[Route("[controller]")]
public class GlassesController : ControllerBase
{
    public GlassesController()
    {
    }
    // GET all action

    [HttpGet]
    public ActionResult<List<Glasses>> GetAll()
    {
        return GlassesTypes.GlassesSelection.GlassesSelection.GetAll();
    }


    // GET by Id action

    [HttpGet("{id}")]
    public ActionResult<Glasses> Get(int id)
    {
        var glasses = GlassesTypes.GlassesSelection.GlassesSelection.Get(id);

        if (glasses == null)
            return NotFound();

        return glasses;
    }
    // POST action

    [HttpPost]
    public IActionResult Create(Glasses glasses)
    {
        // This code will save the glasses and return a result
        GlassesTypes.GlassesSelection.GlassesSelection.Add(glasses);
        return CreatedAtAction(nameof(Get), new { id = glasses.Id }, glasses);
    }

    // PUT action

    [HttpPut("{id}")]
    public IActionResult Update(int id, Glasses glasses)
    {
        if (id != glasses.Id)
            return BadRequest();

        var existingGlasses = GlassesTypes.GlassesSelection.GlassesSelection.Get(id);
        if (existingGlasses is null)
            return NotFound();

        GlassesTypes.GlassesSelection.GlassesSelection.Update(glasses);

        return NoContent();
    }

    // DELETE action

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var glasses = GlassesTypes.GlassesSelection.GlassesSelection.Get(id);

        if (glasses is null)
            return NotFound();

        GlassesTypes.GlassesSelection.GlassesSelection.Delete(id);

        return NoContent();
    }
}

