using BlondsCooking.Models.Structure;

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
            context.Categories.AddOrUpdate(new Category()
            {
                Name = "Muffins"
            });
            context.Categories.AddOrUpdate(new Category()
            {
                Name = "Cookies"
            });
            context.Categories.AddOrUpdate(new Category()
            {
                Name = "Cakes"
            });
            context.Categories.AddOrUpdate(new Category()
            {
                Name = "Shakes"
            });
            context.Categories.AddOrUpdate(new Category()
            {
                Name = "Dinners"
            });
            context.Categories.AddOrUpdate(new Category()
            {
                Name = "Pancakes"
            });
        }

        #endregion

        #region Recipes

        private void AddOrUpdateRecipes(BlondsCookingContext context)
        {
            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "CARROT CAKE #1",
                Description = "In one bowl sift all-purpose flour with sugar, baking powder, soda powder and spices. In another one mix eggs with oil. Combine ingredients from two bowls. Add carrots, pineapple and nuts. Put pie in 20cm-diameter form and bake for about 45 minutes. Leave it to cool down. Cut it along. Mix well all ingredients for cream. Spread over the inside and the topping. Decorate top with nuts.",
                Ingredients = "0.5 glass: all-purpose flour, sugar, 1 spoon: soda powder, baking powder, cinnamon, gingerbread spices, 0.3 cup vegetable oil, 2 fluffy eggs, 1 cup: nuts, grated carrot, few slices of pineapple, cream: 300g mascarpone, 6 tablespoons butter, 1.5 cup powdered sugar, 1 spoon vanilla extract",
                Temperature = "175",
                Time = "45 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Cakes/1.png"               
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "CINNAMON ROLLS",
                Description = "Sift flour. Heat up milk with sugar. Pour half of it to glass with yeast. Another half mix with butter and heat. Fluff eggs and add them to flour. Pour yeast and slowly add milk with butter. Mix precisely and knead it. Leave in warm place to grow. Roll it and smear with butter. Sprinkle with sugar and cinnamon. Collapse it and cut into pieces. Spread with fluffy eggs. Bake.",
                Ingredients = "550g all-purpose flour, yeast, 3 tablespoons sugar, 300ml milk, 80g butter, 3 small eggs, cinnamon",
                Temperature = "175",
                Time = "30 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cookies") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Cookies/2.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "CHOCOLATE AND BANANA",
                Description = "In one bowl mash two bananas. Next add egg and vegetable oil. Mix them up. In another bowl mix flour, sugar, cacao, baking powder with baking soda. Combine ingredients from two bowls. At the end add chopped white chocolate. Leave a little bit for top decoration. Bake for about 20 minutes.",
                Ingredients = "1.5 cup all-purpose flour, 0.5 cup sugar, 0.25 cup cocoa, 1 spoon baking soda, 1 spoon baking powder, 3 bananas, 0.3 cup vegetable oil, 1 egg, 1 white chocolate",
                Temperature = "175",
                Time = "20 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Muffins/3.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "OREO",
                Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. Add smashed oreo cookies at the end. Bake for about 20 minutes. Start decoration when muffins are cooled down. Decorate each one with whipped cream and one Oreo cookie.",
                Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 24 oreo cookies, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
                Temperature = "175",
                Time = "20 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Muffins/4.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "GINGERBREAD",
                Description = "In one bowl mix honey with eggs, buttermilk and vegetable oil. In another one mix flour with sugar, cacao, baking powder, baking soda and all spices. Combine ingredients from two bowls. Add grated apple and nuts at the end. Decorate top of each muffins with nuts. Bake for about 20 minutes.",
                Ingredients = "1.5 cup all-purpose flour, 0.5 cup: rye flour, sugar, honey, 1 spoon: baking powder, soda powder, gingerbread spices, 1 cup buttermilk, 1 egg, 50g oil, 2 tablespoons cocoa, 1 apple, 50 g of nuts",
                Temperature = "175",
                Time = "20 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Muffins/5.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "SNICKERS",
                Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. Chop snickers bars into dice and add them at the end. Leave a little bit for top decoration. Bake for about 20 minutes.",
                Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 3 snickers bars, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
                Temperature = "175",
                Time = "20 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Muffins/6.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "BLUEBERRY",
                Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. At the end add chopped white chocolate and blueberries, but leaving a little bit for top decoration. Bake for about 20 minutes.",
                Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 1 white chocolate, 300g blueberries, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
                Temperature = "175",
                Time = "20 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Muffins/7.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "STRAWBERRY",
                Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. At the end add chopped strawberries. Bake for about 20 minutes. ",
                Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 300g strawberries, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
                Temperature = "175",
                Time = "20 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Muffins/8.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "SPINACH SPAGHETTI",
                Description = "Cook pasta. Heat olive oil on pan. Add spinach, onion, garlic and spices. Add chopped salmon. At the and add yogurt. Mix with pasta.",
                Ingredients = "200g pasta, 500g spinach, 100g smoked salmon, onion, garlic, spices, 100g yogurt",
                Temperature = "175",
                Time = "20 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dinners") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Diners/9.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "GREEN SMOOTHIE",
                Description = "Using blender mix spinach with banana and apple juice.",
                Ingredients = "1 banana, 250ml apple juice, 250g spinach",
                Temperature = "",
                Time = "",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Shakes") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Shakes/10.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "RHUBARB CAKE",
                Description = "Chop rhubarb and sprinkle it with sugar. Leave it for about one hour to get rid of water. Mix butter with sugar, cream, yolk and vanilla extract. At the end add two types of flour. Knead shortly and put in the fridge for about 30 minutes. Spread form with butter. Roll cake into the form. Bake for 10 minutes in 200 degrees. Prepare pudding: mix 0.5 cup of milk with flour, yolks, sugar and vanilla extract. Mix until it will be smooth. Boil 0.5 cup of milk and add prepared earlier mixture when milk will boil. Mix it often and be careful not to burn it. Put pudding on baked pie and rhubarb. Bake for about 25 minutes.",
                Ingredients = "150g all-purpose flour, 150g rough flour, 200g butter, 100g sugar, 1 yolk, 2 tablespoons cream, 1 spoon vanilla extract, 3 rhubarb stalks, Pudding: 30g of all purpose flour, 3 yolks, 90g of sugar, 250ml of milk, 1 spoon of vanilla extract",
                Temperature = "175",
                Time = "25 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Cakes/11.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "OREO CHEESECAKE",
                Description = "Oreo cookies (without cream!) mix with melted butter. Put it at the bottom of form. Mix cheese with mascarpone, condensed milk and sugar. Mix shortly. While mixing add albumen and potato flour. Add few crumbled oreo cookies. Put the mixture in the form. Bake it for about one hour. When it will be cool down put it in the fridge overnight. Decorate top with whipped cream and oreo cookies. ",
                Ingredients = "500g cottage cheese, 250g mascarpone, 150g condensed milk, 2 tablespoons powdered sugar, 2 spoons potato flour, 3 albumen, 3 tablespoons butter, 150g oreo cookies",
                Temperature = "150",
                Time = "60 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Cakes/12.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "NUTELLA CHEESECAKE",
                Description = "Mix crushed Oreo with butter and press it in the bottom of form. Melt gelatin in the water. Beat cream cheese and powdered sugar. Add nutella and mascarpone and mix well. Spread the cheesecake filling over the crust and leave it overnight in the fridge. You can decorate it with melted chocolate.",
                Ingredients = "500g cottage cheese, 250g mascarpone, 150g condensed milk, 2 tablespoons powdered sugar, 2 spoons potato flour, 3 al3 tablespoons butter, 12 oreo cookies, 500g cream cheese, 1.5 cups powdered sugar, 0.5 cup Nutella, 1 cup mascarpone, 3 spoon gelatin melted in 2 tablespoon waterbumen, 3 tablespoons butter, 150g oreo cookies",
                Temperature = "",
                Time = "",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Cakes/13.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "BLUEBERRY SHAKE",
                Description = "Add protein powder to buttermilk, shake well. Using blender mix it with blueberries.",
                Ingredients = "250ml buttermilk, 30g protein powder, 200g blueberries",
                Temperature = "",
                Time = "",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Shakes") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Shakes/14.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "RASPBERRY CAKE",
                Description = "Mix butter with sugar, cream, yolk and vanilla extract. At the end add two types of flour. Knead shortly and put in the fridge for about 30 minutes. Spread form with butter. Roll cake into the form. Bake for 10 minutes in 200 degrees. Prepare pudding: mix 0.5 cup of milk with flour, yolks, sugar and vanilla extract. Mix until it will be smooth. Boil 0.5 cup of milk and add prepared earlier mixture when milk will boil. Mix it often and be careful not to burn it. Put on baked pie pudding and raspberries. Cover it with almonds. Bake for about 25 minutes.",
                Ingredients = "150g all-purpose flour, 150g rough flour, 200g butter, 100g sugar, 1 yolk, 2 tablespoons cream, 1 spoon vanilla extract, 500g raspberries, Pudding: 30g of all purpose flour, 3 yolks, 90g of sugar, 250ml of milk, 1 spoon of vanilla extract",
                Temperature = "175",
                Time = "25 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Cakes/15.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "PEANUT CHEESE CAKE",
                Description = "Mix peanut butter with cookies. Put it at the bottom of 30cm-diameter form. Mix well cheese with mascarpone, heavy cream and vanilla extract. Add eggs and mix again. At the end add two types of flour, sugar powder and melted white chocolate. Put mixture in the form. Bake in 220 degrees for 15 minutes, and for the next two hours lower the temperature to 100 degrees and bake for next 2 hours. When the cake will cool down decorate with dulce de leche and nuts.",
                Ingredients = "1000g cheese, 200g mascarpone, 150g sugar powder, 4 tablespoons peanut butter, 2 tablespoons potato flour, 2 tablespoons all-purpose flour, 5 eggs, 100g white chocolate, 200g heavy cream, 1 spoon vanilla extract, 100g peanut in honey, 200g cookies, 200g dulce de leche",
                Temperature = "",
                Time = "",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Cakes/16.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "RHUBARB WITH PUDDING",
                Description = "Chop rhubarb and sprinkle it with sugar. Leave it for about one hour to get rid of water.  Prepare pudding: mix 0.5 cup of milk with flour, yolks, sugar and vanilla extract. Mix until it will be smooth. Boil 0.5 cup of milk and add prepared earlier mixture when milk will boil. Mix it often and be careful not to burn it. In one bowl mix melted butter with egg. Add vanilla extract, egg and yogurt. Mix it well. Add sieved flour with baking powder. Mix everything up. When putting in form do it in layers. Firstly put pie, then pudding and rhubarb. Cover it with pie. Decorate each muffin with rhubarb. Bake for about 20 minutes.",
                Ingredients = "2 cups all-purpose flour, 1 spoon baking powder, 0.5 cup sugar, 100g melted butter, 1 egg, 1 cup yogurt, 3 rhubarb stalks, pudding: 1 cup milk, 30g all-purpose flour, 3 yolks, 90g sugar, 1 spoon vanilla extract",
                Temperature = "175",
                Time = "20 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Muffins/17.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "MOLE MOUND",
                Description = "In one bowl add sieved flour, baking powder, soda powder, cocoa and sugar. In another one mix egg with milk and buttermilk. Combine ingredients from two bowls. Bake for about 20 minutes. When muffins will be cool down make in each one hole with spoon – don’t throw the pie away! Chop banana in small pieces and sprinkle with lemon juice. Melt gelatin in 3 table spoons of hot water and leave to cool down. Whip cream and in the end add sugar powder and gelatin. Mix well. In each muffin hole put firstly chopped banana then add cream and cover with pie. Put in fridge for about one hour. ",
                Ingredients = "2 cups all-purpose flour, 0.5 cup sugar, 1 cup milk, 0.5 cup buttermilk, 2 tablespoon cocoa, 1 egg, 1 spoon baking powder, 1 spoon soda powder, 1 banana, cream: 200g 30% sour cream, 1 spoon gelatin, 4 table spoons sugar powder",
                Temperature = "175",
                Time = "20 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Muffins/18.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "CARROT CAKE #2",
                Description = "Mix well eggs with sugar. While mixing add vegetable oil. Add partially flour with baking powder and soda powder. Add cinnamon and gingerbread spice. At the end add carrots with nuts. Fill 30cm-diameter form with pie and bake it for about 45 minutes. Leave it to cool down. Mix well all ingredients for topping and decorate the cake with it. Add orange for extra decoration. ",
                Ingredients = "2 cups grated carrot, 1.5 cup all-purpose flour, 4 eggs, 0.5 cup vegetable oil, 0.5 cup sugar, 1 spoon baking powder, 1 spoon soda powder, 1 spoon cinnamon, 1 spoon gingerbread spice, 1 cap nuts, Topping: 100g cream cheese, 4 spoon honey, 2 tablespoon butter",
                Temperature = "175",
                Time = "45 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Cakes/19.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "STRAWBERRY MILLET",
                Description = "Boil millet in salted water (250ml) for about 10 minutes. Leave it covered to sink the water. Add honey, cinnamon and desiccated coconut. Smashed well strawberries. Put it in jar in layers: millet, strawberries and yogurt. Add favorite nuts.",
                Ingredients = "50g millet, cinnamon, 100g yogurt, 1 spoon honey, 2 spoon desiccated coconut, 250g strawberries, nuts",
                Temperature = "",
                Time = "",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dinners") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Dinners/20.png"
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                Name = "BANANA & NUTS",
                Description = "Mash bananas in one bowl. Add to them buttermilk, honey, eggs and vanilla extract. Mix them well. In another bowl mix flour with sugar, baking powder, soda powder and cinnamon. Combine ingredients from two bowls. Decorate each muffin with mashed nuts. Bake for about 30 minutes..",
                Ingredients = "2 cups all-purpose flour, 0.5 cup sugar, 2 table spoons honey, 2 bananas, 200g nuts, 2 eggs, 250 ml buttermilk, 1 spoon soda powder, 1 spoon baking powder, 1 spoon cinnamon, 1 spoon vanilla extract",
                Temperature = "175",
                Time = "20 min",
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
                Image = "~/Images/Muffins/21.png"
            });
        }
        #endregion
    }
}
