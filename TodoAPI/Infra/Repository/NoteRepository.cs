using Microsoft.EntityFrameworkCore;
using TodoAPI.Domain.Interface;
using TodoAPI.Domain.Models;
using TodoAPI.Infra.Context;

namespace TodoAPI.Infra.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly DBTodoAPPContext _context;

        public NoteRepository(DBTodoAPPContext context) {
            _context = context;
        }
        public async Task<Notes> Create(Notes notes)
        {
            _context.Notes.Add(notes);
            await _context.SaveChangesAsync();
            return notes;
        }

        public async Task<Notes> Delete(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null) { throw new Exception("Note not found"); }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<Notes> GetNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            return note ?? throw new Exception("Note not found!");
        }

        public async Task<IEnumerable<Notes>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Notes> Update(Notes notes)
        {
            var note = await _context.Notes.FindAsync(notes.Id);
            if (note == null) { throw new Exception("Note Not found!"); }

            _context.Entry(notes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return note;
        }
    }
}
