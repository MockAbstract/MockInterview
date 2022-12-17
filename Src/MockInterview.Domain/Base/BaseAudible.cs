namespace MockInterview.Domain
{
    public interface BaseAudible 
    {
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set;}
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset  LastModifiedDate{ get; set; }

        public void SetLastModified() => LastModifiedDate = DateTimeOffset.UtcNow;

        public void SetCreatedDate() => CreatedDate = DateTimeOffset.UtcNow;
    }
}
