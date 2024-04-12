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
			NoteVO noteVO = await CreateNote();
			var isCreate = noteVO.Id > 0;

			Assert.True(isCreate);
		}

		[Fact]
		public async void UpdateNote_NewValueDescription_NoteUpdated()
		{
			NoteVO noteVO = await CreateNote();
			NoteVO noteVOUpdate = new NoteVO() { Id = noteVO.Id, Description = "Description test update.." };

			NoteVO noteUpdated = await _noteService.Update(noteVO.Id, noteVOUpdate);
			var isCreate = noteUpdated.Id > 0;

			Assert.True(isCreate);
		}

		[Fact]
		public async void DeleteNote_ById_ReturnsTrue()
		{
			NoteVO noteVO = await CreateNote();
			var isDeleted = await _noteService.Delete(noteVO.Id);

			Assert.True(isDeleted);
		}

		#region Privates methods
		private async Task<NoteVO> CreateNote()
		{
			var noteVO = new NoteVO() { Description = "Description test" };

			var noteCreated = await _noteService.Create(noteVO);
			return noteCreated;
		}
		#endregion
	}
}