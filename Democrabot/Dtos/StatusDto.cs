
public class StatusDto
{
    public int[] active_election_policy_effects { get; set; }
    public List<Campaign> campaigns { get; set; }
    public int[] community_targets { get; set; }
    public Global_Events[] global_events { get; set; }
    public float impact_multiplier { get; set; }
    public Joint_Operations[] joint_operations { get; set; }
    public int[] planet_active_effects { get; set; }
    public Planet_Attacks[] planet_attacks { get; set; }
    public Planet_Events[] planet_events { get; set; }
    public Planet_Status[] planet_status { get; set; }
    public DateTime snapshot_at { get; set; }
    public int war_id { get; set; }
}