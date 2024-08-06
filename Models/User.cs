using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebsite.Models
{
    [Table("ListUser")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
