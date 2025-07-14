using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Models.Response;
using ToDo.API.Models.Todos;
using ToDo.Domain.Todos;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoService _todoService;
        private readonly IMapper _mapper;
        public TodosController(TodoService todoService,
                                IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Todo list.
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [ProducesResponseType(typeof(ApiResponseModel<IEnumerable<TodoViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseModel<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTodos()
        {
            try
            {
                var todos = await _todoService.GetTodoAsync();
                var result = _mapper.Map<IEnumerable<TodoViewModel>>(todos);
                return Ok(new ApiResponseModel<IEnumerable<TodoViewModel>> { Success = true, Data = result, Message = "Todo Fetch Succssfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel<object> { Success = false, Data = null, Message = ex.Message }); 
            }
        }

        /// <summary>
        /// Add Todo.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("add-todo")]
        [ProducesResponseType(typeof(ApiResponseModel<TodoViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseModel<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTodo(AddTodoRequestModel model)
        {
            try
            {
                var todo = _mapper.Map<Todo>(model);
                var addTodo = await _todoService.AddTodoAsync(todo);
                var result = _mapper.Map<TodoViewModel>(addTodo);
                return Ok(new ApiResponseModel<TodoViewModel> { Success = true, Data = result, Message = "Todo Add Succssfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel<object> { Success = false, Data = null, Message = ex.Message });
            }
        }

        /// <summary>
        /// Change complete status.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("change-todo-status")]
        [ProducesResponseType(typeof(ApiResponseModel<TodoViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseModel<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponseModel<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangeStatusTodo(UpdateTodoRequestModel model)
        {
            try
            {
                var existingTodo = await _todoService.GetTodoByIdAsync(Guid.Parse(model.Id));
                if (existingTodo == null) {
                    return NotFound(new ApiResponseModel<object> { Success = false, Data = null, Message = "Todo not found!" });
                }

                var todo = _mapper.Map(model, existingTodo);
                var updateTodo = await _todoService.UpdateTodoAsync(todo);
                var result = _mapper.Map<TodoViewModel>(updateTodo);
                return Ok(new ApiResponseModel<TodoViewModel> { Success = true, Data = result, Message = "Todo status is change Succssfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel<object> { Success = false, Data = null, Message = ex.Message });
            }
        }
    }
}
