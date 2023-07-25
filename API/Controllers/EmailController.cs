using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EmailController : BaseApiController{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public EmailController(IUnitOfWork unitOfWork  ,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<EmailDto>> Get(int id)
{                       //Aca unicamente traigo mi unidad de trabajo y la propiedad asociada a mi interfaz 
    var Email =  await _unitOfWork.Emails.GetEmailById(id);
    return mapper.Map<EmailDto>(Email);
}



[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]


public async Task<ActionResult<Email>> Post(EmailUDto emailE){
   var email = mapper.Map<Email>(emailE);
   
    if(email == null)
    {
        return BadRequest();

    }
    _unitOfWork.Emails.AddEmail(email);
    int  num = await _unitOfWork.SaveAsync();
    if(num == 0 )
    {
        return BadRequest();
    }

    return CreatedAtAction(nameof(Post), new {id = email.Id},email);

}


[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<IEnumerable<EmailDto>>> GeAll(){

    var Emails = await _unitOfWork.Emails.GetAllEmails();
    return mapper.Map<List<EmailDto>>(Emails);
}


[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Email>> Put(int id, [FromBody]Email Email)
{
    _unitOfWork.Emails.UpdateEmail(Email);
    int num = await _unitOfWork.SaveAsync();

    if(num == 0)
        return BadRequest();
    
    return Email;
}



[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]

public async Task<ActionResult> Delete(int id)
{
    var Email = await _unitOfWork.Emails.GetEmailById(id);
    if(Email == null)
        return NotFound();
    _unitOfWork.Emails.RemoveEmail(Email);
    var num = await _unitOfWork.SaveAsync();
    if (num == 0)
        return BadRequest();
    return NoContent();

}
}