namespace MyWebApplication.API.ViewModels
{
    public class InputDataViewModel
    {
        public string Name { get; set; }
        public int MonthId { get; set; }
    }

    public class InputDataBetweenViewModel
    {
        public int Month1Id { get; set; }
        public int Month2Id { get; set; }
    }
}
