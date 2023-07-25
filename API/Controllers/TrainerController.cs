using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TrainerController : BaseApiController{

     //Aca declaro una variable privada context del tipo SistemaReporteContext
   private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public TrainerController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<IEnumerable<TrainerDto>>> GetTipoHardwaresLugares(){
    var TipoHardwares = await _unitOfWork.TipoHardwares.GetAllTipoHardware();
    return this.mapper.Map<List<TrainerDto>>(TipoHardwares);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<TrainerDto> GettipoHardware(int id){
    var tipoHardware = await _unitOfWork.TipoHardwares.GetTipoHardWareById(id);
    return mapper.Map<TrainerDto>(tipoHardware);
}



[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Trainer>> Post(TrainerUDTO trainer)
{
    var   trainerd = mapper.Map<Trainer>(trainer);
    if(trainer == null)
    {
        return BadRequest();
    }
    _unitOfWork.Trainers.Add(trainerd);
    var numAlter = await _unitOfWork.SaveAsync();

    if(numAlter == 0 )
    {
        return BadRequest();
    }

    return CreatedAtAction(nameof(Post),new {id = trainerd.Id},trainerd);

}


[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Trainer>> Put(int id ,[FromBody]Trainer Trainer){
    
    _unitOfWork.Trainers.Update(Trainer);
    var num = await _unitOfWork.SaveAsync();
    if( num == 0)
        return BadRequest();
    return Trainer;

}
    
[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]


public async Task<ActionResult> Delete(int id)
{
    var Trainer = await _unitOfWork.Trainers.GetByIdAsync(id);
    if(Trainer == null)
        return NotFound();
    _unitOfWork.Trainers.Remove(Trainer);
    await _unitOfWork.SaveAsync();
    return NoContent();
}

    //METODOS DE MI CLASE TRAINER
}