using Microsoft.EntityFrameworkCore;
using ReservationSystem.Core.Models;

namespace ReservationSystem.Data
{
    public class ReservationSystemContext : DbContext
    {
        public ReservationSystemContext(DbContextOptions<ReservationSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Table relations and constraints go here

            builder.Entity<Reservation>(r =>
            {
                r.HasOne(x=>x.Contact)
                .WithMany()
                .HasForeignKey(r => r.ContactId);

                r.Property(r => r.Date)
                .IsRequired();

                r.Property(r => r.Ranking)
                .HasDefaultValue(0);

                r.Property(r => r.RatesCount)
                .HasDefaultValue(0);

                r.Property(r => r.Favorite)
                .HasDefaultValue(false);
            });

            builder.Entity<Contact>(c =>
            {
                c.HasOne(x=>x.ContactType)
                .WithMany()
                .HasForeignKey(c => c.ContactTypeId);

                c.HasIndex(c => c.Name)
                .IsUnique();

                c.Property(c => c.Name)
                .IsRequired();

                c.Property(c => c.BirthDate)
                .IsRequired();

                c.Property(c => c.ContactTypeId)
                .IsRequired();
            });

            builder.Entity<ContactType>(ct => {
                ct.HasIndex(ct => ct.Name)
                .IsUnique();

                ct.Property(ct => ct.Name)
                .IsRequired();
            });
                
        }
    }
}
