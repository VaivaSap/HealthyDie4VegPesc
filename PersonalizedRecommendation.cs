using FusionCharts.Visualization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using VegApp.Areas.Identity.Data;
using VegApp.Areas.Identity.Pages.Account.Manage;
using VegApp.Data;
using VegApp.Entities;

namespace VegApp
{
    public class PersonalizedRecommendation
    {
        private readonly UserProvider _userProvider;

        public PersonalizedRecommendation(UserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public Recommendation CategorizePerson()
        {
            var person = _userProvider.GetCurrentUser();

            if (person.Gender == GenderEnum.Female)
            {
                if (9 >= person.Age && person.Age < 14)
                {

                    return new Recommendation
                    {

                        Calories = 2200,
                        Fats = 18,
                        Carbs = 130,
                        Proteins = 34,
                    };


                }

                if (14 >= person.Age && person.Age < 30)
                {
                    return new Recommendation
                    {
                        Calories = 2200,
                        Fats = 20,
                        Carbs = 130,
                        Proteins = 46,
                    };
                }


                if (30 >= person.Age && person.Age <= 49)
                {
                    return new Recommendation
                    {
                        Calories = 2000,
                        Fats = 20,
                        Carbs = 59.1m,
                        Proteins = 46,
                    };
                }


                if (50 >= person.Age && person.Age <= 69)
                {
                    return new Recommendation
                    {
                        Calories = 1800,
                        Fats = 25,
                        Carbs = 57.8m,
                        Proteins = 46,
                    };
                }

                if (person.Age > 69)
                {
                    return new Recommendation
                    {
                        Calories = 1600,
                        Fats = 19,
                        Carbs = 130,
                        Proteins = 46,
                    };
                }

            }


            else
            {

                if (9 >= person.Age && person.Age < 14)
                {
                    return new Recommendation
                    {
                        Calories = 1800,
                        Fats = 20,
                        Carbs = 130,
                        Proteins = 34,
                    };
                }

                if (14 >= person.Age && person.Age < 18)
                {
                    return new Recommendation
                    {
                        Calories = 2400,
                        Fats = 24,
                        Carbs = 130,
                        Proteins = 52,
                    };
                }

                if (18 >= person.Age && person.Age < 30)
                {
                    return new Recommendation
                    {
                        Calories = 2400,
                        Fats = 23.5m,
                        Carbs = 130,
                        Proteins = 56,
                    };

                }

                if (30 >= person.Age && person.Age <= 49)
                {
                    return new Recommendation
                    {
                        Calories = 2400,
                        Fats = 23.5m,
                        Carbs = 130,
                        Proteins = 56,
                    };
                }

                else if (person.Age >= 50)
                {
                    return new Recommendation
                    {
                        Calories = 2000,
                        Fats = 23,
                        Carbs = 130,
                        Proteins = 56,
                    };
                }
            }
          throw new Exception("Too young to use this app. For now, listen to your parents what to eat ;)");
        }
    }
}



