using System;
using System.ComponentModel.DataAnnotations;

namespace SpaceShooter.Data
{
    public class Highscore
    {
        [Key]
        public Guid HighscoreId { get; set; } = Guid.NewGuid();

        [Required, MaxLength(3)]
        public string PlayerName { get; set; }

        [Required]
        public int Score { get; set; }
    }
}
