using System.Security.Cryptography.X509Certificates;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class LugarController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public LugarController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


//Metodos GET
/* 
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<IEnumerable<Lugares>>> GetAllLugaress()
{
    var Lugaress = await _unitOfWork.Lugaress.GetAllAsync();
    return Ok(Lugaress);
} */


//Solo para mostrar el nombre de cada Lugares con LugaresUDto
/* 
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
//Me devuelve unicamente las Lugaress
public async Task<List<LugaresUDto>> GetNombresLugaress()
{
        var Lugaress = await _unitOfWork.Lugaress.GetAllAsync();
        return mapper.Map<List<LugaresUDto>>(Lugaress);
} */


[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<IEnumerable<LugarDto>>> GetLugaressLugares(){
    var Lugares = await _unitOfWork.Lugares.GetAllAsync();
    return this.mapper.Map<List<LugarDto>>(Lugares);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<LugarDto> GetArea(int id){
    var area = await _unitOfWork.Areas.GetByIdAsync(id);
    return mapper.Map<LugarDto>(area);
}





[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<Lugar>> Post(Lugar entity){
    if(entity == null)
    {
        return BadRequest();

    }
    _unitOfWork.Lugares.Add(entity);
    int  num = await _unitOfWork.SaveAsync();
    if(num == 0 )
    {
        return BadRequest();
    }

    return CreatedAtAction(nameof(Post), new {id = entity.Id},entity);

}



[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Lugar>> Put(int id ,[FromBody]Lugar Lugares){
    
    _unitOfWork.Lugares.Update(Lugares);
    var num = await _unitOfWork.SaveAsync();
    if( num == 0)
        return BadRequest();
    return Lugares;

}
    
[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]


public async Task<ActionResult> Delete(int id)
{
    var Lugares = await _unitOfWork.Lugares.GetByIdAsync(id);
    if(Lugares == null)
        return NotFound();
    _unitOfWork.Lugares.Remove(Lugares);
    await _unitOfWork.SaveAsync();
    return NoContent();
}

}