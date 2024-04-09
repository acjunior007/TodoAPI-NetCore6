using AutoFixture;
using AutoMapper;
using TodoListAPI.Application.ValueObject;
using TodoListAPI.Domain.Interface;

namespace TodoListAPI.Test.Services
{
	public class UnitTest1
	{
		private readonly INoteService _noteService;
		private readonly IMapper _mapper;

		public UnitTest1(INoteService noteService, IMapper mapper)
		{
			_noteService = noteService;
			_mapper = mapper;
		}

		[Fact]
		public async void ValidDescriptionNewCreateAsync()
		{
			var noteVO = new NoteVO();
			var note = await _noteService.Create(noteVO);
			var isCreate = note.Id > 0;
			Assert.True(isCreate);
		}

		[Fact]
		public async void CreateNewNoteAsync()
		{
			// Arrange
			var noteVO = new NoteVO() { Description = "Description test" };

			var note = await _noteService.Create(noteVO);
			var isCreate = note.Id > 0;
			Assert.True(isCreate);
		}

	}
}