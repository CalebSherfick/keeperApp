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

    public IEnumerable<VaultKeep> GetALL()
    {
      return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps");
    }

    // public VaultKeep GetById(int Id)
    // {
    //   return _db.QueryFirstOrDefault<VaultKeep>("SELECT * FROM keeps WHERE id = @Id", new { Id });
    // }

    public VaultKeep CreateKeep(VaultKeep vaultKeep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO keeps (name, description, userId, img)
                    VALUES (@Name, @Description, @UserId, @Img);
                    SELECT LAST_INSERT_ID();
                ", vaultKeep);
        vaultKeep.Id = id;
        return vaultKeep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps WHERE id = @id", new { id });
      return success > 0;
    }
  }
}