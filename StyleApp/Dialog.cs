using System.Collections.Generic;

namespace StyleApp
{
    public class Dialog
    {
        public string NamePerson { get; set; }

        public string ImagePerson { get; set; }

        public List<string> TextDialog { get; set; } = new List<string>();

        public override string ToString()
        {
            return NamePerson;
        }
    }
}
