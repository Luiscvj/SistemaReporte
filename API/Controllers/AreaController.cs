using System.Security.Cryptography.X509Certificates;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class AreaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public AreaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


//Metodos GET
/* 
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<ActionResult<IEnumerable<Area>>> GetAllAreas()
{
    var areas = await _unitOfWork.Areas.GetAllAsync();
    return Ok(areas);
} */


//Solo para mostrar el nombre de cada area con AreaUDto

[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]

public async Task<List<AreaUDto>> GetNombresAreas()
{
        var areas = await _unitOfWork.Areas.GetAllAsync();
        return mapper.Map<List<AreaUDto>>(areas);
}
}