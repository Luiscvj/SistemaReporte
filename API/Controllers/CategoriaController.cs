using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class CategoriaController : BaseApiController{

    private readonly IUnitOfWork _unitOfWork;

    public CategoriaController(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;
    }


[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Categoria>> Get(int id)
{                       //Aca unicamente traigo mi unidad de trabajo y la propiedad asociada a mi interfaz 
    var categoria =  await _unitOfWork.Categorias.GetCategoryById(id);
    return Ok(categoria);
}


[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<IEnumerable<Categoria>>> GeAll(){

    var categorias = await _unitOfWork.Categorias.GetAllCategories();
    return Ok(categorias);
}
   
}