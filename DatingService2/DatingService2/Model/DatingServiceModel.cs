using System.Data.Entity;
using DatingService2.Model.Tables;

namespace DatingService2.Model
{
    public partial class DatingServiceModel : DbContext
    {
        public DatingServiceModel()
            : base("name=DatingServiceEntity")
        {
        }

        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<PrivateInf> PrivateInfs { get; set; }
        public virtual DbSet<Requirement> Requirements { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Education)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Requirement)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Photo)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.PrivateInf)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
               .HasOptional(e => e.City)
               .WithRequired(e => e.Person);

            modelBuilder.Entity<PrivateInf>()
                .Property(e => e.Height)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PrivateInf>()
                .Property(e => e.Weight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Requirement>()
                .Property(e => e.PartnerSex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Requirement>()
                .Property(e => e.PartnerCity)
                .IsUnicode(false);

            modelBuilder.Entity<Requirement>()
                .Property(e => e.PartnerEducation)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userPassword)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Person)
                .WithRequired(e => e.User);

          
/*Хранимая процедура добавление private inf*/

            modelBuilder.Entity<PrivateInf>().MapToStoredProcedures(z => z.Insert(y => y.HasName("dbo.PrivateInf_Insert")
                .Parameter(p => p.Id, "Id")
                .Parameter(p => p.Height, "Height")
                .Parameter(p => p.Weight, "Weight")
                .Parameter(p => p.phone, "phone")));


            /*Хранимая процедура обновления private inf*/

            modelBuilder.Entity<PrivateInf>().MapToStoredProcedures(z => z.Update(y => y.HasName("dbo.PrivateInf_Update")
                .Parameter(p => p.Id, "Id")
                .Parameter(p => p.Height, "Height")
                .Parameter(p => p.Weight, "Weight")
                .Parameter(p => p.phone, "phone")));

            /*Хранимая процедура добавления записи в requirements*/
            modelBuilder.Entity<Requirement>().MapToStoredProcedures(z => z.Insert(y => y.HasName("dbo.Requirements_Insert")
              .Parameter(p => p.Id, "Id")
              .Parameter(p => p.PartnerSex, "PartnerSex")
              .Parameter(p => p.PartnerCity, "PartnerCity")
              .Parameter(p => p.AgeFrom, "AgeFrom")
              .Parameter(p => p.AgeAbove, "AgeAbove")
              .Parameter(p => p.PartnerEducation, "PartnerEducation")));

            /*Хранимая процедура добавления записи в city*/
            modelBuilder.Entity<City>().MapToStoredProcedures(z => z.Insert(y => y.HasName("dbo.City_Insert")
                .Parameter(p => p.Id, "Id")
                .Parameter(p => p.PersonCity, "PersonCity")));

            /*Хранимая процедура добавления записи в education*/
            modelBuilder.Entity<Education>().MapToStoredProcedures(z => z.Insert(y => y.HasName("dbo.Education_Insert")
               .Parameter(p => p.Id, "Id")
               .Parameter(p => p.PersonEducation, "PersonEducation")));


            /*Хранимая процедура обновлени записи в requirements*/
            modelBuilder.Entity<Requirement>().MapToStoredProcedures(z => z.Update(y => y.HasName("dbo.Reqiurements_Update")
               .Parameter(p => p.Id, "Id")
              .Parameter(p => p.PartnerSex, "PartnerSex")
              .Parameter(p => p.PartnerCity, "PartnerCity")
              .Parameter(p => p.AgeFrom, "AgeFrom")
              .Parameter(p => p.AgeAbove, "AgeAbove")
              .Parameter(p => p.PartnerEducation, "PartnerEducation")));

/*хранимая процедура удаления записи из requirements*/
            modelBuilder.Entity<Requirement>()
                .MapToStoredProcedures(z => z.Delete(y => y.HasName("dbo.Requirements_Delete")
                    .Parameter(p => p.Id, "Id")));

            /*хранимая процедура удаления записи из privateinf*/

            modelBuilder.Entity<PrivateInf>()
                .MapToStoredProcedures(z => z.Delete(y => y.HasName("dbo.PrivateInf_Delete")
                    .Parameter(p => p.Id, "Id")));
            /*хранимая процедура удаления записи из city*/
            modelBuilder.Entity<City>()
                .MapToStoredProcedures(z => z.Delete(y => y.HasName("dbo.City_Delete")
                    .Parameter(p => p.Id, "Id")));
            /*хранимая процедура удаления записи из education*/
            modelBuilder.Entity<Education>()
                .MapToStoredProcedures(z => z.Delete(y => y.HasName("dbo.Education_Delete")
                    .Parameter(p => p.Id, "Id")));
            /*Хранимая процедура обновлени записи в city*/
            modelBuilder.Entity<City>()
                .MapToStoredProcedures(z => z.Update(y => y.HasName("dbo.City_Update")
                    .Parameter(p => p.Id, "Id")
                    .Parameter(p => p.PersonCity, "PersonCity")));
            /*Хранимая процедура обновлени записи в education*/
            modelBuilder.Entity<Education>()
                .MapToStoredProcedures(z => z.Update(y => y.HasName("dbo.Education_Update")
                    .Parameter(p => p.Id, "Id")
                    .Parameter(p => p.PersonEducation, "PersonEducation")));

        }
    }
}
