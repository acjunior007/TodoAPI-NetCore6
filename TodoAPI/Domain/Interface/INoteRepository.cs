using TodoListAPI.Domain.Models;

namespace TodoListAPI.Domain.Interface
{
    public interface INoteRepository
    {
        Task<IEnumerable<Notes>> GetNotes();
        Task<Notes> GetNote(int id);

        Task<Notes> Create(Notes notes);

        Task<Notes> Update(Notes notes);

        Task<Notes> Delete(int id);
    }
}
