using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace SharedRepository
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(50)")]
        public string Email { get; set; }

        [Required]
        public byte[] UHash { get; set; }

        [Required]
        public byte[] UKey { get; set; }


        public void GeneratePassword(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                UKey = hmac.Key;
                UHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }


        public bool ValidatePassword(string password)
        {
            using (var hmac = new HMACSHA512(UKey))
            {
                var _uhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i=0; i<_uhash.Length; i++)
                {
                    if (_uhash[i] != UHash[i])
                        return false;
                }
            }

            return true;
        }
    }
}
