using AutoMapper;
using TodoListAPI.Application.ValueObject;
using TodoListAPI.Domain.Interface;

namespace TodoListAPI.Test.Services
{
	public class NoteServiceTest
	{
		private readonly INoteService _noteService;
		private readonly IMapper _mapper;

		public NoteServiceTest(INoteService noteService, IMapper mapper)
		{
			_noteService = noteService;
			_mapper = mapper;
		}

		[Fact]
		public async Task CreateNote_DescriptionWithoutValue_Exception()
		{
			var noteVO = new NoteVO();
			try
			{
				var note = await _noteService.Create(noteVO);
				var isCreate = note.Id > 0;

			}
			catch (Exception ex)
			{
				Assert.IsType<Exception>(ex);
			}
		}

		[Fact]
		public async void CreateNote_DescriptionWithValue_NoteCreated()
		{
			var noteVO = new NoteVO() { Description = "Description test" };

			var note = await _noteService.Create(noteVO);
			var isCreate = note.Id > 0;

			Assert.True(isCreate);
		}

		[Fact]
		public async void UpdateNote_NewValueDescription_NoteUpdated()
		{
			var id = 3;
			var noteVO = new NoteVO() { Id = id, Description = "Description test update.." };

			var note = await _noteService.Update(id, noteVO);
			var isCreate = note.Id > 0;

			Assert.True(isCreate);
		}

		[Fact]
		public async void DeleteNote_ById_ReturnsTrue()
		{
			var id = 4;
			var isDeleted = await _noteService.Delete(id);

			Assert.True(isDeleted);
		}
	}
}