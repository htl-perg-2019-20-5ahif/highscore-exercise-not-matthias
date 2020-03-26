using System.ComponentModel.DataAnnotations;

namespace SpaceShooter.Data
{
    public class Highscore
    {
        public int HighscoreId { get; set; }

        [Required, MaxLength(3)]
        public string PlayerName { get; set; }

        [Required]
        public int Score { get; set; }
    }
}
