public class Planet_Events
{
    public Campaign campaign { get; set; }
    public int event_type { get; set; }
    public DateTime expire_time { get; set; }
    public int health { get; set; }
    public int id { get; set; }
    public Joint_Operations[] joint_operations { get; set; }
    public int max_health { get; set; }
    public Planet planet { get; set; }
    public string race { get; set; }
    public DateTime start_time { get; set; }
}