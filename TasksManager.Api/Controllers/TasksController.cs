using Microsoft.AspNetCore.Mvc;
using TasksManager.Api.DTOs;
using TasksManager.Api.Services.Interfaces;

namespace TasksManager.Api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;
        private ResponseDto _responseDto = new();

        public TasksController(ITaskService service)
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var items = await _service.GetTasksAsync("17d804c8-8e94-4910-8223-c0533e4b20ba".ToUpper());

                _responseDto.Success = true;
                _responseDto.Message = "Ok";
                _responseDto.Result = items;

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;

                return BadRequest(_responseDto);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var item = await _service.GetTaskAsync(id, "17d804c8-8e94-4910-8223-c0533e4b20ba".ToUpper());

                _responseDto.Success = true;
                _responseDto.Message = "Ok";
                _responseDto.Result = item;

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;

                return BadRequest(_responseDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TaskRequestDto request)
        {
            try
            {
                var item = await _service.CreateTaskAsync(request, "17d804c8-8e94-4910-8223-c0533e4b20ba".ToUpper());

                _responseDto.Success = true;
                _responseDto.Message = "Ok";
                _responseDto.Result = item;

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;

                return BadRequest(_responseDto);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, TaskRequestDto request)
        {
            try
            {
                var item = await _service.UpdateTaskAsync(id, "17d804c8-8e94-4910-8223-c0533e4b20ba".ToUpper(), request);

                _responseDto.Success = true;
                _responseDto.Message = "Ok";
                _responseDto.Result = item;

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;

                return BadRequest(_responseDto);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteTaskAsync(id, "17d804c8-8e94-4910-8223-c0533e4b20ba".ToUpper());

                _responseDto.Success = true;
                _responseDto.Message = "Ok";
                _responseDto.Result = null;

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;

                return BadRequest(_responseDto);
            }
        }
    }
}
