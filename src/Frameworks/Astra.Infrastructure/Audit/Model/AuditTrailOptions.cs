namespace Astra.Infrastructure.AuditTrail.Model
{
    public class AuditTrailOptions
    {
        public bool IndexPerMonth { get; set; }

        public int AmountOfPreviousIndicesUsedInAlias { get; set; }

        public string ServiceUrl { get; set; }

        public string Alias { get; set; }

        public bool CustomIndexEnable { get; set; }

        public AuditTrailOptions UseSettings(string serviceUrl, bool indexPerMonth, int amountOfPreviousIndicesUsedInAlias, string alias = null)
        {
            ServiceUrl = serviceUrl;
            IndexPerMonth = indexPerMonth;
            AmountOfPreviousIndicesUsedInAlias = amountOfPreviousIndicesUsedInAlias;
            Alias = alias;

            return this;
        }

        public AuditTrailOptions EnableCustomIndex(bool enabled)
        {
            CustomIndexEnable = enabled;
            return this;
        }
    }
}
