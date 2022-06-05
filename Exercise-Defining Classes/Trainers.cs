using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Trainers
    {
        public Trainers(string name,List<Pokemon> pokemons)
        {
            Name = name;
            Badges = 0;
            Pokemons = pokemons;
        }
        public Trainers(List<Pokemon> pokemons)
        {
            Pokemons = pokemons;
        }
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
       
        //"{trainerName} {badges} {numberOfPokemon}"
        public override string ToString()
        {
            return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
        }
    }
}
