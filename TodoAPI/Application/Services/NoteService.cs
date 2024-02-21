using TodoAPI.Domain.Interface;
using TodoAPI.Domain.Models;

namespace TodoAPI.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _repository;

        public NoteService(INoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notes> Create(Notes notes)
        {
            return await _repository.Create(notes);
        }

        public async Task<Notes> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Notes> GetNote(int id)
        {
            return await _repository.GetNote(id);
        }

        public async Task<IEnumerable<Notes>> GetNotes()
        {
            return await _repository.GetNotes();
        }

        public async Task<Notes> Update(Notes notes)
        {
            return await _repository.Update(notes);
        }
    }
}
