using TodoListAPI.Application.ValueObject;

namespace TodoListAPI.Domain.Interface
{
	public interface INoteService
	{
		Task<IEnumerable<NoteVO>> GetNotes();
		Task<NoteVO> GetNoteById(int id);

		Task<NoteVO> Create(NoteVO note);

		Task<NoteVO> Update(int id, NoteVO note);

		Task<bool> Delete(int id);
	}
}
