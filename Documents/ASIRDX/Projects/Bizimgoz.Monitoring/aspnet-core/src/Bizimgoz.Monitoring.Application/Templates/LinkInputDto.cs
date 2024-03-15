using System.Collections.Generic;

namespace Bizimgoz.Monitoring.Templates
{
    public class LinkInputDto
    {
        public List<string> hostids { get; set; }
        public List<string> templateids {  get; set; }
        public bool clear {  get; set; }
    }
}
