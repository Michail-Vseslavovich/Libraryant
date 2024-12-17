using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Instruments.Dto
{
    public class ReViewDTO
    {       
        [Key] public readonly int id;
        public readonly int UserId;
        public readonly int AdressedBookId;
        public string ReviewText;
        public DateTime ReviewDate;
    }
}
