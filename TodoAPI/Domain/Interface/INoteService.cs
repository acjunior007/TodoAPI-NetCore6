using TodoListAPI.Application.ValueObject;
using TodoListAPI.Domain.Models;

namespace TodoListAPI.Domain.Interface
{
	public interface INoteService
	{
		Task<IEnumerable<NoteVO>> GetNotes();
		Task<NoteVO> GetNoteById(int id);

		Task<Notes> Create(NoteVO note);

		Task<Notes> Update(int id, NoteVO note);

		Task<bool> Delete(int id);
	}
}
