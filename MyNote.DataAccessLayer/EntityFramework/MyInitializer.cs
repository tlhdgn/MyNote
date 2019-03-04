using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyNote.Entities;

namespace MyNote.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        //Admin kullanıcı ekleme
        protected override void Seed(DatabaseContext context)
        {
            User admin = new User()
            {
                Name = "Talha",
                Surname = "Doğan",
                Email = "talhadogan16@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "tlhdgn",
                ProfileImageFilename = "user_boy.png",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "tlhdgn"
            };


            // Standart kullanıcı ekleme
            User standartUser = new User()
            {
                Name = "xxx",
                Surname = "yyy",
                Email = "xxyy@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "xxyy",
                Password = "654321",
                ProfileImageFilename = "user_boy.png",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "tlhdgn"
            };

            context.Users.Add(admin);
            context.Users.Add(standartUser);

            for (int i = 0; i < 8; i++)
            {
                User user = new User()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ProfileImageFilename = "user_boy.png",
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    Username = $"user{i}",
                    Password = "123",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user{i}"
                };

                context.Users.Add(user);
            }

            context.SaveChanges();

            
            List<User> userlist = context.Users.ToList();

            // fake kategori ekleme
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "tlhdgn"
                };

                context.Categories.Add(cat);

                // fake not ekleme..
                for (int k = 0; k < FakeData.NumberData.GetNumber(5, 9); k++)
                {
                    User owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];

                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner = owner,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = owner.Username,
                    };

                    cat.Notes.Add(note);

                    // Fake yorum ekleme
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        User comment_owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];

                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner = comment_owner,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = comment_owner.Username
                        };

                        note.Comments.Add(comment);
                    }

                    // fake like ekleme..

                    for (int m = 0; m < note.LikeCount; m++)
                    {
                        Liked liked = new Liked()
                        {
                            LikedUser = userlist[m]
                        };

                        note.Likes.Add(liked);
                    }

                }

            }

            context.SaveChanges();


        }
    }
}
