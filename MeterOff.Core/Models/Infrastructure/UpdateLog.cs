using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public class UpdateLog
    {
        [Key]
        public int id { get; set; }
        public string TableName { get; set; }
        public string PropertyName { get; set; }
        public int TableRecordId { get; set; }
        public string oldValue { get; set; }
        public string newValue { get; set; }
        public int userId { get; set; }
        public DateTime CreationTime { get; set; }
        public string PropertyDescription { get; set; }

        public UpdateLog(int id_, string TableName_, string PropertyName_, int TableRecordId_, string oldValue_, string newValue_, int userId_, DateTime CreationTime_, string PropertyDescription_)
        {
            this.id = id_;
            this.TableName = TableName_;
            this.PropertyName = PropertyName_;
            this.TableRecordId = TableRecordId_;
            this.oldValue = oldValue_;
            this.newValue = newValue_;
            this.userId = userId_;
            this.CreationTime = CreationTime_;
            this.PropertyDescription = PropertyDescription_;
        }
    }
}
