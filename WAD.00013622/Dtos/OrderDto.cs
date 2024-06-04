namespace WAD._00013622.Dtos
{
    public class OrderCreateDto
    {
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }

    public class OrderReadDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
    }

    public class OrderUpdateDto
    {
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
    }
}
