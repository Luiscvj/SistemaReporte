using Core.Entities;
using Core.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TrainerController : BaseApiController{

     //Aca declaro una variable privada context del tipo SistemaReporteContext
   private readonly IUnitOfWork _unitOfWork;

    public TrainerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<IEnumerable<Trainer>>> GetAll(){
    var trainers = await _unitOfWork.Trainers.GetAllAsync();
    return Ok(trainers);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Trainer>> GetById(int id){
    var trainer = await _unitOfWork.Trainers.GetByIdAsync(id) ;
    return Ok(trainer);
}


[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Trainer>> Post(Trainer trainer)
{
    if(trainer == null)
    {
        return BadRequest();
    }
    _unitOfWork.Trainers.Add(trainer);
    var numAlter = await _unitOfWork.SaveAsync();

    if(numAlter == 0 )
    {
        return BadRequest();
    }

    return CreatedAtAction(nameof(Post),new {id = trainer.Id},trainer);

}

    //METODOS DE MI CLASE TRAINER
}