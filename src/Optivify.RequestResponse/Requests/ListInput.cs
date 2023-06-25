using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Optivify.RequestResponse
{
    public class ListInput
    {
        public virtual string? SearchText { get; set; }

        public virtual int Page { get; set; }

        public virtual int ItemsPerPage { get; set; }

        public virtual string? SortBy { get; set; }

        public virtual bool SortDesc { get; set; }

        public virtual bool PaginationEnabled { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual int Skip
        {
            get { return this.ItemsPerPage * (this.Page - 1); }
        }

        [NotMapped]
        [JsonIgnore]
        public virtual int Take
        {
            get { return this.ItemsPerPage; }
        }

        public ListInput()
        {
            this.SetDefault();
        }

        protected void SetDefault()
        {
            this.Page = 1;
            this.ItemsPerPage = 10;
            this.PaginationEnabled = true;
        }
    }
}
