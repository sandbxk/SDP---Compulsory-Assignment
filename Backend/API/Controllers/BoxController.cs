using Application.DTOs;
using Application.Interfaces;
using Domain;
using FluentValidation;
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
        try
        {
            return _boxService.GetBoxById(id);
        } 
        catch (KeyNotFoundException e) 
        {
            return NotFound("No box found at ID " + id);
        } 
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
    
    [HttpPost]
    public ActionResult<Box> CreateBox([FromBody] PostBoxDTO box)
    {
        try
        {
            var result = _boxService.CreateNewBox(box);
            return Created("", result);
        }
        catch (ValidationException v)
        {
            return BadRequest(v.Message);
        }
        catch (System.Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPut]
    public ActionResult<Box> UpdateBox([FromRoute] int id, [FromBody] Box box)
    {
        try
        {
            return Ok(_boxService.UpdateBox(id, box));
        } catch (KeyNotFoundException e) 
        {
            return NotFound("No product found at ID " + id);
        } catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
    
    [HttpDelete("{id}")]
    public ActionResult<Box> DeleteBox(int id)
    {
        try
        {
            var successful =_boxService.DeleteBox(id);

            if (successful)
                return Ok(_boxService.DeleteBox(id));
            else
                return BadRequest();
        } 
        catch (KeyNotFoundException e) 
        {
            return NotFound("No product found at ID " + id);
        } 
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
    
    [HttpGet]
    [Route("RebuildDB")]
    public void RebuildDb()
    {
        _boxService.RebuildDb();
    }




}