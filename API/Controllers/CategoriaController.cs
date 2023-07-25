using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class CategoriaController : BaseApiController{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public CategoriaController(IUnitOfWork unitOfWork,IMapper mapper){
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<CategoriaDto>> Get(int id)
{                       //Aca unicamente traigo mi unidad de trabajo y la propiedad asociada a mi interfaz 
    var categoria =  await _unitOfWork.Categorias.GetCategoryById(id);
    return mapper.Map<CategoriaDto>(categoria);
}


[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<IEnumerable<CategoriaDto>>> GeAll(){

    var categorias = await _unitOfWork.Categorias.GetAllCategories();
    return mapper.Map<List<CategoriaDto>>(categorias);
}


[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Categoria>> Post(CategoriaUDto Categorias)
{    var categoria =this.mapper.Map<Categoria>(Categorias);

    if(categoria == null)
    {
        return BadRequest();
    }
    _unitOfWork.Categorias.AddCategory(categoria);
    var numAlter = await _unitOfWork.SaveAsync();

    if(numAlter == 0 )
    {
        return BadRequest();
    }

    return CreatedAtAction(nameof(Post),new {id = categoria.Id},categoria);

}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<Categoria>> Put(int id, [FromBody]Categoria categoria)
{
    _unitOfWork.Categorias.UpdateCategory(categoria);
    int num = await _unitOfWork.SaveAsync();

    if(num == 0)
        return BadRequest();
    
    return categoria;
}



[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]

public async Task<ActionResult> Delete(int id)
{
    var categoria = await _unitOfWork.Categorias.GetCategoryById(id);
    if(categoria == null)
        return NotFound();
    _unitOfWork.Categorias.RemoveCategoriaByID(categoria);
    var num = await _unitOfWork.SaveAsync();
    if (num == 0)
        return BadRequest();
    return NoContent();

}
}