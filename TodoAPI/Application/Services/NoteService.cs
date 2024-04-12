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

		public async Task<NoteVO> Create(NoteVO noteVO)
		{
			var newNote = _mapper.Map<Notes>(noteVO);
			if (!newNote.ValidDescription())
				throw new Exception("Informar uma descrição!");

			newNote = await _repository.Create(newNote);

			return _mapper.Map<NoteVO>(newNote);
		}

		public async Task<NoteVO> Update(int id, NoteVO noteVO)
		{
			var note = await _repository.GetNote(id);
			note.Description = noteVO.Description;
			note.DateUpdated = DateTime.Now;
			note.Active = noteVO.Active;

			var noteUpdated = await _repository.Update(note);
			return _mapper.Map<NoteVO>(noteUpdated);
		}

		public async Task<bool> Delete(int id)
		{
			if (id <= 0)
				throw new Exception("Id inválido!");
			return await _repository.Delete(id);
		}




	}
}
