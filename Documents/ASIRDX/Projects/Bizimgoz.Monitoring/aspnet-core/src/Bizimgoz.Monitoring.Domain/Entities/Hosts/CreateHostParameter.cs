using System.Collections.Generic;

namespace Bizimgoz.Monitoring.Entities.Hosts
{
    public class CreateHostParameter
    {
        /*
         host: values.name,
        groups: [{ groupid: values.groupid }],
        interfaces: [], tags: [], templates: [], macros: [],
         */
        public string host { get; set; }
        public List<GroupIdObject> groups { get; set; }
        public List<object> interfaces { get; set; }
        public List<object> tags { get; set; }
        public List<object> templates { get; set; }
        public List<object> macros { get; set; }
    }
}
