using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Models.Dtos;
using Core.Interfaces;
using Api.Helpers;
using Core.Entities;
using Api.Extensions;

namespace Api.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class ProductController : BaseApiController{
   private readonly IUnitOfWork _UnitOfWork;
   private readonly IMapper _Mapper;
   private readonly ILogger<ProductController> _Logger;

   public ProductController (
      IUnitOfWork unitOfWork,
      IMapper mapper,
      ILogger<ProductController> logger
   ){
      _UnitOfWork = unitOfWork;
      _Mapper = mapper;
      _Logger = logger;
   }

   [HttpGet]
   [MapToApiVersion("1.0")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   public async Task<ActionResult> Get(){
      try{
         var records = await _UnitOfWork.Products.GetAllAsync();
         if (records == null){return NotFound();}
         if (!records.Any()){return NoContent();}
         return Ok(_Mapper.Map<List<ProductDto>>(records));
      }catch (Exception ex){
         _Logger.LogError(ex.Message);
         return StatusCode(500,"Some Wrong");
      }
   }

   [HttpGet("{id}")]
   [MapToApiVersion("1.0")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   public async Task<ActionResult> Get(int id){
      try{
         var record = await _UnitOfWork.Products.GetByIdAsync(id);
         if (record == null){return NotFound();}
         return Ok(_Mapper.Map<ProductDto>(record));
      }catch (Exception ex){
         _Logger.LogError(ex.Message);
         return StatusCode(500,"Some Wrong");
      }
   }

   [HttpGet]
   [MapToApiVersion("1.1")]
   [Authorize]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   public async Task<ActionResult> Get11([FromQuery] Params conf){
      try{
         var param = new Param(conf);
         var records = await _UnitOfWork.Products.GetAllAsync();
         if (records == null){return NotFound();}
         if (!records.Any()){return NoContent();}
         var recordDto = records.GetPaged<ProductDto,Product>(_Mapper,param);
         return Ok(recordDto);
      }catch (Exception ex){
         _Logger.LogError(ex.Message);
         return StatusCode(500,"Some Wrong");
      }
   }

   [HttpPost]
   [Authorize]
   [ProducesResponseType(StatusCodes.Status201Created)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   [ProducesResponseType(StatusCodes.Status409Conflict)]
   public async Task<ActionResult> Post(ProductDto recordDto){
      try{
         if(recordDto == null){return BadRequest();}
         if(_UnitOfWork.Products.ItAlreadyExists(recordDto)){
            return Conflict("ya se encuentra registrado");
         }
         var record = _Mapper.Map<Product>(recordDto);
         _UnitOfWork.Products.Add(record);
         await _UnitOfWork.SaveAsync();
         return Created(nameof(Post),new {id= record.Id, recordDto});
      }catch (Exception ex){
         _Logger.LogError(ex.Message);
         return StatusCode(500,"Some Wrong");
      }

   }

   [HttpPut("{id}")]
   [Authorize(Roles = "Administrator,Manager")]
   [MapToApiVersion("1.0")]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   [ProducesResponseType(StatusCodes.Status304NotModified)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   [ProducesResponseType(StatusCodes.Status409Conflict)]
   public async Task<ActionResult<ProductDto>> Put(int id, [FromBody]ProductDto? recordDto){
      try{
         if(recordDto == null){return BadRequest();}
         if(_UnitOfWork.Products.ItAlreadyExists(recordDto)){
            return Conflict("ya se encuentra registrado");
         }
         var record = _Mapper.Map<Product>(recordDto);
         record.Id = id;
         _UnitOfWork.Products.Update(record);
         await _UnitOfWork.SaveAsync();
         return NoContent();
      }catch (Exception ex){
         _Logger.LogError(ex.Message);
         return StatusCode(500,"Some Wrong");
      }

   }

   [HttpDelete("{id}")]
   [Authorize(Roles = "Administrator")]
   [MapToApiVersion("1.0")]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   public async Task<IActionResult> Delete(int id){
      try{
         var record = await _UnitOfWork.Products.GetByIdAsync(id);
         if(record == null){return NotFound();}
         _UnitOfWork.Products.Remove(record);
         await _UnitOfWork.SaveAsync();
         return NoContent();
      }catch (Exception ex){
         _Logger.LogError(ex.Message);
         return StatusCode(500,"Some Wrong");
      }

   }

}