using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace tincApi.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Apelido { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public bool IsLocked { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}