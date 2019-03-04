using MyNote.DataAccessLayer.EntityFramework;
using MyNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.BusinessLayer
{
    public class Test 
    {
        private Repository<User> repo_user = new Repository<User>();
        private Repository<Category> repo_category = new Repository<Category>();
        private Repository<Comment> repo_comment = new Repository<Comment>();
        private Repository<Note> repo_note = new Repository<Note>();

        public Test()
        {
            //*************Repository'den önce database'i oluşturma işlemleri*************
            //DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
            //db.Categories.ToList();

            //repository test işlemleri
            //Repository<Category> repo = new Repository<Category>();
            List<Category> categories= repo_category.List();
            List<Category> categories_filtered = repo_category.List(x => x.Id > 5);
        }

        public void InsertTest()
        {
            int result = repo_user.Insert(new User()
            {
                Name = "aa",
                Surname = "bb",
                Email = "aabb@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "aabb",
                Password = "654321",
                ProfileImageFilename = "user_boy.png",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "tlhdgn"
            });
        }

        public void UpdateTest()
        {
            User user = repo_user.Find(x => x.Username == "aabb");
            if(user !=null)
            {
                user.Username = "xxxx";
                int result = repo_user.Update(user);
            }
        }

        public void DeleteTest()
        {
            User user = repo_user.Find(x => x.Username == "xxxx");
            if(user!=null)
            {
                int result = repo_user.Delete(user);
            }
        }

        public void CommentTest()
        {
            User user = repo_user.Find(x => x.Id == 1);
            Note note = repo_note.Find(x => x.Id == 3);

            Comment comment = new Comment()
            {
                Text = "Test yorum",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "tlhdgn",
                Note = note,
                Owner = user
            };

            repo_comment.Insert(comment);
        }
    }
}
