using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<Trainers> trainers = new List<Trainers>();
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputData = input //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                .Split()
                .ToArray();
                CatchPokemon(inputData, trainers);
            }
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                FightRound(cmd, trainers);
            }
            //sorted by the number of badges they have in descending order
            trainers = trainers.OrderByDescending(x => x.Badges).ToList();
            Console.WriteLine(String.Join(Environment.NewLine,trainers));
        }
        static void CatchPokemon(string[] inputData, List<Trainers> trainers)
        {
            List<Pokemon> pokemon = new List<Pokemon>();
            if (!trainers.Any(trainer => trainer.Name == inputData[0]))
            {
                pokemon.Add(ReadDataOfPokemon(inputData));
                Trainers currTrainer = new Trainers(inputData[0], pokemon);
                trainers.Add(currTrainer);
            }
            else
            {
                pokemon = trainers.Where(trainer => trainer.Name == inputData[0]).First().Pokemons.Append(ReadDataOfPokemon(inputData)).ToList();
                trainers.Where(trainer => trainer.Name == inputData[0]).First().Pokemons=pokemon;
            }
        }
        static Pokemon ReadDataOfPokemon(string[] inputData)
        {
            Pokemon pokemon = new Pokemon(inputData[1], inputData[2], int.Parse(inputData[3]));
            return pokemon;
        }
        static void FightRound(string cmd,List<Trainers> trainers)
        {
            foreach (var coach in trainers)
            {
                if (coach.Pokemons.Any(x=>x.Element==cmd))
                {
                    coach.Badges++;
                }
                else
                {
                    coach.Pokemons.ForEach(x => x.Health -= 10);
                    coach.Pokemons.RemoveAll(x => x.Health <= 0);
                }
            }
        }
    }
}
