using AutoMapper;
using TodoListAPI.Application.ValueObject;
using TodoListAPI.Domain.Interface;
using TodoListAPI.Domain.Models;

namespace TodoListAPI.Application.Services
{
	public class NoteService : INoteService
	{
		private readonly INoteRepository _repository;
		private readonly IMapper _mapper;

		public NoteService(INoteRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<NoteVO>> GetNotes()
		{
			var notes = await _repository.GetNotes();
			return _mapper.Map<IEnumerable<NoteVO>>(notes);

		}

		public async Task<NoteVO> GetNoteById(int id)
		{
			var note = await _repository.GetNote(id);

			return _mapper.Map<NoteVO>(note);
		}
		public async Task<Notes> Create(NoteVO noteVO)
		{
			var noteEntity = _mapper.Map<Notes>(noteVO);
			return await _repository.Create(noteEntity);
		}

		public async Task<Notes> Update(int id, NoteVO noteVO)
		{
			var note = await _repository.GetNote(id);
			note.Description = noteVO.Description;
			return await _repository.Update(note);
		}

		public async Task<Notes> Delete(int id)
		{
			if (id <= 0)
				throw new Exception("Id inválido!");
			return await _repository.Delete(id);
		}




	}
}
