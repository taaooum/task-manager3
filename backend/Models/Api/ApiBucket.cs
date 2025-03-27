﻿namespace backend.Models.Api
{
    public class ApiBucket
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
