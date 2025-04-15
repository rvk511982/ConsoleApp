﻿using System.ComponentModel.DataAnnotations;

namespace GraphQL.JWTAuthentication.Pagination.FileUpload.WebApi.Models.Entities
{
    public class UserEN
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;    
    }
}
