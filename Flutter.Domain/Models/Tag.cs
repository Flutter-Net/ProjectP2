using Flutter.Domain.Abstracts;

namespace Flutter.Domain.Models
{
    public class Tag : AEntity
    {
        public string TagName {get;set;}

        public Tag(string name){
            TagName = name;
        }
    }
}
