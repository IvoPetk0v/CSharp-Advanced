using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name,int neededREnovators,string project)
        {
            renovators = new List<Renovator>();
            this.Name = name;
            this.NeededRenovators = neededREnovators;
            this.Project = project;
        }
        private List<Renovator> renovators;
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public List<Renovator> Renovators { get => renovators; }
        public int Count { get => renovators.Count; }
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name)||string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (this.NeededRenovators<=renovators.Count) 
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate>350)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
       public bool RemoveRenovator(string name)
        {
            return renovators.Remove(renovators.FirstOrDefault(x => x.Name == name));
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            return renovators.RemoveAll(x => x.Type == type);
        }
        public Renovator HireRenovator(string name)
        {
            if (renovators.Exists(x=>x.Name==name))
            {
                renovators.Find(x => x.Name == name).Hired = true;
            }
            return renovators.FirstOrDefault(x => x.Name == name);
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> result = renovators.Where(x => x.Days >= days).ToList();
            return result;
        }
        public  string Report()
        {
            List<Renovator> result = renovators.Where(x => x.Hired == false).ToList();
           
           
            return $"Renovators available for Project { this.Project}:{Environment.NewLine}"+string.Join(Environment.NewLine, result);
        }
    }
}
