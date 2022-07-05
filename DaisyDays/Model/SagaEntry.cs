using System;
using System.Drawing;

namespace DaisyDays.Model
{
    public class SagaEntry
    {
        public int DiaryEntryId { get; set; }
        // public DateTime DateDue { get; set; }
        public string? Title { get; set; } = String.Empty;
        public string? DiaryContent { get; set; } = String.Empty;
        public RectangleF ObscurableArea { get; set; }
        public int SagaId { get; set; }
        //public Saga Saga { get; set; }
    }
}
