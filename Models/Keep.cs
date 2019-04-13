namespace keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int userId { get; set; }
    public string img { get; set; }
    public int views { get; set; }
    public int shares { get; set; }
    public int keeps { get; set; }

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