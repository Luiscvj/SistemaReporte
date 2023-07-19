using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EmailController : BaseApiController{

    private readonly IUnitOfWork _unitOfWork;

    public EmailController(IUnitOfWork unitOfWork  )
    {
        _unitOfWork = unitOfWork;
    }


[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<IEnumerable<Email>>> GetAll()
{
    var emails = await _unitOfWork.Emails.GetAllEmails();
    return Ok(emails);
}

//Esto indica que el metodo Http asociado a la funcion es de tipo Get y espera  un parametro de ruta {id}
[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Email>> Get(int id)
{
    var email = await _unitOfWork.Emails.GetEmailById(id);
    //Devuelve un codigo 200 con el cuerpo de la solicitud.Es decir devuelve un OkObjectResult  que contiene el contenido especificado
    return Ok(email);
}

}