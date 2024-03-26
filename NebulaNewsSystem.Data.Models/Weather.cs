using System.ComponentModel.DataAnnotations;

namespace NebulaNewsSystem.Data.Models
{
    public class Weather
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public double Temperature { get; set; }
        public double FeelsLikeTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public double WindDirection { get; set; }

        public string Town { get; set; } = null!; // Dupnitsa
    }
}
