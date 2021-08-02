using Employee.API.CustomRequestValidation;
using Employee.API.ResponseHandler;
using EmployeeBLL.DTOs;
using EmployeeBLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        // GET: api/Employee/GetEmployees
        [HttpGet]
        [Route("GetEmployees")]       
        public async Task<ApiResponse> GetEmployees()
        {
            try
            {
                var data = await _employeeManager.GetEmployees();
                return new ApiOkResponse(data);
            }
            catch (Exception ex)
            {
                return new ApiResponse((int)HttpStatusCode.InternalServerError, "Error Occured While executing request");
            }
        }

        // GET api/Employee/GetEmployee/1
        [HttpGet]
        [Route("GetEmployee/{id}")]
        public async Task<ApiResponse> Get(int id)
        {
            try
            {
                var data = await _employeeManager.GetEmployee(id);
                if(data == null)
                {
                    return new ApiResponse((int)HttpStatusCode.NotFound);
                }
                return new ApiOkResponse(data);
            }
            catch (Exception ex)
            {
                return new ApiResponse((int)HttpStatusCode.InternalServerError, "Error Occured While executing request");
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<ApiResponse> CreateEmployee([FromBody] EmployeeDto employee)
        {
            try
            {
                var data = await _employeeManager.CreateEmployee(employee);
                // if success then returns the id of created employee
                return new ApiOkResponse(data, "Data Created Successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse((int)HttpStatusCode.InternalServerError, "Error Occured While executing request");
            }
        }

        // PUT api/Employee/UpdateEmployee/1
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public async Task<ApiResponse> UpdateEmployee(int id,[FromBody] EmployeeDto employee)
        {
            try
            {
                var data = await _employeeManager.UpdateEmployee(id,employee); 
                // if success then returns the id of updated employee
                if(data>0)
                {
                    return new ApiOkResponse(data,"Data Updated Successfully");
                }
                return new ApiBadRequestResponse(ModelState);
            }
            catch (Exception ex)
            {
                return new ApiResponse((int)HttpStatusCode.InternalServerError, "Error Occured While executing request");
            }
        }

        // DELETE api/Employee/DeleteEmployee/1
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            try
            {
                var data = await _employeeManager.DeleteEmployee(id);
                return new ApiOkResponse(new { result = data });
            }
            catch (Exception ex)
            {
                return new ApiResponse((int)HttpStatusCode.InternalServerError, "Error Occured While executing request");
            }
        }
    }
}
