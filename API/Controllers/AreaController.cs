using System.Security.Cryptography.X509Certificates;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class AreaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public AreaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


//Metodos GET
/* 
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<IEnumerable<Area>>> GetAllAreas()
{
    var areas = await _unitOfWork.Areas.GetAllAsync();
    return Ok(areas);
} */


//Solo para mostrar el nombre de cada area con AreaUDto
/* 
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
//Me devuelve unicamente las Areas
public async Task<List<AreaUDto>> GetNombresAreas()
{
        var areas = await _unitOfWork.Areas.GetAllAsync();
        return mapper.Map<List<AreaUDto>>(areas);
} */


[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<IEnumerable<AreaDto>>> GetAreasLugares(){
    var areas = await _unitOfWork.Areas.GetAllAsync();
    return this.mapper.Map<List<AreaDto>>(areas);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<AreaDto> GetArea(int id){
    var area = await _unitOfWork.Areas.GetByIdAsync(id);
    return mapper.Map<AreaDto>(area);
}





[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<Area>> Post(AreaUDto aread){
   var area = mapper.Map<Area>(aread);
    if(area == null)
    {
        return BadRequest();

    }
    _unitOfWork.Areas.Add(area);
    int  num = await _unitOfWork.SaveAsync();
    if(num == 0 )
    {
        return BadRequest();
    }

    return CreatedAtAction(nameof(Post), new {id = area.Id},area);

}



[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Area>> Put(int id ,[FromBody]Area area){
    
    _unitOfWork.Areas.Update(area);
    var num = await _unitOfWork.SaveAsync();
    if( num == 0)
        return BadRequest();
    return area;

}
    
[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]


public async Task<ActionResult> Delete(int id)
{
    var area = await _unitOfWork.Areas.GetByIdAsync(id);
    if(area == null)
        return NotFound();
    _unitOfWork.Areas.Remove(area);
    await _unitOfWork.SaveAsync();
    return NoContent();
}

}