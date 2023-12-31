using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IProductRepository: IGenericRepositoryWithIntId<Product>{
    bool ItAlreadyExists(ProductDto recordDto);    
}