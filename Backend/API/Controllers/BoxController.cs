using Application.DTOs;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BoxController : ControllerBase
{

    private readonly IBoxService _boxService;

    public BoxController(IBoxService boxService)
    {
        _boxService = boxService;
    }

    [HttpGet]
    public ActionResult<List<Box>> GetAllBoxes()
    {
        return _boxService.GetAllBoxes();
    }
    
    [HttpGet("{id}")]
    public ActionResult<Box> GetBoxById(int id)
    {
        return _boxService.GetBoxById(id);
    }
    
    [HttpPost]
    public ActionResult<Box> CreateBox([FromBody] PostBoxDTO box)
    {
        return _boxService.CreateNewBox(box);
    }
    
    [HttpPut]
    public ActionResult<Box> UpdateBox([FromBody] Box box)
    {
        return _boxService.UpdateBox(box.Id, box);
    }
    
    [HttpDelete("{id}")]
    public ActionResult<Box> DeleteBox(int id)
    {
        var successful =_boxService.DeleteBox(id);

        if (successful)
            return Ok();
        else
        {
            return NotFound();
        }
    }




}