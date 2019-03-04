using MyNote.DataAccessLayer.EntityFramework;
using MyNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.BusinessLayer
{
    public class NoteManager
    {
        private Repository<Note> repo_note = new Repository<Note>();

        public List<Note> GetAllNote()
        {
            return repo_note.List();
        }
        public Note Find(Expression<Func<Note, bool>> where)
        {
            return repo_note.Find(where);
        }
    }
}
