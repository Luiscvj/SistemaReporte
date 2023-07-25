using System.Security.Cryptography.X509Certificates;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class EmailTrainerController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public EmailTrainerController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


//Metodos GET
/* 
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<IEnumerable<EmailTrainer>>> GetAllEmailTrainers()
{
    var EmailTrainers = await _unitOfWork.EmailTrainers.GetAllAsync();
    return Ok(EmailTrainers);
} */


//Solo para mostrar el nombre de cada area con AreaUDto
/* 
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
//Me devuelve unicamente las EmailTrainers
public async Task<List<AreaUDto>> GetNombresEmailTrainers()
{
        var EmailTrainers = await _unitOfWork.EmailTrainers.GetAllAsync();
        return mapper.Map<List<AreaUDto>>(EmailTrainers);
} */


[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<IEnumerable<EmailTrainerDto>>> GetEmailTrainersLugares(){
    var EmailTrainers = await _unitOfWork.EmailTrainers.GetAllAsync();
    return this.mapper.Map<List<EmailTrainerDto>>(EmailTrainers);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<EmailTrainerDto> GetEmail(int id){
    var Email = await _unitOfWork.EmailTrainers.GetByIdAsync(id);
    return mapper.Map<EmailTrainerDto>(Email);
}





[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<EmailTrainer>> Post(EmailTrainerDto EmailTrainerd){
   var emailTrainer = mapper.Map<EmailTrainer>(EmailTrainerd);
    if(emailTrainer == null)
    {
        return BadRequest();

    }
    _unitOfWork.EmailTrainers.Add(emailTrainer);
    int  num = await _unitOfWork.SaveAsync();
    if(num == 0 )
    {
        return BadRequest();
    }

    return emailTrainer;

}



[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<EmailTrainer>> Put(int id ,[FromBody]EmailTrainer EmailTrainer){
    
    _unitOfWork.EmailTrainers.Update(EmailTrainer);
    var num = await _unitOfWork.SaveAsync();
    if( num == 0)
        return BadRequest();
    return EmailTrainer;

}
    
[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]


public async Task<ActionResult> Delete(int id)
{
    var EmailTrainer = await _unitOfWork.EmailTrainers.GetByIdAsync(id);
    if(EmailTrainer == null)
        return NotFound();
    _unitOfWork.EmailTrainers.Remove(EmailTrainer);
    await _unitOfWork.SaveAsync();
    return NoContent();
}

}