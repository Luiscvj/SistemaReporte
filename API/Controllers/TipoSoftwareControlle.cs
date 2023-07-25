using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoSoftwareController : BaseApiController{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public TipoSoftwareController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<IEnumerable<TipoSoftwareDto>>> GetTipoSoftwareLugares(){
    var TipoSoftware = await _unitOfWork.TipoSoftwares.GetAllAsync();
    return this.mapper.Map<List<TipoSoftwareDto>>(TipoSoftware);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<TipoSoftwareDto> GetTipoSoftware(int id){
    var TipoSoftware = await _unitOfWork.TipoSoftwares.GetByIdAsync(id);
    return mapper.Map<TipoSoftwareDto>(TipoSoftware);
}





[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<TipoSoftware>> Post(TipoSoftware entity){
    if(entity == null)
    {
        return BadRequest();

    }
    _unitOfWork.TipoSoftwares.Add(entity);
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

public async Task<ActionResult<TipoSoftware>> Put(int id ,[FromBody]TipoSoftware TipoSoftware){
    
    _unitOfWork.TipoSoftwares.Update(TipoSoftware);
    var num = await _unitOfWork.SaveAsync();
    if( num == 0)
        return BadRequest();
    return TipoSoftware;

}
    
[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]


public async Task<ActionResult> Delete(int id)
{
    var TipoSoftware = await _unitOfWork.TipoSoftwares.GetByIdAsync(id);
    if(TipoSoftware == null)
        return NotFound();
    _unitOfWork.TipoSoftwares.Remove(TipoSoftware);
    await _unitOfWork.SaveAsync();
    return NoContent();
}

}