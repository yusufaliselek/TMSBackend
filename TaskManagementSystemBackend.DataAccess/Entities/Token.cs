﻿namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class Token : Base
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public DateTime? RefreshedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

}
