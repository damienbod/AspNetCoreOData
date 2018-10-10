using Microsoft.EntityFrameworkCore;

namespace  AspNetCoreOData.Service.Database
{
    public partial class DomainModelContext : DbContext
    {
        public DomainModelContext(DbContextOptions<DomainModelContext> options): base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<BusinessEntity> BusinessEntity { get; set; }
        public virtual DbSet<BusinessEntityAddress> BusinessEntityAddress { get; set; }
        public virtual DbSet<BusinessEntityContact> BusinessEntityContact { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<CountryRegion> CountryRegion { get; set; }
        public virtual DbSet<EmailAddress> EmailAddress { get; set; }
        public virtual DbSet<Password> Password { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonPhone> PersonPhone { get; set; }
        public virtual DbSet<PhoneNumberType> PhoneNumberType { get; set; }
        public virtual DbSet<StateProvince> StateProvince { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactType>().Ignore(c => c.ModifiedDate);
            modelBuilder.Entity<ContactType>().Property( AspNetCoreOData.Service.Database.ContactType.ContactTypeExpressions.ModifiedDate).HasColumnName("ModifiedDate");

            modelBuilder.Entity<PhoneNumberType>().Ignore(c => c.ModifiedDate);
            modelBuilder.Entity<PhoneNumberType>().Property( AspNetCoreOData.Service.Database.PhoneNumberType.PhoneNumberTypeExpressions.ModifiedDate).HasColumnName("ModifiedDate");
       
            modelBuilder.Entity<Address>()
                .HasMany(e => e.BusinessEntityAddress)
                .WithOne(e => e.Address).IsRequired();

            modelBuilder.Entity<AddressType>()
                .HasMany(e => e.BusinessEntityAddress)
                .WithOne(e => e.AddressType).IsRequired();

            modelBuilder.Entity<BusinessEntity>()
                .HasMany(e => e.BusinessEntityAddress)
                .WithOne(e => e.BusinessEntity).IsRequired();

            modelBuilder.Entity<BusinessEntity>()
                .HasMany(e => e.BusinessEntityContact)
                .WithOne(e => e.BusinessEntity).IsRequired();

            modelBuilder.Entity<ContactType>()
                .HasMany(e => e.BusinessEntityContact)
                .WithOne(e => e.ContactType).IsRequired();

            modelBuilder.Entity<CountryRegion>()
                .HasMany(e => e.StateProvince)
                .WithOne(e => e.CountryRegion).IsRequired();

            modelBuilder.Entity<Password>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<Password>()
                .Property(e => e.PasswordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonType)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.BusinessEntityContact)
                .WithOne(e => e.Person).IsRequired()
                .HasForeignKey(e => e.PersonID);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.EmailAddress)
                .WithOne(e => e.Person).IsRequired();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonPhone)
                .WithOne(e => e.Person).IsRequired();

            modelBuilder.Entity<PhoneNumberType>()
                .HasMany(e => e.PersonPhone)
                .WithOne(e => e.PhoneNumberType).IsRequired();

            modelBuilder.Entity<StateProvince>()
                .Property(e => e.StateProvinceCode)
                .IsFixedLength();

            modelBuilder.Entity<StateProvince>()
                .HasMany(e => e.Address)
                .WithOne(e => e.StateProvince).IsRequired();
        }
    }
}
