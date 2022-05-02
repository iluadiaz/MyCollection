using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pokemon.Info;
using System.Collections.Generic;
using System.Linq;
using Users.Info;
using System.IO;

namespace _367Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUserData()
        {
            string[] stats = new string[6];
        
            for(int i = 0; i < 6; i++)
            {
                stats[i] = "90";
            }
            
            IList<UserInfo> users = new List<UserInfo>();

            IList<PokemonManager> mons = new List<PokemonManager>();

            PokemonManager mon = new PokemonManager("Squirtle", "Timid", stats);

            mons.Add(mon);

            Assert.AreEqual(mon.PokemonName, "Squirtle");

            var user = new UserInfo();
            user.Teams.Add(mon);
            Assert.AreEqual(user.Teams[0].PokemonName, "Squirtle");

            users.Add(user);
            Assert.AreEqual(users[0].Teams[0].Nature, "Timid");

            Assert.AreEqual(user.verified,false);
            Assert.IsNull(user.Password);
            Assert.IsNull(user.UserName);

            Console.WriteLine("Please create a user Account before continuing. Type your username");
            user.UserName = "Blob";
            user.Password = "whyDoesCharizardSuck";            

            Assert.IsNotNull(user.UserName);
            Assert.IsNotNull(user.Password);

            Assert.IsFalse(user.verifyAccount(user, "billy"));
            Assert.IsTrue(user.verifyAccount(user, "Blob"));
            Assert.IsFalse(user.passwordChecker(user, "billy"));
            Assert.IsTrue(user.passwordChecker(user, "whyDoesCharizardSuck"));
            Assert.AreEqual(user.verified, true);   

            Assert.AreEqual(user.UserName, "Blob");
            Assert.AreEqual(user.Password,"whyDoesCharizardSuck");
            
        }

        [TestMethod]

        public void PokemonManagerManualTest()
        {
            IList<PokemonManager> mons = new List<PokemonManager>();
            string[] stats = new string[6];

            var user = new UserInfo();

            string pokemon = " ", nature =" ";

            Console.WriteLine("Please provide the Pokemon name, nature and stats.");
            
            // //For loop to manaually create a team
            for(int i = 0; i < 2; i++)
            {
                if(i == 0)
                {
                    pokemon = "Squirtle";
                    nature = "Modest";
                }
                else if( i == 1)
                {
                    pokemon = "Pichu";
                    nature = "Timid";
                }
                
                Console.WriteLine("Please provide the Pokemons stats in the following order: hp,atk,def,spa,spd,spe.");
                for(int j = 0; j < stats.Length; j++)
                {
                    stats[j] = "100";
                }

                PokemonManager mon = new PokemonManager(pokemon, nature, stats);
                Assert.AreEqual(mon.PokemonName, pokemon);
                Assert.AreEqual(mon.Nature, nature);

                Console.WriteLine("Please provide the next pokemon");
                user.Teams.Add(mon);

            }

           
        Assert.AreEqual(user.Teams[0].PokemonName, "Squirtle");
        Assert.AreEqual(user.Teams[1].PokemonName, "Pichu");

        Assert.AreEqual(user.Teams[0].Nature, "Modest");
        Assert.AreEqual(user.Teams[1].Nature, "Timid");


        int unmodifiedStatCounter = 0;
        int modifiedStatCounter = 0;

        string[] modifiedStatTracker = new string[4];
        
        for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                if(user.Teams[i].Stats[j] == 100)
                {
                unmodifiedStatCounter++;
                }
                else if(user.Teams[i].Stats[j] == 90 || user.Teams[i].Stats[j] == 110)
                {
                    modifiedStatTracker[modifiedStatCounter] = user.Teams[i].StatNames[j];
                    modifiedStatCounter++;
                }
            }
        }

        Assert.AreEqual(unmodifiedStatCounter, 8);
        Assert.AreEqual(modifiedStatCounter, 4);

        Assert.AreEqual(modifiedStatTracker[0], "atk");
        Assert.AreEqual(modifiedStatTracker[1], "spa");
        Assert.AreEqual(modifiedStatTracker[2], "atk");
        Assert.AreEqual(modifiedStatTracker[3], "spe");



        PokemonManager monster = new PokemonManager("Squirtle", "Lonely", stats);

        monster.HitPoints = 100;
        monster.Attack = 100;
        monster.Defense = 100;
        monster.SpecialAttack = 100;
        monster.SpecialDefense = 100;
        monster.Speed = 100;

        monster.Nature = "Adamant";

        PokemonManager monster2 = new PokemonManager(monster.PokemonName, monster.Nature, stats);
        Assert.AreEqual(monster2.Attack, 110);
        monster = new PokemonManager("Squirtle", "Naughty", stats);
        monster = new PokemonManager("Squirtle", "Relaxed", stats);
        monster = new PokemonManager("Squirtle", "Impish", stats);
        monster = new PokemonManager("Squirtle", "Lax", stats);
        monster = new PokemonManager("Squirtle", "Naive", stats);
        monster = new PokemonManager("Squirtle", "Mild", stats);
        monster = new PokemonManager("Squirtle", "Rash", stats);
        monster = new PokemonManager("Squirtle", "Gentle", stats);
        monster = new PokemonManager("Squirtle", "Sassy", stats);
        monster = new PokemonManager("Squirtle", "Careful", stats);



        }

[TestMethod]

        public void PokemonUseTest()
        {
            IList<PokemonManager> mons = new List<PokemonManager>();

            var user = new UserInfo();

            string pokemon = " ", nature =" ";

            string[] stats = new string[6];

            pokemon = "Squirtle";
            nature = "Modest";

        
                for(int j = 0; j < stats.Length; j++)
                {
                    stats[j] = "100";
                }

                PokemonManager mon = new PokemonManager(pokemon, nature, stats);
                user.Teams.Add(mon);  
        
            PokemonManager tempMon = new PokemonManager(pokemon, "Hardy", stats);
            PokemonUse use = new PokemonUse(tempMon);
            tempMon.PokemonUse = use.PokemonRoleAssign(tempMon);
            Assert.AreEqual(tempMon.PokemonUse,"This pokemon can serve any role ");
            Console.WriteLine(tempMon.PokemonUse);

            tempMon = new PokemonManager(pokemon, "Jolly", stats);
            use = new PokemonUse(tempMon);
            tempMon.PokemonUse = use.PokemonRoleAssign(tempMon);
            Assert.AreEqual(tempMon.PokemonUse,"This pokemon will serve best as a fast physical sweeper ");
            Console.WriteLine(tempMon.PokemonUse);

            tempMon = new PokemonManager(pokemon, "Brave", stats);
            use = new PokemonUse(tempMon);
            tempMon.PokemonUse = use.PokemonRoleAssign(tempMon);
            Assert.AreEqual(tempMon.PokemonUse,"This pokemon will serve best as a physical sweeper ");
            Console.WriteLine(tempMon.PokemonUse);

            tempMon = new PokemonManager(pokemon, "Timid", stats);
            use = new PokemonUse(tempMon);
            tempMon.PokemonUse = use.PokemonRoleAssign(tempMon);
            Assert.AreEqual(tempMon.PokemonUse,"This pokemon will serve best as a fast special sweeper ");
            Console.WriteLine(tempMon.PokemonUse);

            tempMon = new PokemonManager(pokemon, "Hasty", stats);
            use = new PokemonUse(tempMon);
            tempMon.PokemonUse = use.PokemonRoleAssign(tempMon);
            Assert.AreEqual(tempMon.PokemonUse,"This pokemon can be either a special or physical sweeper ");
            Console.WriteLine(tempMon.PokemonUse);


            tempMon = new PokemonManager(pokemon, "Quiet", stats);
            use = new PokemonUse(tempMon);
            tempMon.PokemonUse = use.PokemonRoleAssign(tempMon);
            Assert.AreEqual(tempMon.PokemonUse,"This pokemon will serve best as a special sweeper");
            Console.WriteLine(tempMon.PokemonUse);


            stats[2] = "112";

            tempMon = new PokemonManager(pokemon, "Calm", stats);
            use = new PokemonUse(tempMon);
            tempMon.PokemonUse = use.PokemonRoleAssign(tempMon);
            Assert.AreEqual(tempMon.PokemonUse,"This pokemon will serve best as a damage soak");
            Console.WriteLine(tempMon.PokemonUse);

            stats[4] = "90";

            tempMon = new PokemonManager(pokemon, "Bold", stats);
            use = new PokemonUse(tempMon);
            tempMon.PokemonUse = use.PokemonRoleAssign(tempMon);
            Assert.AreEqual(tempMon.PokemonUse,"This pokemon will serve best as a physical damage soak ");
            Console.WriteLine(tempMon.PokemonUse);

            stats[2] = "100";
            stats[3] = "89";
            stats[4] = "110";
            stats[5] = "90";

            tempMon = new PokemonManager(pokemon, "calm", stats);
            use = new PokemonUse(tempMon);
            tempMon.PokemonUse = use.PokemonRoleAssign(tempMon);
            Console.WriteLine(tempMon.PokemonUse);
            Assert.AreEqual(tempMon.PokemonUse,"This pokemon will serve best as a special damage soak ");

        }

        [TestMethod]

        public void RandomPokemonGeneratorTest()
        {
            IList<PokemonManager> mons = new List<PokemonManager>();
            var user = new UserInfo();

            TeamGenerator rando = new TeamGenerator();

            user.Teams.Add(rando.Pokemon);
            mons.Add(rando.Pokemon);

            Assert.AreEqual(user.Teams[0].PokemonName, mons[0].PokemonName);

            string temp = mons[0].PokemonName, temp2 = mons[0].Nature; double temp3 = mons[0].Stats[0];
            
            Assert.AreEqual(temp,mons[0].PokemonName);
            Assert.AreEqual(temp2,mons[0].Nature);
            Assert.AreEqual(temp3,mons[0].Stats[0]);   
        }

           public void PokemonNatureTests()
        {
            IList<PokemonManager> mons = new List<PokemonManager>();

            var user = new UserInfo();

            string pokemon = " ", nature =" ";

            Console.WriteLine("Please provide the Pokemon name, nature and stats.");

            for(int i = 0; i < 2; i++)
            {
                if(i == 0)
                {
                    pokemon = "Squirtle";
                    nature = "Modest";
                }
                else if( i == 1)
                {
                    pokemon = "Pichu";
                    nature = "Timid";
                }
                
                string[] stats = new string[6];
                Console.WriteLine("Please provide the Pokemons stats in the following order: hp,atk,def,spa,spd,spe.");
                for(int j = 0; j < stats.Length; j++)
                {
                    stats[j] = "100";
                }

                PokemonManager mon = new PokemonManager(pokemon, nature, stats);

                Console.WriteLine("Please provide the next pokemon");
                user.Teams.Add(mon);
     
            }
            string[] tempString = File.ReadAllLines("Natures.txt");

                for(int i = 0; i < 2; i++)
                {
                    for(int j = 0; j < 25; i++)
                    {
                    user.Teams[i].Nature = tempString[j];
            if(user.Teams[i].Nature == "Hardy"|| user.Teams[i].Nature == "Docile"|| user.Teams[i].Nature == "Serious"|| user.Teams[i].Nature == "Bashful"|| user.Teams[i].Nature == "Quirky"  )
            {
                for(int p = 0; p < 6; p++)
                Assert.Equals(user.Teams[i].Stats[p],100);
            }
             if(user.Teams[i].Nature == "Lonely")
            {
                
                Assert.Equals(user.Teams[i].Stats[1],110 );
                Assert.Equals(user.Teams[i].Stats[2],90 );
                

            }
                if(user.Teams[i].Nature == "Brave")
            {
                
                Assert.Equals(user.Teams[i].Stats[1],110 );
                Assert.Equals(user.Teams[i].Stats[5],90 );
                   

            }
                if(user.Teams[i].Nature == "Adamant")
            {
                
                Assert.Equals(user.Teams[i].Stats[1],110 );
                Assert.Equals(user.Teams[i].Stats[3],90 );
                

            }
                if(user.Teams[i].Nature == "Naughty")
            {
                
                Assert.Equals(user.Teams[i].Stats[1],110 );
                Assert.Equals(user.Teams[i].Stats[4],90 );
                       
            }
                if(user.Teams[i].Nature == "Bold")
            {
                
                Assert.Equals(user.Teams[i].Stats[2],110 );
                Assert.Equals(user.Teams[i].Stats[1],90 );
                        
            }
                 if(user.Teams[i].Nature == "Relaxed")
            {
                
                Assert.Equals(user.Teams[i].Stats[2],110 );
                Assert.Equals(user.Teams[i].Stats[5],90 );
                
            }
             if(user.Teams[i].Nature == "Impish")
            {
                
                Assert.Equals(user.Teams[i].Stats[2],110 );
                Assert.Equals(user.Teams[i].Stats[3],90 );
                
            }
             if(user.Teams[i].Nature == "Lax")
            {
                
                Assert.Equals(user.Teams[i].Stats[2],110 );
                Assert.Equals(user.Teams[i].Stats[4],90 );
                
            }
             if(user.Teams[i].Nature == "Timid")
            {
                
                Assert.Equals(user.Teams[i].Stats[5],110 );
                Assert.Equals(user.Teams[i].Stats[1],90 );
                
            }
             if(user.Teams[i].Nature == "Hasty")
            {
                
                Assert.Equals(user.Teams[i].Stats[5],110 );
                Assert.Equals(user.Teams[i].Stats[2],90 );
                
            }
             if(user.Teams[i].Nature == "Jolly")
            {
                
                Assert.Equals(user.Teams[i].Stats[5],110 );
                Assert.Equals(user.Teams[i].Stats[3],90 );
                
            }
             if(user.Teams[i].Nature == "Naive")
            {
                
                Assert.Equals(user.Teams[i].Stats[5],110 );
                Assert.Equals(user.Teams[i].Stats[4],90 );
                
            }
             if(user.Teams[i].Nature == "Modest")
            {
                
                Assert.Equals(user.Teams[i].Stats[3],110 );
                Assert.Equals(user.Teams[i].Stats[1],90 );
                
            }
             if(user.Teams[i].Nature == "Mild")
            {
                
                Assert.Equals(user.Teams[i].Stats[3],110 );
                Assert.Equals(user.Teams[i].Stats[2],90 );
                
            }
             if(user.Teams[i].Nature == "Quiet")
            {
                
                Assert.Equals(user.Teams[i].Stats[3],110 );
                Assert.Equals(user.Teams[i].Stats[5],90 );
                
            }
             if(user.Teams[i].Nature == "Rash")
            {
                
                Assert.Equals(user.Teams[i].Stats[3],110 );
                Assert.Equals(user.Teams[i].Stats[4],90 );
                
            }
             if(user.Teams[i].Nature == "Calm")
            {
                
                Assert.Equals(user.Teams[i].Stats[4],110 );
                Assert.Equals(user.Teams[i].Stats[1],90 );
                
            }
             if(user.Teams[i].Nature == "Gentle")
            {
                
                Assert.Equals(user.Teams[i].Stats[4],110 );
                Assert.Equals(user.Teams[i].Stats[2],90 );
                
            }
             if(user.Teams[i].Nature == "Sassy")
            {
                
                Assert.Equals(user.Teams[i].Stats[4],110 );
                Assert.Equals(user.Teams[i].Stats[5],90 );
                
            }
             if(user.Teams[i].Nature == "Careful")
            {
                
                Assert.Equals(user.Teams[i].Stats[4],110 );
                Assert.Equals(user.Teams[i].Stats[3],90 );
                
            }
                    }
                }
            bool statcheck = false;
            if(mons[0].Attack == 100 && mons[0].Nature != "lonely" ||  mons[0].Nature != "Brave"||
            mons[0].Nature != "Adamant" || mons[0].Nature != "Naughty" || mons[0].Nature != "Bold" || 
            mons[0].Nature != "Timid" || mons[0].Nature != "Modest" || mons[0].Nature != "Calm")
            {
                statcheck = true;
            }
             Assert.IsTrue(statcheck);
              statcheck = false;

            if(mons[0].Defense == 100 && mons[0].Nature != "Bold" ||  mons[0].Nature != "Gentle"||
            mons[0].Nature != "Hasty" || mons[0].Nature != "Impish" || mons[0].Nature != "Lax" || 
            mons[0].Nature != "Lonely" || mons[0].Nature != "Mild" || mons[0].Nature != "Relaxed")
            {
                statcheck = true;
            }
             Assert.IsTrue(statcheck);
              statcheck = false;
            
            if(mons[0].Attack == 110 && mons[0].Nature != "Lonely" ||  mons[0].Nature != "Brave"||
            mons[0].Nature != "Adamant" || mons[0].Nature != "Naughty" )
            {
                statcheck = true;
            }
             Assert.IsTrue(statcheck);
              statcheck = false;

            string[] natures = File.ReadAllLines("Natures.txt");
            string[] moreStats = File.ReadAllLines("Pokemonstats.txt");

            for(int i = 0; i < 25; i++)
            {
                PokemonManager monster = new PokemonManager("squirtle", natures[i], moreStats);
                Assert.Equals(monster.Nature, natures[i]);
            }

        }

        [TestMethod]
        public void PokemonTeamBuilderTest()
        {
            var user = new UserInfo();

            Console.WriteLine("Please create a user Account before continuing. Type your username");
            user.UserName = "Blob";
            user.Password = "whyDoesCharizardSuck";      
            Console.WriteLine("This is your user name: " + user.UserName+  " password: " + user.Password);      

            Assert.IsFalse(user.verifyAccount(user, "billy"));
            Assert.IsTrue(user.verifyAccount(user, "Blob"));
            Assert.IsFalse(user.passwordChecker(user, "billy"));
            Assert.IsTrue(user.passwordChecker(user, "whyDoesCharizardSuck"));
            Assert.AreEqual(user.verified, true);   

            Assert.AreEqual(user.UserName, "Blob");
            Assert.AreEqual(user.Password,"whyDoesCharizardSuck");

            string[] pokemon = File.ReadAllLines("PokemonList.txt"), 
            nature = File.ReadAllLines("Natures.txt"),
            statsFromData = File.ReadAllLines("Pokemonstats.txt");

            string[] stats = new string[6];

            for(int i = 0; i < 6; i++)
            {
                stats[i] = "100";
            }

            PokemonManager mon = new PokemonManager(pokemon[1], nature[1], stats);
            Console.WriteLine("This is the pokemon info: ");
            Console.WriteLine(mon.PokemonName);
            Console.WriteLine("These are the Stats: ");
            for(int i = 0; i < 6; i++)
            {
                Console.WriteLine(mon.StatNames[i] + ": " + mon.Stats[i]);
            }
            
            Console.WriteLine("This is the nature: " + mon.Nature);

            PokemonUse use = new PokemonUse(mon);
            use.PokemonRoleAssign(mon);

            mon.PokemonUse = use.pokemonUse;

            Console.WriteLine(mon.PokemonUse);

            Console.WriteLine();

            mon = new PokemonManager(pokemon[1], nature[2], stats);
            Console.WriteLine("This is the pokemon info: ");
            Console.WriteLine(mon.PokemonName);
            Console.WriteLine("These are the Stats: ");
            for(int i = 0; i < 6; i++)
            {
                Console.WriteLine(mon.StatNames[i] + ": " + mon.Stats[i]);
            }
            Console.WriteLine("This is the nature: " + mon.Nature);

            use = new PokemonUse(mon);
            use.PokemonRoleAssign(mon);

            mon.PokemonUse = use.pokemonUse;

            Console.WriteLine(mon.PokemonUse);

            Console.WriteLine();
            Console.WriteLine("Starting random team test");

            TeamGenerator rando = new TeamGenerator();

            user.Teams.Add(rando.Pokemon);

            rando = new TeamGenerator();

            user.Teams.Add(rando.Pokemon);

            for(int j = 0; j < 2; j++)
            {
                Console.WriteLine();
                Console.WriteLine("Pokemon added is: " + user.Teams[j].PokemonName);
                Console.WriteLine("These are the Stats: ");
                for(int i = 0; i < 6; i++)
            {
                Console.WriteLine(user.Teams[j].StatNames[i] + ": " + user.Teams[j].Stats[i]);
            }
            Console.WriteLine("This is the nature: " + user.Teams[j].Nature);

            use = new PokemonUse(user.Teams[j]);

            user.Teams[j].PokemonUse = use.pokemonUse;

            Console.WriteLine(user.Teams[j].PokemonUse);
            }

            IList<UserInfo> users = new List<UserInfo>();
            users.Add(user);

            Console.WriteLine("This is the second pokemon for the first user on the list: ");
            Console.WriteLine(users[0].Teams[1].PokemonName);

        }
    }
}
