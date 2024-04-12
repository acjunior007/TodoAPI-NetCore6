using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Application.ValueObject;
using TodoListAPI.Domain.Interface;

namespace TodoListAPI.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class TodoAppController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly INoteService _noteService;

		public TodoAppController(IConfiguration configuration, INoteService noteService)
		{
			_configuration = configuration;
			_noteService = noteService;
		}

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			try
			{
				var notes = await _noteService.GetNotes();
				return Ok(notes);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GeById(int id)
		{
			try
			{
				var note = await _noteService.GetNoteById(id);
				return Ok(note);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] NoteVO noteVO)
		{
			try
			{
				var note = await _noteService.Create(noteVO);
				return Ok(note);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] NoteVO noteVO)
		{
			try
			{
				var note = await _noteService.Update(id, noteVO);
				return Ok(note);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				var isDeleted = await _noteService.Delete(id);
				return Ok(isDeleted);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
