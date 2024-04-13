using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LMS_SASS.Models
{
    [Table("QuizAttemptDetails")]
    [PrimaryKey(nameof(Id))]
    public class QuizAttemptDetailModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }
        [ForeignKey(nameof(QuizAttempt))]
        public required int QuizAttemptId { get; set; }
        public required QuizAttemptModel QuizAttempt { get; set; }
        [ForeignKey(nameof(QuizQuestion))]
        public required int QuestionId { get; set; }
        public required QuizQuestionModel QuizQuestion { get; set; }
        public required int Answered { get; set; }
        public required bool IsCorrect { get; set; }
    }
}