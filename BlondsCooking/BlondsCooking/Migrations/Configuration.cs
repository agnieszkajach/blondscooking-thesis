﻿using System.Collections.Generic;
using BlondsCooking.Models.Structure;
using LinearRegression;

namespace BlondsCooking.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BlondsCooking.Models.Db;

    internal sealed class Configuration : DbMigrationsConfiguration<BlondsCooking.Models.Db.BlondsCookingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlondsCookingContext context)
        {
            AddOrUpdateCategories(context);
            context.SaveChanges();
            AddOrUpdateRecipes(context);
            context.SaveChanges();
        }

        #region Categories

        private void AddOrUpdateCategories(BlondsCookingContext context)
        {
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Muffins"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Cookies"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Cakes"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Shakes"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Dinners"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Pancakes"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Dishes"
            });
        }

        #endregion

        #region Recipes

        private void AddOrUpdateRecipes(BlondsCookingContext context)
        {
            DishParametersHelper dishParametersHelper = new DishParametersHelper();
            List<double[]> dishParameters = dishParametersHelper.CalculateParameterForDishes();
            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "FILETY Z KURCZAKA W SOSIE POMIDOROWYM Z MOZZARELLĄ",
                Image = "~/Images/Recipes/Dishes/1.jpg",
                SpicyValue = dishParameters[0][0],
                SaltyValue = dishParameters[0][1],
                BitterValue = dishParameters[0][2],
                SweetValue = dishParameters[0][3],
                MeatValue = dishParameters[0][4],
                SourValue = dishParameters[0][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,oregano,ostra papryka,szynka parmeńska,pomidor,mozzarella,bazylia"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "FILETY Z KURCZAKA W PARMEZANOWEJ PANIERCE PIECZONE Z POMIDORAMI I SEREM",
                Image = "~/Images/Recipes/Dishes/2.jpg",
                SpicyValue = dishParameters[1][0],
                SaltyValue = dishParameters[1][1],
                BitterValue = dishParameters[1][2],
                SweetValue = dishParameters[1][3],
                MeatValue = dishParameters[1][4],
                SourValue = dishParameters[1][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,parmezan,pomidor,czerwona cebula,mozzarella,bazylia,tymianek,estragon,cukinia"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "PULPECIKI Z ŁOSOSIA I KASZY JAGLANEJ ZE SZPINAKIEM (LUB JARMUŻEM)",
                Image = "~/Images/Recipes/Dishes/3.jpg",
                SpicyValue = dishParameters[2][0],
                SaltyValue = dishParameters[2][1],
                BitterValue = dishParameters[2][2],
                SweetValue = dishParameters[2][3],
                MeatValue = dishParameters[2][4],
                SourValue = dishParameters[2][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,szpinak,jarmuż,kasza jaglana,bazylia,szczypiorek,chili"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "GRILLOWANE FILETY Z KURCZAKA Z KARMELIZOWANYMI ŚLIWKAMI",
                Image = "~/Images/Recipes/Dishes/4.jpg",
                SpicyValue = dishParameters[3][0],
                SaltyValue = dishParameters[3][1],
                BitterValue = dishParameters[3][2],
                SweetValue = dishParameters[3][3],
                MeatValue = dishParameters[3][4],
                SourValue = dishParameters[3][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,rozmaryn,słodka papryka,oliwa,śliwki,ostra papryka,miód,ocet balsamiczny"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ŁOSOŚ Z SOSEM ŚLIWKOWYM I SALSĄ MANGO",
                Image = "~/Images/Recipes/Dishes/5.jpg",
                SpicyValue = dishParameters[4][0],
                SaltyValue = dishParameters[4][1],
                BitterValue = dishParameters[4][2],
                SweetValue = dishParameters[4][3],
                MeatValue = dishParameters[4][4],
                SourValue = dishParameters[4][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,śliwki,mango,mięta,chili,cynamon,komosa ryżowa,ocet balsamiczny,oliwa,cukier trzcinowy,syrop klonowy,czosnek"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ZAPIEKANKA RYŻOWA Z DYNIĄ, MIELONYM MIĘSEM I POMIDORAMI",
                Image = "~/Images/Recipes/Dishes/6.jpg",
                SpicyValue = dishParameters[5][0],
                SaltyValue = dishParameters[5][1],
                BitterValue = dishParameters[5][2],
                SweetValue = dishParameters[5][3],
                MeatValue = dishParameters[5][4],
                SourValue = dishParameters[5][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "cebula cukrowa,czosnek,mielone mięso,kurkuma,kmin rzymski,cynamon,ostra papryka,słodka papryka,ryż,czerwona soczewica,dynia,pomidor,chili"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "LETNIE RISOTTO Z WARZYWAMI",
                Image = "~/Images/Recipes/Dishes/7.jpg",
                SpicyValue = dishParameters[6][0],
                SaltyValue = dishParameters[6][1],
                BitterValue = dishParameters[6][2],
                SweetValue = dishParameters[6][3],
                MeatValue = dishParameters[6][4],
                SourValue = dishParameters[6][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "oliwa,cebula,czosnek,ryż,kurki,czerwona papryka,cukinia,białe wino,różowe wino,pomidor malinowy,gorgonzola,parmezan,tymianek,estragon,ostra papryka,kurkuma,kmin rzymski"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "GRILLOWANE FILETY Z KURCZAKA PO MEKSYKAŃSKU",
                Image = "~/Images/Recipes/Dishes/8.jpg",
                SpicyValue = dishParameters[7][0],
                SaltyValue = dishParameters[7][1],
                BitterValue = dishParameters[7][2],
                SweetValue = dishParameters[7][3],
                MeatValue = dishParameters[7][4],
                SourValue = dishParameters[7][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,kolendra,słodka papryka,czosnek,oregano,tymianek,ostra papryka,ryż,czerwona cebula,koncentrat pomidorowy,kmin rzymski,czerwona fasola,awokado,pomidor,chili,kolendra"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "PAPRYKA FASZEROWANA PO MEKSYKAŃSKU",
                Image = "~/Images/Recipes/Dishes/9.jpg",
                SpicyValue = dishParameters[8][0],
                SaltyValue = dishParameters[8][1],
                BitterValue = dishParameters[8][2],
                SweetValue = dishParameters[8][3],
                MeatValue = dishParameters[8][4],
                SourValue = dishParameters[8][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "cebula cukrowa,czosnek,chili,ocet jabłkowy,kmin rzymski,cynamon,oregano,oliwa,papryka,wołowina,passata pomidorowa,sos sojowy,ryż,czerwona fasola,kukurydza,cheddar,mozzarella"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "GOŁĄBKI Z GRILLOWANEGO BAKŁAŻANA",
                Image = "~/Images/Recipes/Dishes/10.jpg",
                SpicyValue = dishParameters[9][0],
                SaltyValue = dishParameters[9][1],
                BitterValue = dishParameters[9][2],
                SweetValue = dishParameters[9][3],
                MeatValue = dishParameters[9][4],
                SourValue = dishParameters[9][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "bakłażan,indyk,cynamon,cebula,czosnek,chili,pietruszka,parmezan,oliwa,pomidor,białe wino,ogórek gruntowy,kmin rzymski,kolendra,mięta,jogurt naturalny,jogurt grecki,majonez"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "AROMATYCZNE BIRYANI Z SOCZEWICĄ, MARCHEWKĄ I POMIDORAMI",
                Image = "~/Images/Recipes/Dishes/11.jpg",
                SpicyValue = dishParameters[10][0],
                SaltyValue = dishParameters[10][1],
                BitterValue = dishParameters[10][2],
                SweetValue = dishParameters[10][3],
                MeatValue = dishParameters[10][4],
                SourValue = dishParameters[10][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "oliwa,cebula,czosnek,por,indyk,słodka papryka,ostra papryka,kolendra,kopr włoski,marchewka,pietruszka,ryż,czerwona soczewica,pomidor"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "FILETY DORSZA SMAŻONE W CURRY",
                Image = "~/Images/Recipes/Dishes/12.jpg",
                SpicyValue = dishParameters[11][0],
                SaltyValue = dishParameters[11][1],
                BitterValue = dishParameters[11][2],
                SweetValue = dishParameters[11][3],
                MeatValue = dishParameters[11][4],
                SourValue = dishParameters[11][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "dorsz,curry,ziemniaki,pieczarki,oregano,oliwa"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ŁOSOŚ W CIEŚCIE FRANCUSKIM",
                Image = "~/Images/Recipes/Dishes/13.jpg",
                SpicyValue = dishParameters[12][0],
                SaltyValue = dishParameters[12][1],
                BitterValue = dishParameters[12][2],
                SweetValue = dishParameters[12][3],
                MeatValue = dishParameters[12][4],
                SourValue = dishParameters[12][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,ciasto francuskie,czosnek,oliwa,sos sojowy,suszone pomidory,migdały,bazylia"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ŁOSOŚ SMAŻONY W SEZAMIE",
                Image = "~/Images/Recipes/Dishes/14.jpg",
                SpicyValue = dishParameters[13][0],
                SaltyValue = dishParameters[13][1],
                BitterValue = dishParameters[13][2],
                SweetValue = dishParameters[13][3],
                MeatValue = dishParameters[13][4],
                SourValue = dishParameters[13][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,makaron gryczany,makaron ryżowy,biały sezam,czarny sezam,sos sojowy,miód,imbir,biała rzodkiewka,chili,ocet ryżowy,cukier trzcinowy"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "BURGERY Z ŁOSOSIA, SZPINAKU I RYŻU",
                Image = "~/Images/Recipes/Dishes/15.jpg",
                SpicyValue = dishParameters[14][0],
                SaltyValue = dishParameters[14][1],
                BitterValue = dishParameters[14][2],
                SweetValue = dishParameters[14][3],
                MeatValue = dishParameters[14][4],
                SourValue = dishParameters[14][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,ryż,szpinak,jajko,oregano,tymianek,natka pietruszki,gałka muszkatołowa,oliwa,jogurt grecki,szczypiorek,czosnek"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "KURCZAK W MARYNACIE JOGURTOWEJ ZAPIEKANY Z MOZZARELLĄ I POMIDORKAMI",
                Image = "~/Images/Recipes/Dishes/16.jpg",
                SpicyValue = dishParameters[15][0],
                SaltyValue = dishParameters[15][1],
                BitterValue = dishParameters[15][2],
                SweetValue = dishParameters[15][3],
                MeatValue = dishParameters[15][4],
                SourValue = dishParameters[15][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,czerwona papryka,jogurt grecki,oliwa,miód,mozzarella,pomidorki koktajlowe,oregano"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "BAKŁAŻANY ZAPIEKANE Z MIĘSEM, KASZĄ GRYCZANĄ I JOGURTEM GRECKIM",
                Image = "~/Images/Recipes/Dishes/17.jpg",
                SpicyValue = dishParameters[16][0],
                SaltyValue = dishParameters[16][1],
                BitterValue = dishParameters[16][2],
                SweetValue = dishParameters[16][3],
                MeatValue = dishParameters[16][4],
                SourValue = dishParameters[16][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "bakłażań,oliwa,kasza gryczana,cebula,czosnek,mielone mięso,pomidor,koncentrat pomidorowy,cukier,oregano,tymianek,chili,natka pietruszki,cynamon"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "MOUSSAKA",
                Image = "~/Images/Recipes/Dishes/18.jpg",
                SpicyValue = dishParameters[17][0],
                SaltyValue = dishParameters[17][1],
                BitterValue = dishParameters[17][2],
                SweetValue = dishParameters[17][3],
                MeatValue = dishParameters[17][4],
                SourValue = dishParameters[17][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "bakłażan,oliwa,cebula,czosnek,mielone mięso,białe wino,pomidor,natka pietruszki,cynamon,chili,oregano"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ZAPIEKANKA Z ŁOSOSIEM, TARTĄ CUKINIĄ I PLASTERKAMI ZIEMNIAKÓW",
                Image = "~/Images/Recipes/Dishes/19.jpg",
                SpicyValue = dishParameters[18][0],
                SaltyValue = dishParameters[18][1],
                BitterValue = dishParameters[18][2],
                SweetValue = dishParameters[18][3],
                MeatValue = dishParameters[18][4],
                SourValue = dishParameters[18][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "ziemniaki,łosoś,cukinia,śmietanka,camembert,jajko,parmezan,oregano"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "PAPRYKI ZAPIEKANE Z MIELONYM KURCZAKIEM, RYŻEM I SOSEM POMIDOROWYM",
                Image = "~/Images/Recipes/Dishes/20.jpg",
                SpicyValue = dishParameters[19][0],
                SaltyValue = dishParameters[19][1],
                BitterValue = dishParameters[19][2],
                SweetValue = dishParameters[19][3],
                MeatValue = dishParameters[19][4],
                SourValue = dishParameters[19][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "ryż,czerwona papryka,oliwa,kurczak,cebula,czosnek,jajko,oregano,tymianek,natka pietruszki,pomidor,białe wino"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ZAPIEKANKA Z ŁOSOSIEM I BROKUŁAMI POD PLASTERKAMI ZRUMIENIONYCH ZIEMNIAKÓW",
                Image = "~/Images/Recipes/Dishes/21.jpg",
                SpicyValue = dishParameters[20][0],
                SaltyValue = dishParameters[20][1],
                BitterValue = dishParameters[20][2],
                SweetValue = dishParameters[20][3],
                MeatValue = dishParameters[20][4],
                SourValue = dishParameters[20][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,mleko,ziemniaki,por,brokuł,kapary,krewetki,oliwa"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ZAPIEKANKA MAKARONOWA Z DYNIĄ, KURCZAKIEM I SUSZONYMI GRZYBAMI",
                Image = "~/Images/Recipes/Dishes/22.jpg",
                SpicyValue = dishParameters[21][0],
                SaltyValue = dishParameters[21][1],
                BitterValue = dishParameters[21][2],
                SweetValue = dishParameters[21][3],
                MeatValue = dishParameters[21][4],
                SourValue = dishParameters[21][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "borowiki,makaron,kurczak,słodka papryka,oliwa,dynia,cebula,śmietanka,tymianek"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "KURCZAK W ORZECHACH",
                Image = "~/Images/Recipes/Dishes/23.jpg",
                SpicyValue = dishParameters[22][0],
                SaltyValue = dishParameters[22][1],
                BitterValue = dishParameters[22][2],
                SweetValue = dishParameters[22][3],
                MeatValue = dishParameters[22][4],
                SourValue = dishParameters[22][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,orzechy włoskie,parmezan,natka pietruszki,jajko"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "DORSZ W POMIDORACH Z TYMIANKIEM",
                Image = "~/Images/Recipes/Dishes/24.jpg",
                SpicyValue = dishParameters[23][0],
                SaltyValue = dishParameters[23][1],
                BitterValue = dishParameters[23][2],
                SweetValue = dishParameters[23][3],
                MeatValue = dishParameters[23][4],
                SourValue = dishParameters[23][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "oliwa,szczypiorek,cebula,pomidor,brązowy cukier,sos sojowy,tymianek,dorsz,pomidorki koktajlowe"
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "CHILI CON CARNE",
                Image = "~/Images/Recipes/Dishes/25.jpg",
                SpicyValue = dishParameters[24][0],
                SaltyValue = dishParameters[24][1],
                BitterValue = dishParameters[24][2],
                SweetValue = dishParameters[24][3],
                MeatValue = dishParameters[24][4],
                SourValue = dishParameters[24][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "oliwa,cebula,czosnek,chili,kmin rzymski,oregano,wołowina,pomidor,czerwona papryka,czerwona fasola,suszone pomidory,boczek"
            });
            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "CARROT CAKE #1",
            //    Description = "In one bowl sift all-purpose flour with sugar, baking powder, soda powder and spices. In another one mix eggs with oil. Combine ingredients from two bowls. Add carrots, pineapple and nuts. Put pie in 20cm-diameter form and bake for about 45 minutes. Leave it to cool down. Cut it along. Mix well all ingredients for cream. Spread over the inside and the topping. Decorate top with nuts.",
            //    Ingredients = "0.5 glass: all-purpose flour, sugar, 1 spoon: soda powder, baking powder, cinnamon, gingerbread spices, 0.3 cup vegetable oil, 2 fluffy eggs, 1 cup: nuts, grated carrot, few slices of pineapple, cream: 300g mascarpone, 6 tablespoons butter, 1.5 cup powdered sugar, 1 spoon vanilla extract",
            //    Temperature = "175",
            //    Time = "45 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/1.png"               
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "CINNAMON ROLLS",
            //    Description = "Sift flour. Heat up milk with sugar. Pour half of it to glass with yeast. Another half mix with butter and heat. Fluff eggs and add them to flour. Pour yeast and slowly add milk with butter. Mix precisely and knead it. Leave in warm place to grow. Roll it and smear with butter. Sprinkle with sugar and cinnamon. Collapse it and cut into pieces. Spread with fluffy eggs. Bake.",
            //    Ingredients = "550g all-purpose flour, yeast, 3 tablespoons sugar, 300ml milk, 80g butter, 3 small eggs, cinnamon",
            //    Temperature = "175",
            //    Time = "30 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cookies") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cookies/2.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "CHOCOLATE AND BANANA",
            //    Description = "In one bowl mash two bananas. Next add egg and vegetable oil. Mix them up. In another bowl mix flour, sugar, cacao, baking powder with baking soda. Combine ingredients from two bowls. At the end add chopped white chocolate. Leave a little bit for top decoration. Bake for about 20 minutes.",
            //    Ingredients = "1.5 cup all-purpose flour, 0.5 cup sugar, 0.25 cup cocoa, 1 spoon baking soda, 1 spoon baking powder, 3 bananas, 0.3 cup vegetable oil, 1 egg, 1 white chocolate",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/3.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "OREO",
            //    Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. Add smashed oreo cookies at the end. Bake for about 20 minutes. Start decoration when muffins are cooled down. Decorate each one with whipped cream and one Oreo cookie.",
            //    Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 24 oreo cookies, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/4.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "GINGERBREAD",
            //    Description = "In one bowl mix honey with eggs, buttermilk and vegetable oil. In another one mix flour with sugar, cacao, baking powder, baking soda and all spices. Combine ingredients from two bowls. Add grated apple and nuts at the end. Decorate top of each muffins with nuts. Bake for about 20 minutes.",
            //    Ingredients = "1.5 cup all-purpose flour, 0.5 cup: rye flour, sugar, honey, 1 spoon: baking powder, soda powder, gingerbread spices, 1 cup buttermilk, 1 egg, 50g oil, 2 tablespoons cocoa, 1 apple, 50 g of nuts",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/5.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "SNICKERS",
            //    Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. Chop snickers bars into dice and add them at the end. Leave a little bit for top decoration. Bake for about 20 minutes.",
            //    Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 3 snickers bars, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/6.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "BLUEBERRY",
            //    Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. At the end add chopped white chocolate and blueberries, but leaving a little bit for top decoration. Bake for about 20 minutes.",
            //    Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 1 white chocolate, 300g blueberries, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/7.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "STRAWBERRY",
            //    Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. At the end add chopped strawberries. Bake for about 20 minutes. ",
            //    Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 300g strawberries, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/8.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "SPINACH SPAGHETTI",
            //    Description = "Cook pasta. Heat olive oil on pan. Add spinach, onion, garlic and spices. Add chopped salmon. At the and add yogurt. Mix with pasta.",
            //    Ingredients = "200g pasta, 500g spinach, 100g smoked salmon, onion, garlic, spices, 100g yogurt",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dinners") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Dinners/9.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "GREEN SMOOTHIE",
            //    Description = "Using blender mix spinach with banana and apple juice.",
            //    Ingredients = "1 banana, 250ml apple juice, 250g spinach",
            //    Temperature = "",
            //    Time = "",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Shakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Shakes/10.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "RHUBARB CAKE",
            //    Description = "Chop rhubarb and sprinkle it with sugar. Leave it for about one hour to get rid of water. Mix butter with sugar, cream, yolk and vanilla extract. At the end add two types of flour. Knead shortly and put in the fridge for about 30 minutes. Spread form with butter. Roll cake into the form. Bake for 10 minutes in 200 degrees. Prepare pudding: mix 0.5 cup of milk with flour, yolks, sugar and vanilla extract. Mix until it will be smooth. Boil 0.5 cup of milk and add prepared earlier mixture when milk will boil. Mix it often and be careful not to burn it. Put pudding on baked pie and rhubarb. Bake for about 25 minutes.",
            //    Ingredients = "150g all-purpose flour, 150g rough flour, 200g butter, 100g sugar, 1 yolk, 2 tablespoons cream, 1 spoon vanilla extract, 3 rhubarb stalks, Pudding: 30g of all purpose flour, 3 yolks, 90g of sugar, 250ml of milk, 1 spoon of vanilla extract",
            //    Temperature = "175",
            //    Time = "25 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/11.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "OREO CHEESECAKE",
            //    Description = "Oreo cookies (without cream!) mix with melted butter. Put it at the bottom of form. Mix cheese with mascarpone, condensed milk and sugar. Mix shortly. While mixing add albumen and potato flour. Add few crumbled oreo cookies. Put the mixture in the form. Bake it for about one hour. When it will be cool down put it in the fridge overnight. Decorate top with whipped cream and oreo cookies. ",
            //    Ingredients = "500g cottage cheese, 250g mascarpone, 150g condensed milk, 2 tablespoons powdered sugar, 2 spoons potato flour, 3 albumen, 3 tablespoons butter, 150g oreo cookies",
            //    Temperature = "150",
            //    Time = "60 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/12.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "NUTELLA CHEESECAKE",
            //    Description = "Mix crushed Oreo with butter and press it in the bottom of form. Melt gelatin in the water. Beat cream cheese and powdered sugar. Add nutella and mascarpone and mix well. Spread the cheesecake filling over the crust and leave it overnight in the fridge. You can decorate it with melted chocolate.",
            //    Ingredients = "500g cottage cheese, 250g mascarpone, 150g condensed milk, 2 tablespoons powdered sugar, 2 spoons potato flour, 3 al3 tablespoons butter, 12 oreo cookies, 500g cream cheese, 1.5 cups powdered sugar, 0.5 cup Nutella, 1 cup mascarpone, 3 spoon gelatin melted in 2 tablespoon waterbumen, 3 tablespoons butter, 150g oreo cookies",
            //    Temperature = "",
            //    Time = "",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/13.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "BLUEBERRY SHAKE",
            //    Description = "Add protein powder to buttermilk, shake well. Using blender mix it with blueberries.",
            //    Ingredients = "250ml buttermilk, 30g protein powder, 200g blueberries",
            //    Temperature = "",
            //    Time = "",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Shakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Shakes/14.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "RASPBERRY CAKE",
            //    Description = "Mix butter with sugar, cream, yolk and vanilla extract. At the end add two types of flour. Knead shortly and put in the fridge for about 30 minutes. Spread form with butter. Roll cake into the form. Bake for 10 minutes in 200 degrees. Prepare pudding: mix 0.5 cup of milk with flour, yolks, sugar and vanilla extract. Mix until it will be smooth. Boil 0.5 cup of milk and add prepared earlier mixture when milk will boil. Mix it often and be careful not to burn it. Put on baked pie pudding and raspberries. Cover it with almonds. Bake for about 25 minutes.",
            //    Ingredients = "150g all-purpose flour, 150g rough flour, 200g butter, 100g sugar, 1 yolk, 2 tablespoons cream, 1 spoon vanilla extract, 500g raspberries, Pudding: 30g of all purpose flour, 3 yolks, 90g of sugar, 250ml of milk, 1 spoon of vanilla extract",
            //    Temperature = "175",
            //    Time = "25 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/15.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "PEANUT CHEESE CAKE",
            //    Description = "Mix peanut butter with cookies. Put it at the bottom of 30cm-diameter form. Mix well cheese with mascarpone, heavy cream and vanilla extract. Add eggs and mix again. At the end add two types of flour, sugar powder and melted white chocolate. Put mixture in the form. Bake in 220 degrees for 15 minutes, and for the next two hours lower the temperature to 100 degrees and bake for next 2 hours. When the cake will cool down decorate with dulce de leche and nuts.",
            //    Ingredients = "1000g cheese, 200g mascarpone, 150g sugar powder, 4 tablespoons peanut butter, 2 tablespoons potato flour, 2 tablespoons all-purpose flour, 5 eggs, 100g white chocolate, 200g heavy cream, 1 spoon vanilla extract, 100g peanut in honey, 200g cookies, 200g dulce de leche",
            //    Temperature = "",
            //    Time = "",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/16.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "RHUBARB WITH PUDDING",
            //    Description = "Chop rhubarb and sprinkle it with sugar. Leave it for about one hour to get rid of water.  Prepare pudding: mix 0.5 cup of milk with flour, yolks, sugar and vanilla extract. Mix until it will be smooth. Boil 0.5 cup of milk and add prepared earlier mixture when milk will boil. Mix it often and be careful not to burn it. In one bowl mix melted butter with egg. Add vanilla extract, egg and yogurt. Mix it well. Add sieved flour with baking powder. Mix everything up. When putting in form do it in layers. Firstly put pie, then pudding and rhubarb. Cover it with pie. Decorate each muffin with rhubarb. Bake for about 20 minutes.",
            //    Ingredients = "2 cups all-purpose flour, 1 spoon baking powder, 0.5 cup sugar, 100g melted butter, 1 egg, 1 cup yogurt, 3 rhubarb stalks, pudding: 1 cup milk, 30g all-purpose flour, 3 yolks, 90g sugar, 1 spoon vanilla extract",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/17.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "MOLE MOUND",
            //    Description = "In one bowl add sieved flour, baking powder, soda powder, cocoa and sugar. In another one mix egg with milk and buttermilk. Combine ingredients from two bowls. Bake for about 20 minutes. When muffins will be cool down make in each one hole with spoon – don’t throw the pie away! Chop banana in small pieces and sprinkle with lemon juice. Melt gelatin in 3 table spoons of hot water and leave to cool down. Whip cream and in the end add sugar powder and gelatin. Mix well. In each muffin hole put firstly chopped banana then add cream and cover with pie. Put in fridge for about one hour. ",
            //    Ingredients = "2 cups all-purpose flour, 0.5 cup sugar, 1 cup milk, 0.5 cup buttermilk, 2 tablespoon cocoa, 1 egg, 1 spoon baking powder, 1 spoon soda powder, 1 banana, cream: 200g 30% sour cream, 1 spoon gelatin, 4 table spoons sugar powder",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/18.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "CARROT CAKE #2",
            //    Description = "Mix well eggs with sugar. While mixing add vegetable oil. Add partially flour with baking powder and soda powder. Add cinnamon and gingerbread spice. At the end add carrots with nuts. Fill 30cm-diameter form with pie and bake it for about 45 minutes. Leave it to cool down. Mix well all ingredients for topping and decorate the cake with it. Add orange for extra decoration. ",
            //    Ingredients = "2 cups grated carrot, 1.5 cup all-purpose flour, 4 eggs, 0.5 cup vegetable oil, 0.5 cup sugar, 1 spoon baking powder, 1 spoon soda powder, 1 spoon cinnamon, 1 spoon gingerbread spice, 1 cap nuts, Topping: 100g cream cheese, 4 spoon honey, 2 tablespoon butter",
            //    Temperature = "175",
            //    Time = "45 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/19.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "STRAWBERRY MILLET",
            //    Description = "Boil millet in salted water (250ml) for about 10 minutes. Leave it covered to sink the water. Add honey, cinnamon and desiccated coconut. Smashed well strawberries. Put it in jar in layers: millet, strawberries and yogurt. Add favorite nuts.",
            //    Ingredients = "50g millet, cinnamon, 100g yogurt, 1 spoon honey, 2 spoon desiccated coconut, 250g strawberries, nuts",
            //    Temperature = "",
            //    Time = "",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dinners") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Dinners/20.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "BANANA & NUTS",
            //    Description = "Mash bananas in one bowl. Add to them buttermilk, honey, eggs and vanilla extract. Mix them well. In another bowl mix flour with sugar, baking powder, soda powder and cinnamon. Combine ingredients from two bowls. Decorate each muffin with mashed nuts. Bake for about 30 minutes..",
            //    Ingredients = "2 cups all-purpose flour, 0.5 cup sugar, 2 table spoons honey, 2 bananas, 200g nuts, 2 eggs, 250 ml buttermilk, 1 spoon soda powder, 1 spoon baking powder, 1 spoon cinnamon, 1 spoon vanilla extract",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/21.png"
            //});
        }
        #endregion
    }
}
