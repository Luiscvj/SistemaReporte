using Core.Entities;
using Core.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoHardwareController : BaseApiController{

    private readonly IUnitOfWork _unitOfWork;

    public TipoHardwareController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<IEnumerable<TipoHardware>>> GetALL()
    {
        var TipoHs = await _unitOfWork.TipoHardwares.GetAllTipoHardware();
        return Ok(TipoHs);
    }

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<TipoHardware>> GetById(int id){
    var TipoH = await _unitOfWork.TipoHardwares.GetTipoHardWareById(id);
    return Ok(TipoH);

}


[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<TipoHardware>> Post(TipoHardware tipoHardware)
{
    if(tipoHardware == null)
    {
        return BadRequest();
    }

    _unitOfWork.TipoHardwares.AddTipoHardware(tipoHardware);
    int numRegistros = await _unitOfWork.SaveAsync();

    if(numRegistros == 0)
    {
        return BadRequest();
    }

    return  CreatedAtAction(nameof(Post), new {id = tipoHardware.Id},tipoHardware);
}


}