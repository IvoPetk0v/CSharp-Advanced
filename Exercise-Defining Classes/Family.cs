using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMember;

        public Family()
        {
            this.familyMember = new List<Person>();
        }


        public void AddMember(Person currentPerson)
        {
            familyMember.Add(currentPerson);
        }
        public Person GetOldestMember(Family people)
        {
            int maxAge = this.familyMember.Max(age => age.Age);
            return this.familyMember.First(age => age.Age == maxAge);
        }
    }

}
