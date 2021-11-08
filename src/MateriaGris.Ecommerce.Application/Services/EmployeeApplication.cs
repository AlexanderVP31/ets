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
    public class EmployeeApplication : IEmployeeApplication
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeApplication(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<EmployeeDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<EmployeeDto>>();
            try
            {
                var employees = await _employeeRepository.GetAllAsync();
                if (employees is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
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

        public async Task<Response<EmployeeDto>> GetAsync(string employeeId)
        {
            var response = new Response<EmployeeDto>();
            try
            {
                var employee = await _employeeRepository.GetAsync(employeeId);
                if (employee is not null)
                {
                    response.Data = _mapper.Map<EmployeeDto>(employee);
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

        public async Task<Response<bool>> InsertAsync(EmployeeDto employeeDto)
        {
            var response = new Response<bool>();
            try
            {
                var employee = _mapper.Map<Employee>(employeeDto);
                response.Data = await _employeeRepository.InsertAsync(employee);

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

        public async Task<Response<bool>> UpdateAsync(EmployeeDto employeeDto)
        {
            var response = new Response<bool>();
            try
            {
                var employee = _mapper.Map<Employee>(employeeDto);
                response.Data = await _employeeRepository.UpdateAsync(employee);

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

        public async Task<Response<bool>> DeleteAsync(string employeeId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _employeeRepository.DeleteAsync(employeeId);

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
