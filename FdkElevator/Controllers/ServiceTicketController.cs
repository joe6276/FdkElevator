using AutoMapper;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceDTO;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTicketController : ControllerBase
    {

        private readonly IServiceTicket _serviceTicket;
        private readonly IMapper _mapper;

        public ServiceTicketController(IServiceTicket serviceTicket, IMapper mapper)
        {
            _serviceTicket=serviceTicket;
            _mapper=mapper;
        }
        [HttpPost]
        public async Task<ActionResult<string>> addTickerService(CreateServiceTicketRequest request )
        {
            try
            {
                var ticket= _mapper.Map<ServiceTicket>(request);

                var result =  await _serviceTicket.addServiceTicket(ticket);

                return Ok(result);

            }catch ( Exception ex )
            {
                return BadRequest(ex.Message );
            }
        }

        //[HttpGet("client/{clientId}")]
        //public async Task<ActionResult<List<ServiceTicket>>> getTicketBycLientId(Guid clientId)
        //{
        //    try
        //    {
        //        var result = await _serviceTicket.getServiceTicketByClientId(clientId);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<List<ServiceTicket>>> getTicketBycLientId(Guid clientId)
        {
            try
            {
                var result = await _serviceTicket.getServiceTicketByClientId(clientId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<List<ServiceTicket>>> getTicketByProjectId(Guid projectId)
        {
            try
            {
                var result = await _serviceTicket.getServiceTicketByProjectId(projectId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("lift/{liftAssetId}")]
        public async Task<ActionResult<List<ServiceTicket>>> getTicketByLiftAssetById(Guid liftAssetId)
        {
            try
            {
                var result = await _serviceTicket.getServiceTicketByLiftAssetId(liftAssetId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<string>> updateServiceTicket(Guid Id, CreateServiceTicketRequest request)
        {
            try
            {
                var existingServiceTicket = await _serviceTicket.getServiceTickerById(Id);

                if (existingServiceTicket == null)
                {
                    return NotFound("Service Ticket Not Found");
                }

                var tickerService = _mapper.Map(request, existingServiceTicket);
                var result = await _serviceTicket.updateServiceTicket(tickerService);

                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<string>> deleteServiceTicket(Guid Id)
        {
            try
            {
                var existingServiceTicket = await _serviceTicket.getServiceTickerById(Id);

                if (existingServiceTicket == null)
                {
                    return NotFound("Service Ticket Not Found");
                }

                var result = await _serviceTicket.deleteServiceTicket(existingServiceTicket);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
