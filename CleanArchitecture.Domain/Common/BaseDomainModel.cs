

namespace CleanArchitecture.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatdBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
