using Microsoft.EntityFrameworkCore;
using TodoListAPI.Domain.Interface;
using TodoListAPI.Domain.Models;
using TodoListAPI.Infra.Context;

namespace TodoListAPI.Infra.Repository
{
	public class NoteRepository : INoteRepository
	{
		private readonly DBTodoAPPContext _context;

		public NoteRepository(DBTodoAPPContext context)
		{
			_context = context;
		}

		public async Task<Notes> GetNote(int id)
		{
			var note = await _context.Notes.FindAsync(id);
			return note ?? throw new Exception("Tarefa não encontrada!");
		}

		public async Task<IEnumerable<Notes>> GetNotes()
		{
			return await _context.Notes.ToListAsync();
		}

		public async Task<Notes> Create(Notes notes)
		{
			_context.Notes.Add(notes);
			await _context.SaveChangesAsync();
			return notes;
		}

		public async Task<Notes> Update(Notes notes)
		{
			var note = await _context.Notes.FindAsync(notes.Id);
			if (note == null) { throw new Exception("Tarefa não encontrada!"); }

			_context.Entry(notes).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return note;
		}

		public async Task<bool> Delete(int id)
		{
			var note = _context.Notes.Find(id);
			if (note == null) { throw new Exception("Tarefa não encontrada!"); }

			_context.Notes.Remove(note);
			var qtd = await _context.SaveChangesAsync();
			return qtd > 0;
		}
	}
}
