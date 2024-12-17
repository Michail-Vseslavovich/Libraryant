using System.ComponentModel.DataAnnotations;

namespace Library.Instruments.Dto
{
    public class BookDTO
    {
        private static int Counter = 0;
        [Key] public readonly int Id;
        [Required] public readonly int PublisherId;
        [Required] public string Title;
        [Required] public string Description;
        private List<int> ReviewIds;


        public BookDTO(, int publisherid, string title, string description)
        {
            Id = Counter++;
            PublisherId = publisherid;
            Title = title;
            Description = description;
            ReviewIds = new List<int>();
        }

        public bool AddReview(int reviewId)
        {
            if (!ReviewIds.Contains(reviewId))
            {
                ReviewIds.Add(reviewId);
                return true;
            }
            return false;
        }
        public List<int> GetReviewIds()
        {
            return new List<int>(ReviewIds);
        }
    }
}
