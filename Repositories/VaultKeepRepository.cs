using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetAllVaultKeeps(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"SELECT * FROM vaultkeeps vk
INNER JOIN keeps k ON k.id = vk.keepId
WHERE(vaultId = @vaultId AND vk.userId = @userId)", new { vaultId, userId });
    }

    // public VaultKeep GetById(int Id)
    // {
    //   return _db.QueryFirstOrDefault<VaultKeep>("SELECT * FROM keeps WHERE id = @Id", new { Id });
    // }

    public VaultKeep CreateVaultKeep(VaultKeep payloadVK)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaultkeeps (vaultId, keepId, userId)
                    VALUES (@VaultId, @KeepId, @UserId);
                    SELECT LAST_INSERT_ID();
                ", payloadVK);
        payloadVK.Id = id;
        return payloadVK;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool Delete(int vaultId, int keepId, string userId)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps WHERE vaultId = @vaultId AND keepId = @keepId AND userId = @userId", new { vaultId, keepId, userId });
      return success > 0;
    }
  }
}