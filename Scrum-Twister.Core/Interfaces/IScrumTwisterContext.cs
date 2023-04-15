using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Scrum_Twister.Core.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.Interfaces
{
    public interface IScrumTwisterContext
    {
        ChangeTracker ChangeTracker { get; }
        IModel Model { get; }
        EntityEntry<TEntity> Add<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>([NotNullAttribute] TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        EntityEntry Remove([NotNullAttribute] object entity);

        DbSet<Avatar> Avatars { get; set; }
        DbSet<Participant> Participants { get; set; }
        DbSet<Session> Sessions { get; set; }
        DbSet<SessionStatus> SessionStatuses { get; set; }

    }
}
