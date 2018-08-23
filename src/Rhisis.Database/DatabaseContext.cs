﻿using Microsoft.EntityFrameworkCore;
using Rhisis.Database.Entities;
using System;

namespace Rhisis.Database
{
    public sealed class DatabaseContext : DbContext
    {
        private const string MySqlConnectionString = "server={0};userid={1};pwd={2};port={4};database={3};sslmode=none;";
        private const string MsSqlConnectionString = "Server={0},{1};Database={2};User Id={3};Password={4};";

        private readonly DatabaseConfiguration _databaseConfiguration;

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<DbUser> Users { get; set; }

        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        public DbSet<DbCharacter> Characters { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public DbSet<DbItem> Items { get; set; }

        /// <summary>
        /// Create a new <see cref="DatabaseContext"/> instance.
        /// </summary>
        /// <param name="options"></param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Creates a new <see cref="DatabaseContext"/> instance.
        /// </summary>
        /// <param name="databaseConfiguration"></param>
        public DatabaseContext(DatabaseConfiguration databaseConfiguration)
        {
            this._databaseConfiguration = databaseConfiguration;
        }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            switch (this._databaseConfiguration.Provider)
            {
                case DatabaseProvider.MySql:
                    optionsBuilder.UseMySql(
                        string.Format(MsSqlConnectionString,
                            this._databaseConfiguration.Host,
                            this._databaseConfiguration.Username,
                            this._databaseConfiguration.Password,
                            this._databaseConfiguration.Database,
                            this._databaseConfiguration.Port));
                    break;

                case DatabaseProvider.MsSql:
                    optionsBuilder.UseSqlServer(
                        string.Format(MySqlConnectionString,
                            this._databaseConfiguration.Host,
                            this._databaseConfiguration.Port,
                            this._databaseConfiguration.Database,
                            this._databaseConfiguration.Username,
                            this._databaseConfiguration.Password));
                    break;

                default: throw new NotImplementedException();
            }
        }
    }
}
