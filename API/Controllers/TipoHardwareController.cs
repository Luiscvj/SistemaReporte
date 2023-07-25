using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoHardwareController : BaseApiController{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public TipoHardwareController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<IEnumerable<TipoHardwareDto>>> GetTipoHardwaresLugares(){
    var TipoHardwares = await _unitOfWork.TipoHardwares.GetAllTipoHardware();
    return this.mapper.Map<List<TipoHardwareDto>>(TipoHardwares);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<TipoHardwareDto> GettipoHardware(int id){
    var tipoHardware = await _unitOfWork.TipoHardwares.GetTipoHardWareById(id);
    return mapper.Map<TipoHardwareDto>(tipoHardware);
}





[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<TipoHardware>> Post(TipoHardware entity){
    if(entity == null)
    {
        return BadRequest();

    }
    _unitOfWork.TipoHardwares.AddTipoHardware(entity);
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

public async Task<ActionResult<TipoHardware>> Put(int id ,[FromBody]TipoHardware TipoHardware){
    
    _unitOfWork.TipoHardwares.Update(TipoHardware);
    var num = await _unitOfWork.SaveAsync();
    if( num == 0)
        return BadRequest();
    return TipoHardware;

}
    
[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]


public async Task<ActionResult> Delete(int id)
{
    var TipoHardware = await _unitOfWork.TipoHardwares.GetTipoHardWareById(id);
    if(TipoHardware == null)
        return NotFound();
    _unitOfWork.TipoHardwares.Remove(TipoHardware);
    await _unitOfWork.SaveAsync();
    return NoContent();
}

}