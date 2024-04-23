namespace Webapi.Common;

// واسه زمانی که می خواهیم یدونه خروجی داشته باشیم
public class ResultDto<T>
{
    public string? Message { get; set; }
    public bool IsSuccessFull { get; set; }
    public T? Value { get; set; }
}
// واسه زمانی که هیچ خروجی نداریم
public class ResultDto
{
    public string? Message { get; set; }
    public bool IsSuccessFull { get; set; }
}

// زمانی که یک کالکشنی از خروجی می خوهیم
public class ResultsDto<T>
{
    public string? Message { get; set; }
    public bool IsSuccessFull { get; set; }
    public IEnumerable<T>? Value { get; set; }
}