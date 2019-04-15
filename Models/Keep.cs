using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public string UserId { get; set; }
    public string Img { get; set; }
    public int IsPrivate { get; set; }
    public int Views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }
  }
}






// CREATE TABLE keeps(
// --     id int NOT NULL AUTO_INCREMENT,
// --     name VARCHAR(20) NOT NULL,
// --     description VARCHAR(255) NOT NULL,
// --     userId VARCHAR(255),
// --     img VARCHAR(255),
// --     isPrivate TINYINT,
// --     views INT DEFAULT 0,
// --     shares INT DEFAULT 0,
// --     keeps INT DEFAULT 0,
// --     INDEX userId(userId),
// --     FOREIGN KEY(userId)
// --         REFERENCES users(id)
// --         ON DELETE CASCADE,  
// --     PRIMARY KEY(id)
// -- );