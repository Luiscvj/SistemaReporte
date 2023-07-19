using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

//Aca implementamos nuestra interfaz 

public class UnitOfWork : IUnitOfWork, IDisposable
{



  


private readonly SistemReporteContext _context;

    public UnitOfWork(SistemReporteContext context)
    {
        _context = context;
    }

    //Hacemos referencia a todos nuestros repositorios.
    private AreaRepository _area;
    private CategoriaRepository _categoria;
    private EmailRepository _email;
    private TipoHardwareRepository _tipoHardware;
    private TrainerRepository _trainer;
    private HardwareRepository _hardwares;
    private InsidenciaRepository _insidencias;
    private SoftwareRepository _softwares;
    private PuestoRepository _puestos;
    private TipoInsidenciaRepository _tipoInsidencias;
    private EmailTrainerRepository  _emailTrainers;
    private LugarRepository    _lugares;
    private TelefonoRepository  _telefonos;
    private TelefonoTrainerRepository _telefonosTrainers;
    private TipoSoftwareRepository  _tiposSoftwares;


    //Implementamos cada metodo para ESTABLECER UN LAZYLOAD es decir
    //Cada metodo se va a encargar de cargarme los repositorios de mi clase segun mi api los necesite y si ya esta no lo vuelve a crear.
    //Esto ayuda a auemntar la versatilidad de la api y aumentar la flexibilidad y rendimiento

    public IAreaInterface Areas
    {   //le damos cuerpo a nuestro get y le decimos que si existe retorne la instancia de mi repositorio, sino que la cree
        get{
            if(_area == null){
                _area = new AreaRepository(_context);
            }
            return _area;
        }
    }
  

    public ICategoria Categorias
    {
        get
        {
            if(_categoria == null)
            {
                _categoria = new CategoriaRepository(_context);

            }
            return _categoria;
        }
    }
    public IEmail Emails
    {
        get
        {
            if(_email == null)
            {
                _email = new EmailRepository(_context);
            }
            return _email;
        }  
    }

    public ITipoHardware TipoHardwares
    {
        get
        {
            if(_tipoHardware == null)
            {
                _tipoHardware = new TipoHardwareRepository(_context);
            }
            return _tipoHardware;
        }
    }

    public ITrainerInterface Trainers
    {
        get
        {
            if(_trainer == null)
            {
                _trainer = new TrainerRepository(_context);
            }
            return _trainer;
        }
    }

    public IHardware Hardwares
    {
        get
        {
            if(_hardwares == null)
            {
                _hardwares = new HardwareRepository(_context);
            }
            return _hardwares;
        }
    }

    public IInsidencia Insidencias
    {
        get
        {
            if(_insidencias == null)
            {
                _insidencias = new InsidenciaRepository(_context);
            }
            return _insidencias;
        }
    }
    public IPuesto Puestos
    {
        get
        {
            if(_puestos == null)
            {
                _puestos = new PuestoRepository(_context);
            }
            return _puestos;
        }
    }

    public ISoftware Softwares
    {
        get
        {
            if(_softwares == null)
            {
                _softwares = new SoftwareRepository(_context);
            }
            return _softwares;
        }
    }

    public ITipoInsidencia TipoInsidencias
    {
        get
        {
            if(_tipoInsidencias == null)
            {
                _tipoInsidencias = new TipoInsidenciaRepository(_context);
            }
            return _tipoInsidencias;
        }
    }

    public IEmailTrainer EmailTrainers
    {
        get
        {
            if(_emailTrainers == null)
            {
                _emailTrainers = new EmailTrainerRepository(_context);
            }
            return _emailTrainers;
        }
    }
    public ILugar Lugares
    {
        get
        {
            if(_lugares == null)
            {
                _lugares = new LugarRepository(_context);
            }
            return _lugares;
        }
    }

    public ITelefono Telefonos
    {
        get
        {
            if(_telefonos == null)
            {
                _telefonos = new TelefonoRepository(_context);
            }
            return _telefonos;
        }
    }
    public ITelefonoTrainer TelefonoTrainers
    {
        get
        {
            if(_telefonosTrainers == null)
            {
                _telefonosTrainers = new TelefonoTrainerRepository(_context);
            }
            return _telefonosTrainers;
        }
    }

    public ITipoSoftware TipoSoftwares
    {
                get
        {
            if(_tiposSoftwares == null)
            {
                _tiposSoftwares = new TipoSoftwareRepository(_context);
            }
            return _tiposSoftwares;
        }
    }

    public void Dispose()
    { //Se encarga de destruir el contexto si no estamos usandola, esto con el fin de liberar recursos.
        _context.Dispose();
    }


    public async Task<int> SaveAsync()
    {
          return await _context.SaveChangesAsync();
    }
}