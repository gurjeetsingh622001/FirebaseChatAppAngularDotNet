using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestDto
{
    public class UserRequestDto
    {
        [Required]
        public string? DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(6)]
        public string? Password { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [Url]
        public string? PhotoUrl { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string? Address { get; set; }
        [Required]
        public Role? Role { get; set; }

        public bool IsActive { get; set; } = true;


    }
    public enum Role {
        admin = 1,
        user = 2,
    }
    [FirestoreData]
    public class UserDetailDto
    {
        [FirestoreProperty]
        [Required]
        public string? PhotoUrl { get; set; }
        [FirestoreProperty]
        [Required]
        public string? FirstName { get; set; }
        [FirestoreProperty]
        [Required]
        public string? LastName { get; set; }
        [FirestoreProperty]
        [Required]
        [FirestoreDocumentReadTimestamp]
        public Timestamp DateOfBirth { get; set; }
        [FirestoreProperty]
        [Required]
        public string? Address { get; set; }
        [FirestoreProperty]
        [Required]
        public Role? Role { get; set; }
        [FirestoreProperty]
        [Required]
        public bool IsActive { get; set; } = true;
        //private DateTime createdAt;
        //[FirestoreProperty]
        //[Required]
        //public DateTime CreatedAt
        //{
        //    get => createdAt;
        //    set => createdAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        //}

        //private DateTime updatedAt;
        //[FirestoreProperty]
        //[Required]
        //public DateTime UpdatedAt
        //{
        //    get => updatedAt;
        //    set => updatedAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        //}

    }

}
