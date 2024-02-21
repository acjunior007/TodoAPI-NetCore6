using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Interface
{
    public interface INoteService
    {
        Task<IEnumerable<Notes>> GetNotes();
        Task<Notes> GetNote(int id);

        Task<Notes> Create(Notes notes);

        Task<Notes> Update(Notes notes);

        Task<Notes> Delete(int id);
    }
}
