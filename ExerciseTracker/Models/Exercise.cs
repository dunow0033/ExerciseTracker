using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Models
{
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public DateTime DateStart {  get; set; }
        public DateTime DateEnd { get; set; }

        [MaxLength(255)]
        public string? Comments {  get; set; }
        public TimeSpan Duration {  get; set; }
    }
}
