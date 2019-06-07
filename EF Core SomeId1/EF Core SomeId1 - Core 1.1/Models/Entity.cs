using SQLite;

namespace EF_Core_SomeId1.Models
{
    public abstract class Entity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}