using MateriaGris.Ecommerce.Application.Commons;
using MateriaGris.Ecommerce.Application.Dtos;
using MateriaGris.Ecommerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Interfaces;
using AutoMapper;
using MateriaGris.Ecommerce.Domain.Entities;

namespace MateriaGris.Ecommerce.Application.Services
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductApplication(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ProductDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ProductDto>>();
            try
            {
                var products = await _productRepository.GetAllAsync();
                if (products is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<ProductDto>>(products);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<ProductDto>> GetAsync(string productId)
        {
            var response = new Response<ProductDto>();
            try
            {
                var product = await _productRepository.GetAsync(productId);
                if (product is not null)
                {
                    response.Data = _mapper.Map<ProductDto>(product);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> InsertAsync(ProductDto productDto)
        {
            var response = new Response<bool>();
            try
            {
                var product = _mapper.Map<Product>(productDto);
                response.Data = await _productRepository.InsertAsync(product);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
                else
                {
                    response.Message = "Registro Fallido!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(ProductDto productDto)
        {
            var response = new Response<bool>();
            try
            {
                var product = _mapper.Map<Product>(productDto);
                response.Data = await _productRepository.UpdateAsync(product);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
                else
                {
                    response.Message = "Actualización Fallida!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string productId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _productRepository.DeleteAsync(productId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
                else
                {
                    response.Message = "Eliminación Fallida!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}

