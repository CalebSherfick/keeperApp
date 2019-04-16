using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> GetALL()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
    }

    public Vault CreateVault(Vault vault)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaults (name, description, userId)
                    VALUES (@Name, @Description, @UserId);
                    SELECT LAST_INSERT_ID();
                ", vault);
        vault.Id = id;
        return vault;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      return success > 0;
    }
  }
}