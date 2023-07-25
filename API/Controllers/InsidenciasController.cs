using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class InsidenciasController : BaseApiController{

     //Aca declaro una variable privada context del tipo SistemaReporteContext
   private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public InsidenciasController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<IEnumerable<InsidenciasDto>>> GetTipoHardwaresLugares(){
    var TipoHardwares = await _unitOfWork.TipoHardwares.GetAllTipoHardware();
    return this.mapper.Map<List<InsidenciasDto>>(TipoHardwares);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<InsidenciasDto> GettipoHardware(int id){
    var tipoHardware = await _unitOfWork.TipoHardwares.GetTipoHardWareById(id);
    return mapper.Map<InsidenciasDto>(tipoHardware);
}



[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Insidencia>> Post(Insidencia Insidencias)
{
    if(Insidencias == null)
    {
        return BadRequest();
    }
    _unitOfWork.Insidencias.AddInsidencia(Insidencias);
    var numAlter = await _unitOfWork.SaveAsync();

    if(numAlter == 0 )
    {
        return BadRequest();
    }

    return CreatedAtAction(nameof(Post),new {id = Insidencias.Id},Insidencias);

}


[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Insidencia>> Put(int id ,[FromBody]Insidencia Insidencias){
    
    _unitOfWork.Insidencias.UpdateInsidencia(Insidencias);
    var num = await _unitOfWork.SaveAsync();
    if( num == 0)
        return BadRequest();
    return Insidencias;

}
    
[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]


public async Task<ActionResult> Delete(int id)
{
    var Insidencias = await _unitOfWork.Insidencias.GetInsidenciaById(id);
    if(Insidencias == null)
        return NotFound();
    _unitOfWork.Insidencias.RemoveInsidencia(Insidencias);
    await _unitOfWork.SaveAsync();
    return NoContent();
}

    //METODOS DE MI CLASE TRAINER
}