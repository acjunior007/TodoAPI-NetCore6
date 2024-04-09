using AutoFixture;
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
		public async void InvalidDescriptionNewCreateAsync()
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

			//Assert.True(true);
		}

		[Fact]
		public async void GetNoteAsync()
		{
			//// Arrange
			var noteVO = new NoteVO() { Description = "Description test" };

			var note = await _noteService.Create(noteVO);
			var isCreate = note.Id > 0;

			Assert.True(isCreate);
		}

		[Fact]
		public async void CreateNoteAsync()
		{
			var noteVO = new NoteVO() { Description = "Description test" };

			var note = await _noteService.Create(noteVO);
			var isCreate = note.Id > 0;

			Assert.True(isCreate);
		}

		[Fact]
		public async void UpdateNoteAsync()
		{
			// Arrange
			var noteVO = new NoteVO() { Id = 1, Description = "Description test update" };

			var note = await _noteService.Update(1, noteVO);
			var isCreate = note.Id > 0;
			Assert.True(isCreate);
		}

		[Fact]
		public async void DeleteNoteAsync()
		{
			// Arrange
			var id = 1;

			var isDeleted = await _noteService.Delete(id);

			Assert.True(isDeleted);

		}
	}
}