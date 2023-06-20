using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swim_Feedback.Data;
using Swim_Feedback.Enums;

namespace Swim_Feedback.Services
{
    public class TestDataService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public TestDataService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public void AddTestData()
        {
            AddBodyParts();
            AddAccessories();
            AddStudentImage();
            AddSwimClass();
            AddStudents();
            AddStudentFeedback();
            AddTeacherFeedback();
        }

        public void AddStudentImage()
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //dbContext.StudentImages.Add(new StudentImage());

            dbContext.SaveChanges();
        }

        public void AddSwimClass()
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.SwimClasses.Add(new SwimClass("A"));
            dbContext.SwimClasses.Add(new SwimClass("B"));
            dbContext.SwimClasses.Add(new SwimClass("C"));
            dbContext.SwimClasses.Add(new SwimClass("D"));
            dbContext.SwimClasses.Add(new SwimClass("E"));

            dbContext.SaveChanges();
        }

        public void AddStudents()
        {
            Random random = new Random();

            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            SwimClass scA = dbContext.SwimClasses.Where(sc => sc.Name == "A").FirstOrDefault();
            SwimClass scB = dbContext.SwimClasses.Where(sc => sc.Name == "B").FirstOrDefault();
            SwimClass scC = dbContext.SwimClasses.Where(sc => sc.Name == "C").FirstOrDefault();

            dbContext.Students.Add(new Student(null, scA, random.Next(1_000, 10_000), "Olivia"));
            dbContext.Students.Add(new Student(null, scA, random.Next(1_000, 10_000), "Noah"));
            dbContext.Students.Add(new Student(null, scA, random.Next(1_000, 10_000), "Emma"));
            dbContext.Students.Add(new Student(null, scA, random.Next(1_000, 10_000), "Sam"));
            dbContext.Students.Add(new Student(null, scA, random.Next(1_000, 10_000), "Liam"));
            dbContext.Students.Add(new Student(null, scA, random.Next(1_000, 10_000), "Liam"));

            dbContext.Students.Add(new Student(null, scB, random.Next(1_000, 10_000), "Julia"));
            dbContext.Students.Add(new Student(null, scB, random.Next(1_000, 10_000), "Isa"));
            dbContext.Students.Add(new Student(null, scB, random.Next(1_000, 10_000), "Lucas"));
            dbContext.Students.Add(new Student(null, scB, random.Next(1_000, 10_000), "Mila"));
            dbContext.Students.Add(new Student(null, scB, random.Next(1_000, 10_000), "Bo"));

            dbContext.Students.Add(new Student(null, scC, random.Next(1_000, 10_000), "Bo"));
            dbContext.Students.Add(new Student(null, scC, random.Next(1_000, 10_000), "Bo"));
            dbContext.Students.Add(new Student(null, scC, random.Next(1_000, 10_000), "Sophie"));
            dbContext.Students.Add(new Student(null, scC, random.Next(1_000, 10_000), "Jip"));

            dbContext.SaveChanges();
        }

        public void AddStudentFeedback()
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //dbContext.StudentFeedbacks.Add(new StudentFeedback());

            Random rnd = new();

            string[] topics = { "Dierentuin", "Bellen blazen", "Hoep" };

            for (int i = 0; i < 50; i++)
            {
                string? topic = null;
                if (rnd.Next(5) == 1)
                {
                    topic = topics[rnd.Next(topics.Length)];
                }

                dbContext.StudentFeedbacks.Add(new StudentFeedback(topic, (rnd.Next(10) + 1) * 10, DateTimeOffset.Now));
            }

            dbContext.SaveChanges();
        }

        public void AddTeacherFeedback()
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //dbContext.TeacherFeedbacks.Add(new TeacherFeedback());

            dbContext.SaveChanges();
        }

        public void AddBodyParts()
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            string missing = Convert.ToBase64String(File.ReadAllBytes(Directory.GetCurrentDirectory() + @"\Assets\BodyPartImages\Missing.png"));

            string FaceFormsOval = Convert.ToBase64String(File.ReadAllBytes(Directory.GetCurrentDirectory() + @"\Assets\BodyPartImages\FaceForms\Oval.png"));

            string EyePairsBlack = Convert.ToBase64String(File.ReadAllBytes(Directory.GetCurrentDirectory() + @"\Assets\BodyPartImages\EyePairs\Black.png"));
            string EyePairGreen = Convert.ToBase64String(File.ReadAllBytes(Directory.GetCurrentDirectory() + @"\Assets\BodyPartImages\EyePairs\Green.png"));

            //dbContext.BodyParts.Add(new BodyPart(EBodyPartType.Skin, "Wit", missingImage));
            //dbContext.BodyParts.Add(new BodyPart(EBodyPartType.Skin, "Donker", missingImage));

            //dbContext.BodyParts.Add(new BodyPart(EBodyPartType.FaceForm, "Dun", missingImage));
            //dbContext.BodyParts.Add(new BodyPart(EBodyPartType.FaceForm, "Normaal", missingImage));
            //dbContext.BodyParts.Add(new BodyPart(EBodyPartType.FaceForm, "Bol", missingImage));

            //dbContext.BodyParts.Add(new BodyPart(EBodyPartType.Hair, "Lang", missingImage));
            //dbContext.BodyParts.Add(new BodyPart(EBodyPartType.Hair, "Kort", missingImage));

            //dbContext.BodyParts.Add(new BodyPart(EBodyPartType.EyePair, "Blauw", missingImage));
            //dbContext.BodyParts.Add(new BodyPart(EBodyPartType.EyePair, "Groen", missingImage));

            //dbContext.BodyParts.Add(new BodyPart(EBodyPartType.Mouth, "Lauch", missingImage));
            //dbContext.BodyParts.Add(new BodyPart(EBodyPartType.Mouth, "Gekke bek", missingImage));


            dbContext.BodyParts.Add(new BodyPart(EBodyPartType.FaceForm, "Oval", FaceFormsOval));

            dbContext.BodyParts.Add(new BodyPart(EBodyPartType.EyePair, "Black", EyePairsBlack));
            dbContext.BodyParts.Add(new BodyPart(EBodyPartType.EyePair, "Green", EyePairGreen));

            dbContext.SaveChanges();
        }

        public void AddAccessories()
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            string missingImage = Convert.ToBase64String(File.ReadAllBytes(Directory.GetCurrentDirectory() + @"\Assets\AccessoryImages\Missing.png"));
            string hogeHoedImage = Convert.ToBase64String(File.ReadAllBytes(Directory.GetCurrentDirectory() + @"\Assets\AccessoryImages\Hoge hoed.png"));
            string petImage = Convert.ToBase64String(File.ReadAllBytes(Directory.GetCurrentDirectory() + @"\Assets\AccessoryImages\Pet.png"));

            dbContext.Accessories.Add(new Accessory(EAccessoryType.Background, "Grijs", 0, missingImage));
            dbContext.Accessories.Add(new Accessory(EAccessoryType.Background, "Groen", 15, missingImage));
            dbContext.Accessories.Add(new Accessory(EAccessoryType.Background, "Bubbels", 20, missingImage));

            dbContext.Accessories.Add(new Accessory(EAccessoryType.Hair, "Haarknip", 0, missingImage));
            dbContext.Accessories.Add(new Accessory(EAccessoryType.Hair, "Hoge hoed", 20, hogeHoedImage));
            dbContext.Accessories.Add(new Accessory(EAccessoryType.Hair, "Pet", 15, petImage));

            dbContext.Accessories.Add(new Accessory(EAccessoryType.EyePair, "Ronde bril", 0, missingImage));
            dbContext.Accessories.Add(new Accessory(EAccessoryType.EyePair, "Zonnebril", 10, missingImage));
            dbContext.Accessories.Add(new Accessory(EAccessoryType.EyePair, "Ooglap", 15, missingImage));

            dbContext.Accessories.Add(new Accessory(EAccessoryType.Mouth, "Lipstick", 0, missingImage));
            dbContext.Accessories.Add(new Accessory(EAccessoryType.Mouth, "Snorkel", 10, missingImage));

            dbContext.Accessories.Add(new Accessory(EAccessoryType.Neck, "Krappe band om hals ding", 0, missingImage));
            dbContext.Accessories.Add(new Accessory(EAccessoryType.Neck, "Goude ketting", 15, missingImage));
            dbContext.Accessories.Add(new Accessory(EAccessoryType.Neck, "Sjaal", 10, missingImage));

            dbContext.SaveChanges();
        }

        public void ClearDatabase()
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE StudentImages");
            dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE SwimClasses");
            dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE Students");
            dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE StudentFeedbacks");
            dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE TeacherFeedbacks");

            dbContext.SaveChanges();
        }
    }
}
